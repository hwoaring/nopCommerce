using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Publics;

namespace Nop.Core.Domain.Shares;

/// <summary>
/// 分享页面设置信息
/// </summary>
public partial class SharePage : BaseEntity
{
    /// <summary>
    /// 实例ID
    /// </summary>
    public int EntityId { get; set; }

    /// <summary>
    /// 实例页面类型ID
    /// </summary>
    public int PublicEntityTypeId { get; set; }

    /// <summary>
    /// 微信上传返回的媒体文件ID（为微信自动回复消息准备）
    /// </summary>
    public string MediaId { get; set; }

    /// <summary>
    /// 微信上传返回的缩略图的媒体id（为微信自动回复消息准备）
    /// </summary>
    public string ThumbMediaId { get; set; }

    /// <summary>
    /// 基础浏览量（增加浏览量基数）
    /// </summary>
    public int BaseViewsCount { get; set; }

    /// <summary>
    /// 推荐基数
    /// </summary>
    public int BaseRecommendeCount { get; set; }

    /// <summary>
    /// 收藏基数
    /// </summary>
    public int BaseFavoriteCount { get; set; }

    /// <summary>
    /// 点赞基数
    /// </summary>
    public int BaseThumbCount { get; set; }

    /// <summary>
    /// 分享基数
    /// </summary>
    public int BaseShareCount { get; set; }

    /// <summary>
    /// 分享标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 标语
    /// </summary>
    public string Slogan { get; set; }

    /// <summary>
    /// 分享描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 宣传文字，推广文字
    /// 发了链接后，朋友圈单独发推广的文字（有利于增加链接点击量）
    /// </summary>
    public string PromotionText { get; set; }

    /// <summary>
    /// 分享链接（可用于生成二维码链接）
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 分享小图片链接(分享链接的小图)
    /// </summary>
    public int SmallPictureId { get; set; }

    /// <summary>
    /// 分享大图片链接(分享链接的小图)
    /// </summary>
    public int BigPictureId { get; set; }

    /// <summary>
    /// 绑定推荐人，任何人分享的时候，阅读人的临时推荐人都是该绑定的推荐人
    /// （分享页面绑定用户ID，针对给了现金广告费的用户，所有用户分享时，没有永久推荐人的，设置为永久推荐人
    /// 有永久推荐人的，设置为临时推荐人，赚取分享广告费的用户，在本次分享中不参与分享人记录）
    /// </summary>
    public int BindCustomerId { get; set; }

    /// <summary>
    /// 是否及时分享
    /// 及时分享链接，将优先选择及时分享人，再选择临时分享人，最后选择永久分享人。
    /// </summary>
    public bool TimelySharing { get; set; }

    /// <summary>
    /// 开启海报图片设置（海报/广告图）
    /// </summary>
    public bool EnableSharePicture { get; set; }

    /// <summary>
    /// 开启推广计数（计算推广阅读数，结算广告佣金）
    /// </summary>
    public bool EnablePromotion { get; set; }

    /// <summary>
    /// 浏览计数比：访客浏览一次计算多少广告点数比例
    /// </summary>
    public decimal AdvertCommissionRatio { get; set; }

    /// <summary>
    /// 广告点数结算兑换的券是否允许拆分分开使用
    /// </summary>
    public bool AdvertCommissionSplit { get; set; }

    /// <summary>
    /// 自购分销权限金额（供应商没有购买全部服务时）
    /// </summary>
    public decimal SharePermissionFee { get; set; }

    /// <summary>
    /// 是否允许分享人关闭在线下单按钮，只展示个人联系方式
    /// </summary>
    public bool AllowOrderOffline { get; set; }

    /// <summary>
    /// 自购关闭线上交易的服务费金额（分销人要关闭线上交易链接，
    /// 只显示个人联系方式，需要购买关闭线上交易的线下服务）
    /// </summary>
    public decimal OfflineServiceFee { get; set; }

    /// <summary>
    /// 分享循环周期天数
    /// </summary>
    public int ShareCycleDays { get; set; }

    /// <summary>
    /// 广告代金券结算后，有效使用时间（如365天内有效）
    /// </summary>
    public int BalanceExpireDays { get; set; }

    /// <summary>
    /// 指定到Store
    /// </summary>
    public int LimitToStoreId { get; set; }

    /// <summary>
    /// 指定到VendorStore
    /// </summary>
    public int LimitToVendorStoreId { get; set; }

    /// <summary>
    /// 指定到Brand
    /// </summary>
    public int LimitToBrandId { get; set; }

    /// <summary>
    /// 指定到Product
    /// </summary>
    public int LimitToProductId { get; set; }

    /// <summary>
    /// 展示分享人编码
    /// </summary>
    public bool DisplaySharerCode { get; set; }

    /// <summary>
    /// 展示分享人信息（如头像，昵称）
    /// </summary>
    public bool DisplaySharerUser { get; set; }

    /// <summary>
    /// 是否启用分享页设置
    /// </summary>
    public bool EnableSharePage { get; set; }

    /// <summary>
    /// 页面类型
    /// </summary>
    public PublicEntityType PublicEntityType
    {
        get => (PublicEntityType)PublicEntityTypeId;
        set => PublicEntityTypeId = (int)value;
    }
}
