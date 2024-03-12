using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Weixins;

/// <summary>
/// 消息回复内容设置
/// </summary>
public partial class WeixinMessageResponse : BaseEntity
{
    /// <summary>
    /// 备用（区分微信平台）
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 媒体文件ID
    /// </summary>
    public string MediaId { get; set; }

    /// <summary>
    /// 保存图片在系统中的ID
    /// </summary>
    public int MediaPictureId { get; set; }

    /// <summary>
    /// 保存视频、音乐在系统中的ID
    /// </summary>
    public int MediaVideoId { get; set; }

    /// <summary>
    /// 音乐链接
    /// </summary>
    public string MusicURL { get; set; }

    /// <summary>
    /// 高质量音乐链接
    /// </summary>
    public string HQMusicUrl { get; set; }

    /// <summary>
    /// 缩略图的媒体id
    /// </summary>
    public string ThumbMediaId { get; set; }

    /// <summary>
    /// 保存图片在系统中的ID
    /// </summary>
    public int ThumbMediaPictureId { get; set; }

    /// <summary>
    /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
    /// </summary>
    public string PicUrl { get; set; }

    /// <summary>
    /// 保存图片在系统中的ID
    /// </summary>
    public int PicUrlPictureId { get; set; }

    /// <summary>
    /// 图片链接（备用，为小图准备），支持JPG、PNG格式，小图200*200
    /// </summary>
    public string ThumbPicUrl { get; set; }

    /// <summary>
    /// 保存图片在系统中的ID
    /// </summary>
    public int ThumbPicUrlPictureId { get; set; }

    /// <summary>
    /// 点击图文消息跳转链接
    /// </summary>
    public string Url { get; set; }
}
