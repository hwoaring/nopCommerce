using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Infrastructure;
using Nop.Core.Domain.Weixin;
using Nop.Services.Weixin;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.MP.Entities;
using Senparc.NeuChar.MessageHandlers;
using Nop.Services.Catalog;
using Nop.Services.Suppliers;
using Nop.Services.Marketing;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Marketing;

namespace Senparc.Weixin.MP.CommonService.CustomMessageHandler
{
    public partial class CustomMessageHandler
    {
        protected async Task<IResponseMessageBase> GetResponseMessagesByIdsAsync(List<int> messageIds, MessageResponseType? messageResponseType = null)
        {
            IResponseMessageBase responseMessage = null;

            var wmessageService = EngineContext.Current.Resolve<IWxMessageService>();
            var wmessages = await wmessageService.GetWxMessagesByIdsAsync(messageIds.ToArray());

            if (wmessages != null && wmessages.Count > 0)
            {
                foreach (var messageEntity in wmessages)
                {
                    MessageResponseType? currentResponseType = null;

                    //强制执行指定回复方式
                    if (messageResponseType.HasValue)
                        currentResponseType = messageResponseType;
                    else
                        currentResponseType = messageEntity.MessageResponseType;


                    if (currentResponseType == MessageResponseType.Custom)//客服方式回复
                    {
                        CustomResponseMessage(messageEntity, out responseMessage);
                    }
                    else if (currentResponseType == MessageResponseType.Passive)//被动方式回复
                    {
                        PassiveResponseMessage(messageEntity, out responseMessage);
                    }
                }
            }

            return responseMessage;
        }

        protected void CustomResponseMessage(WxMessage message, out IResponseMessageBase responseMessage)
        {
            responseMessage = null;

            switch (message.MessageType)
            {
                case MessageType.Text:
                    {
                        if (!string.IsNullOrEmpty(message.Content))
                        {
                            AdvancedAPIs.CustomApi.SendText(_senparcWeixinSetting.WeixinAppId,
                                OpenId, message.Content, kfAccount: message.KfAccount);
                        }
                        break;
                    }
                case MessageType.Image:
                    {
                        var messageService = EngineContext.Current.Resolve<IWxMessageService>();
                        //是否永久素材ID
                        if (!message.MaterialMsg)
                        {
                            if (string.IsNullOrEmpty(message.MediaId) ||  /*没有生成MediaId*/
                                message.CreatTime + 259200 - 3600 < Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now)  /*3天过期*/
                                )
                            {
                                if (!string.IsNullOrEmpty(message.PicUrl))
                                {
                                    //上传素材
                                    var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(_senparcWeixinSetting.WeixinAppId,
                                        UploadMediaFileType.image,
                                        _fileProvider.MapPath(message.PicUrl));

                                    //更新
                                    if (string.IsNullOrEmpty(uploadResult.errmsg))
                                    {
                                        message.MediaId = uploadResult.media_id;
                                        message.CreatTime = (int)uploadResult.created_at;
                                        messageService.UpdateWxMessageAsync(message);
                                    }
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(message.MediaId))
                        {
                            AdvancedAPIs.CustomApi.SendImage(_senparcWeixinSetting.WeixinAppId,
                                OpenId, message.MediaId, kfAccount: message.KfAccount);
                        }
                        break;
                    }
                case MessageType.Voice:
                    {
                        if (!string.IsNullOrEmpty(message.MediaId))
                        {
                            AdvancedAPIs.CustomApi.SendVoice(_senparcWeixinSetting.WeixinAppId,
                                OpenId, message.MediaId, kfAccount: message.KfAccount);
                        }
                        break;
                    }
                case MessageType.Video:
                    {
                        if (!string.IsNullOrEmpty(message.MediaId) &&
                            !string.IsNullOrEmpty(message.Title) &&
                            !string.IsNullOrEmpty(message.Description) &&
                            !string.IsNullOrEmpty(message.ThumbMediaId)
                            )
                        {
                            AdvancedAPIs.CustomApi.SendVideo(_senparcWeixinSetting.WeixinAppId,
                                OpenId, message.MediaId, message.Title, message.Description,
                                kfAccount: message.KfAccount, thumb_media_id: message.ThumbMediaId);
                        }
                        break;
                    }
                case MessageType.Music:
                    {
                        if (!string.IsNullOrEmpty(message.ThumbMediaId))
                        {
                            AdvancedAPIs.CustomApi.SendMusic(_senparcWeixinSetting.WeixinAppId,
                                OpenId, message.Title, message.Description,
                                message.MusicUrl, message.HqMusicUrl,
                                message.ThumbMediaId, kfAccount: message.KfAccount);
                        }
                        break;
                    }
                case MessageType.News:
                    {
                        var articles = new List<Article>();

                        if (!string.IsNullOrEmpty(message.Title) &&
                            !string.IsNullOrEmpty(message.Description) &&
                            !string.IsNullOrEmpty(message.PicUrl) &&
                            !string.IsNullOrEmpty(message.Url)
                            )
                        {
                            articles.Add(new Article
                            {
                                Title = message.Title,
                                Description = message.Description,
                                PicUrl = articles.Count == 0 ? message.PicUrl : message.ThumbPicUrl,  //第二条开始为小图
                                Url = message.Url
                            });
                        }

                        if (articles.Count > 0)
                        {
                            AdvancedAPIs.CustomApi.SendNews(_senparcWeixinSetting.WeixinAppId,
                            OpenId, articles, kfAccount: message.KfAccount);
                        }
                        break;
                    }
                case MessageType.MpNews:
                    {
                        if (!string.IsNullOrEmpty(message.MediaId))
                        {
                            AdvancedAPIs.CustomApi.SendMpNews(_senparcWeixinSetting.WeixinAppId,
                                OpenId, message.MediaId, kfAccount: message.KfAccount);
                        }
                        break;
                    }
                case MessageType.WxCard:
                    {
                        AdvancedAPIs.CardExt cardExt = null;
                        AdvancedAPIs.CustomApi.SendCard(_senparcWeixinSetting.WeixinAppId,
                            OpenId, message.MediaId, cardExt);
                        break;
                    }
                case MessageType.MiniProgramPage:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// 被动消息，每次只能有1条被动消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="responseMessage"></param>
        protected void PassiveResponseMessage(WxMessage message, out IResponseMessageBase responseMessage)
        {
            responseMessage = null;

            switch (message.MessageType)
            {
                case MessageType.Text:
                    {
                        if (!string.IsNullOrEmpty(message.Content))
                        {
                            var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                            strongResponseMessage.Content = message.Content;
                            responseMessage = strongResponseMessage;
                        }
                        break;
                    }
                case MessageType.Image:
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageImage>();

                        var messageService = EngineContext.Current.Resolve<IWxMessageService>();
                        //是否永久素材ID
                        if (!message.MaterialMsg)
                        {
                            if (string.IsNullOrEmpty(message.MediaId) ||  /*没有生成MediaId*/
                                message.CreatTime + 259200 - 3600 < Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now)  /*3天过期*/
                                )
                            {
                                if (!string.IsNullOrEmpty(message.PicUrl))
                                {
                                    //上传素材
                                    var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(_senparcWeixinSetting.WeixinAppId,
                                        UploadMediaFileType.image,
                                        _fileProvider.MapPath(message.PicUrl));

                                    //更新
                                    if (string.IsNullOrEmpty(uploadResult.errmsg))
                                    {
                                        message.MediaId = uploadResult.media_id;
                                        message.CreatTime = (int)uploadResult.created_at;
                                        messageService.UpdateWxMessageAsync(message);
                                    }
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(message.MediaId))
                        {
                            strongResponseMessage.Image.MediaId = message.MediaId;
                            responseMessage = strongResponseMessage;
                        }

                        break;
                    }
                case MessageType.Voice:
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageVoice>();

                        var messageService = EngineContext.Current.Resolve<IWxMessageService>();
                        //是否永久素材ID
                        if (!message.MaterialMsg)
                        {
                            if (string.IsNullOrEmpty(message.MediaId) ||  /*没有生成MediaId*/
                                message.CreatTime + 259200 - 3600 < Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now)  /*3天过期*/
                                )
                            {
                                if (!string.IsNullOrEmpty(message.MusicUrl))
                                {
                                    //上传素材
                                    var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(_senparcWeixinSetting.WeixinAppId,
                                        UploadMediaFileType.voice,
                                        _fileProvider.MapPath(message.MusicUrl));

                                    //更新
                                    if (string.IsNullOrEmpty(uploadResult.errmsg))
                                    {
                                        message.MediaId = uploadResult.media_id;
                                        message.CreatTime = (int)uploadResult.created_at;
                                        messageService.UpdateWxMessageAsync(message);
                                    }
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(message.MediaId))
                        {
                            strongResponseMessage.Voice.MediaId = message.MediaId;
                            responseMessage = strongResponseMessage;
                        }
                        break;
                    }
                case MessageType.Video:
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageVideo>();

                        var messageService = EngineContext.Current.Resolve<IWxMessageService>();
                        //是否永久素材ID
                        if (!message.MaterialMsg)
                        {
                            if (string.IsNullOrEmpty(message.MediaId) ||  /*没有生成MediaId*/
                                message.CreatTime + 259200 - 3600 < Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now)  /*3天过期*/
                                )
                            {
                                if (!string.IsNullOrEmpty(message.MusicUrl))
                                {
                                    //上传素材
                                    var uploadResultMediaId = AdvancedAPIs.MediaApi.UploadTemporaryMedia(_senparcWeixinSetting.WeixinAppId,
                                        UploadMediaFileType.video,
                                        _fileProvider.MapPath(message.MusicUrl));

                                    if (string.IsNullOrEmpty(uploadResultMediaId.errmsg))
                                    {
                                        message.MediaId = uploadResultMediaId.media_id;
                                        message.CreatTime = (int)uploadResultMediaId.created_at;
                                    }

                                    //上传缩微图
                                    if (!string.IsNullOrEmpty(message.ThumbPicUrl))
                                    {
                                        var uploadResultThumbId = AdvancedAPIs.MediaApi.UploadTemporaryMedia(_senparcWeixinSetting.WeixinAppId,
                                        UploadMediaFileType.thumb,
                                        _fileProvider.MapPath(message.ThumbPicUrl));

                                        if (string.IsNullOrEmpty(uploadResultThumbId.errmsg))
                                        {
                                            message.ThumbMediaId = uploadResultMediaId.media_id;
                                        }
                                    }

                                    //更新
                                    if (string.IsNullOrEmpty(uploadResultMediaId.errmsg))
                                    {
                                        messageService.UpdateWxMessageAsync(message);
                                    }
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(message.MediaId))
                        {
                            strongResponseMessage.Video.Title = message.Title;
                            strongResponseMessage.Video.Description = message.Description;
                            strongResponseMessage.Video.MediaId = message.MediaId;
                            responseMessage = strongResponseMessage;
                        }
                        break;
                    }
                case MessageType.Music:
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageMusic>();

                        var messageService = EngineContext.Current.Resolve<IWxMessageService>();
                        //是否永久素材ID
                        if (!message.MaterialMsg)
                        {
                            if (string.IsNullOrEmpty(message.ThumbMediaId) ||  /*没有生成ThumbMediaId*/
                                message.CreatTime + 259200 - 3600 < Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now)  /*3天过期*/
                                )
                            {
                                if (!string.IsNullOrEmpty(message.ThumbPicUrl))
                                {
                                    //上传素材
                                    var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(_senparcWeixinSetting.WeixinAppId,
                                        UploadMediaFileType.thumb,
                                        _fileProvider.MapPath(message.ThumbPicUrl));

                                    //更新
                                    if (string.IsNullOrEmpty(uploadResult.errmsg))
                                    {
                                        message.MediaId = uploadResult.media_id;
                                        message.ThumbMediaId = uploadResult.media_id;
                                        message.CreatTime = (int)uploadResult.created_at;
                                        messageService.UpdateWxMessageAsync(message);
                                    }
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(message.ThumbMediaId))
                        {
                            strongResponseMessage.Music.Title = message.Title;
                            strongResponseMessage.Music.Description = message.Description;
                            strongResponseMessage.Music.MusicUrl = message.MusicUrl;
                            strongResponseMessage.Music.HQMusicUrl = message.HqMusicUrl;
                            strongResponseMessage.Music.ThumbMediaId = message.ThumbMediaId;

                            responseMessage = strongResponseMessage;
                        }
                        break;
                    }
                case MessageType.News:
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();

                        if (!string.IsNullOrEmpty(message.Title) &&
                            !string.IsNullOrEmpty(message.Description) &&
                            !string.IsNullOrEmpty(message.PicUrl) &&
                            !string.IsNullOrEmpty(message.Url)
                            )
                        {
                            strongResponseMessage.Articles.Add(new Article
                            {
                                Title = message.Title,
                                Description = message.Description,
                                PicUrl = strongResponseMessage.Articles.Count == 0 ? message.PicUrl : message.ThumbPicUrl,  //第二条开始为小图
                                Url = message.Url
                            });
                        }

                        //TODO: 多条消息的ID存储在MediaId中，MediaId对应id消息类型只能是News类型

                        if (strongResponseMessage.Articles.Count > 0)
                            responseMessage = strongResponseMessage;

                        break;
                    }
                case MessageType.MpNews:
                    {
                        break;
                    }
                case MessageType.WxCard:
                    {
                        break;
                    }
                case MessageType.MiniProgramPage:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }


        protected async Task<IResponseMessageBase> GetQrCodeLimitPassiveResponseMessageAsync(QrCodeLimitBindingSource source)
        {
            IResponseMessageBase responseMessage = null;

            var content = string.Empty;

            var title = string.Empty;
            var description = string.Empty;
            var url = string.Empty;
            var imageUrl = string.Empty;
            var thumbImageUrl = string.Empty;
            var adverImageUrl = string.Empty;

            switch (source.SceneType)
            {
                case SceneType.Adver:
                    {
                        //可以为广告竖图
                        if (source.ProductId > 0)
                        {
                            var productService = EngineContext.Current.Resolve<IProductService>();
                            var product = await productService.GetProductByIdAsync(source.ProductId);
                            if (product != null)
                            {
                                title = product.Name;
                                description = product.ShortDescription;
                                imageUrl = product.CoverImageUrl;
                                thumbImageUrl = product.CoverThumbImageUrl;
                                url = source.UseFixUrl ? source.Url : "http://www.autosetyourproducturl.com/";
                            }

                            if (product != null)
                            {
                                //获取产品绑定的首张图片
                                var productAdvertImageService = EngineContext.Current.Resolve<IProductAdvertImageService>();
                                var productAdvertImages = await productAdvertImageService.GetEntitiesByProductIdAsync(product.Id, 1);
                                if (productAdvertImages.Count > 0)
                                {
                                    adverImageUrl = productAdvertImages[0].ImageUrl;
                                }
                            }

                        }
                        break;
                    }
                case SceneType.Message:
                    {
                        content = source.Content;
                        break;
                    }
                case SceneType.Product:
                    {
                        if (source.ProductId > 0)
                        {
                            var productService = EngineContext.Current.Resolve<IProductService>();
                            var product = await productService.GetProductByIdAsync(source.ProductId);
                            if (product != null)
                            {
                                title = product.Name;
                                description = product.ShortDescription;
                                imageUrl = product.CoverImageUrl;
                                thumbImageUrl = product.CoverThumbImageUrl;
                                url = source.UseFixUrl ? source.Url : "http://www.autosetyourproducturl.com/";
                            }

                            if (product != null)
                            {
                                //获取产品绑定的首张图片
                                var productAdvertImageService = EngineContext.Current.Resolve<IProductAdvertImageService>();
                                var productAdvertImages = await productAdvertImageService.GetEntitiesByProductIdAsync(product.Id, 1);
                                if (productAdvertImages.Count > 0)
                                {
                                    adverImageUrl = productAdvertImages[0].ImageUrl;
                                }
                            }
                        }
                        break;
                    }
                case SceneType.Supplier:
                    {
                        if (source.SupplierId > 0 && source.SupplierShopId > 0)
                        {
                            var supplierShopService = EngineContext.Current.Resolve<ISupplierShopService>();
                            var supplierShop = await supplierShopService.GetEntityByIdAsync(source.SupplierShopId);
                            if (supplierShop != null)
                            {
                                title = supplierShop.Name;
                                description = supplierShop.Description;
                                imageUrl = supplierShop.ImageUrl;
                                thumbImageUrl = supplierShop.ThumbImageUrl;
                                url = source.UseFixUrl ? source.Url : "http://www.autosetyoursuppliershopurl.com/";
                            }
                        }
                        break;
                    }
                case SceneType.Command:
                case SceneType.GiftCard://卡券领取操作放到二维码扫码事件或二维码关注事件中，同永久二维码一起处理
                case SceneType.IDCard:
                case SceneType.Verify:
                case SceneType.Vote:
                case SceneType.None:
                default:
                    {
                        return null;
                    }
            }

            switch (source.MessageType)
            {
                case MessageType.Text:
                    {
                        if (!string.IsNullOrEmpty(content))
                        {
                            var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                            strongResponseMessage.Content = content;
                            responseMessage = strongResponseMessage;
                        }
                        break;
                    }
                case MessageType.Image:
                    {
                        if (!string.IsNullOrEmpty(adverImageUrl))
                        {
                            //上传素材
                            var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(_senparcWeixinSetting.WeixinAppId,
                                UploadMediaFileType.image,
                                _fileProvider.MapPath(adverImageUrl));

                            //更新
                            if (string.IsNullOrEmpty(uploadResult.errmsg) && !string.IsNullOrEmpty(uploadResult.media_id))
                            {
                                var strongResponseMessage = CreateResponseMessage<ResponseMessageImage>();

                                strongResponseMessage.Image.MediaId = uploadResult.media_id;
                                responseMessage = strongResponseMessage;
                            }
                        }

                        break;
                    }
                case MessageType.Voice:
                    {
                        break;
                    }
                case MessageType.Video:
                    {
                        break;
                    }
                case MessageType.Music:
                    {
                        break;
                    }
                case MessageType.News:
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();

                        if (!string.IsNullOrEmpty(title) &&
                            !string.IsNullOrEmpty(description) &&
                            !string.IsNullOrEmpty(imageUrl) &&
                            !string.IsNullOrEmpty(url)
                            )
                        {
                            strongResponseMessage.Articles.Add(new Article
                            {
                                Title = title,
                                Description = description,
                                PicUrl = strongResponseMessage.Articles.Count == 0 ? imageUrl : thumbImageUrl,  //第二条开始为小图
                                Url = url
                            });


                        }

                        //TODO: 多条消息的ID存储在MediaId中，MediaId对应id消息类型只能是News类型

                        if (strongResponseMessage.Articles.Count > 0)
                            responseMessage = strongResponseMessage;

                        break;
                    }
                case MessageType.MpNews:
                    {
                        break;
                    }
                case MessageType.WxCard:
                    {
                        break;
                    }
                case MessageType.MiniProgramPage:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return responseMessage;
        }

        protected async Task<IResponseMessageBase> GetQrCodeTempPassiveResponseMessageAsync(Nop.Services.Weixin.QrCodeSceneString.QrCodeSceneParam source)
        {
            IResponseMessageBase responseMessage = null;

            switch (source.SceneType)
            {
                case SceneType.Adver:
                    {
                        int.TryParse(source.Value, out var adverId);
                        //可以为广告竖图
                        if (adverId > 0)
                        {
                            //获取广告图片
                            var productAdvertImageService = EngineContext.Current.Resolve<IProductAdvertImageService>();
                            var productAdvertImages = await productAdvertImageService.GetEntityByIdAsync(adverId);
                            if (productAdvertImages != null)
                            {
                                if (!string.IsNullOrEmpty(productAdvertImages.ImageUrl))
                                {
                                    //上传素材
                                    var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(_senparcWeixinSetting.WeixinAppId,
                                        UploadMediaFileType.image,
                                        _fileProvider.MapPath(productAdvertImages.ImageUrl));

                                    if (string.IsNullOrEmpty(uploadResult.errmsg) && !string.IsNullOrEmpty(uploadResult.media_id))
                                    {
                                        var strongResponseMessage = CreateResponseMessage<ResponseMessageImage>();
                                        strongResponseMessage.Image.MediaId = uploadResult.media_id;
                                        responseMessage = strongResponseMessage;
                                    }
                                }
                            }

                        }
                        break;
                    }
                case SceneType.Message:
                    {
                        if (!string.IsNullOrEmpty(source.Value))
                        {
                            var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                            strongResponseMessage.Content = source.Value;
                            responseMessage = strongResponseMessage;
                        }
                        break;
                    }
                case SceneType.Product:
                    {
                        int.TryParse(source.Value, out var productId);
                        if (productId > 0)
                        {
                            var productService = EngineContext.Current.Resolve<IProductService>();
                            var product = await productService.GetProductByIdAsync(productId);
                            if (product != null)
                            {
                                var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();

                                if (!string.IsNullOrEmpty(product.Name) &&
                                    !string.IsNullOrEmpty(product.ShortDescription) &&
                                    !string.IsNullOrEmpty(product.CoverThumbImageUrl)
                                    )
                                {
                                    strongResponseMessage.Articles.Add(new Article
                                    {
                                        Title = product.Name,
                                        Description = product.ShortDescription,
                                        PicUrl = product.CoverImageUrl,    //第二条开始应为小图
                                        Url = "http://www.autosetyourproducturl.com/"
                                    });
                                }

                                //TODO: 多条消息的ID存储在MediaId中，MediaId对应id消息类型只能是News类型

                                if (strongResponseMessage.Articles.Count > 0)
                                    responseMessage = strongResponseMessage;
                            }
                        }
                        break;
                    }
                case SceneType.Supplier:
                    {
                        int.TryParse(source.Value, out var supplierId);
                        int.TryParse(source.Value1, out var supplierShopId);
                        if (supplierId > 0 && supplierShopId > 0)
                        {
                            var supplierShopService = EngineContext.Current.Resolve<ISupplierShopService>();
                            var supplierShop = await supplierShopService.GetEntityByIdAsync(supplierShopId);
                            if (supplierShop != null)
                            {
                                var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();

                                if (!string.IsNullOrEmpty(supplierShop.Name) &&
                                   !string.IsNullOrEmpty(supplierShop.Description) &&
                                   !string.IsNullOrEmpty(supplierShop.ImageUrl)
                                   )
                                {
                                    strongResponseMessage.Articles.Add(new Article
                                    {
                                        Title = supplierShop.Name,
                                        Description = supplierShop.Description,
                                        PicUrl = supplierShop.ImageUrl,  //第二条开始应为小图
                                        Url = "http://www.autosetyourproducturl.com/"
                                    });
                                }

                                //TODO: 多条消息的ID存储在MediaId中，MediaId对应id消息类型只能是News类型

                                if (strongResponseMessage.Articles.Count > 0)
                                    responseMessage = strongResponseMessage;
                            }
                        }
                        break;
                    }
                case SceneType.Verify:
                    {
                        if (!string.IsNullOrEmpty(source.Value))
                        {
                            var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                            strongResponseMessage.Content = source.Value;
                            responseMessage = strongResponseMessage;
                        }
                        break;
                    }
                case SceneType.Command:
                    {
                        if (!string.IsNullOrEmpty(source.Value))
                        {
                            var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                            strongResponseMessage.Content = "命令执行完成";
                            responseMessage = strongResponseMessage;
                        }
                        break;
                    }
                case SceneType.Vote:
                    {
                        if (!string.IsNullOrEmpty(source.Value))
                        {
                            var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                            strongResponseMessage.Content = "投票成功";
                            responseMessage = strongResponseMessage;
                        }
                        break;
                    }
                case SceneType.GiftCard: //卡券领取操作放到二维码扫码事件或二维码关注事件中，同永久二维码一起处理
                case SceneType.IDCard:
                case SceneType.None:
                default:
                    {
                        break;
                    }
            }

            return responseMessage;
        }

        protected async Task<IResponseMessageBase> GetAndSetSupplierVoucherCouponPassiveResponseMessageAsync(List<int> cardIds, Nop.Services.Weixin.QrCodeSceneString.QrCodeSceneParam qrCodeSceneParam, string currentOpenId)
        {
            IResponseMessageBase responseMessage = null;
            var receiveNumber = 0; //本次领取总数

            var userAssetIncomeHistoryService = EngineContext.Current.Resolve<IUserAssetIncomeHistoryService>();
            var supplierVoucherCouponService = EngineContext.Current.Resolve<ISupplierVoucherCouponService>();

            var currentCustomer = await _customerService.GetCustomerByOpenIdAsync(currentOpenId);
            if (currentCustomer == null)
                return null;

            var supplierVoucherCoupons = await supplierVoucherCouponService.GetEntitiesByIdsAsync(cardIds.ToArray());

            //循环给扫码用户赠送卡券到账户（判断领取条件和是否重复）

            foreach (var item in supplierVoucherCoupons)
            {
                if (item.LimitUsableNumber > 0)
                {
                    var userAssetIncomeHistory =await userAssetIncomeHistoryService.GetEntitiesBySupplierVoucherCouponIdAsync(currentCustomer.Id, item.Id, true);
                    if (userAssetIncomeHistory.Count >= item.LimitUsableNumber)
                        continue;
                }
                if (item.LimitReceiveNumber > 0)
                {
                    var userAssetIncomeHistory =await userAssetIncomeHistoryService.GetEntitiesBySupplierVoucherCouponIdAsync(currentCustomer.Id, item.Id);
                    if (userAssetIncomeHistory.Count >= item.LimitUsableNumber)
                        continue;
                }

                //为当前用户添加卡券资产
                await userAssetIncomeHistoryService.InsertEntityBysupplierVoucherCouponParamsAsync(item, currentCustomer.Id, 0, null, qrCodeSceneParam.SceneType);

                receiveNumber++; //成功领取计数
            }

            string descripion;
            if (receiveNumber > 0)
                descripion = string.Format("您已成功领取{0}张卡券，请前往卡券管理页面查看或使用！", receiveNumber);
            else
                descripion = "该卡券已领取，同一账号请勿重复领取！(前往卡券管理页面查看/使用)";

            if (supplierVoucherCoupons.Count == 0)
                descripion = "抱歉，该卡券已领完，请关注其他优惠活动！";

            //回复卡券领取成功消息
            var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();
            strongResponseMessage.Articles.Add(new Article
            {
                Title = "卡券领取通知",
                Description = descripion,
                PicUrl = "http://www.giftcardsuccess.com/giftcard.jpg",
                Url = "http://www.giftcardsuccess.com/"
            });

            //TODO: 多条消息的ID存储在MediaId中，MediaId对应id消息类型只能是News类型

            if (strongResponseMessage.Articles.Count > 0)
                responseMessage = strongResponseMessage;

            return responseMessage;
        }

    }
}
