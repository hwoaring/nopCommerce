using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Shares;

/// <summary>
/// 分享页多广告图（海报图，广告圈图片库）
/// </summary>
public partial class SharePicture : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// StoreId
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 作者ID（用于给作者奖励，可为空）
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 是否有默认绑定品牌ID
    /// </summary>
    public int DefaultBrandId { get; set; }

    /// <summary>
    /// 是否有默认绑定产品ID
    /// </summary>
    public int DefaultProductId { get; set; }

    /// <summary>
    /// 图片ID
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 高清图片下载地址
    /// </summary>
    public int? DownloadId { get; set; }

    /// <summary>
    /// 使用第三方下载地址
    /// </summary>
    public bool UseDownloadUrl { get; set; }

    /// <summary>
    /// 高清下载路径（设置外部下载路径）
    /// </summary>
    public int DownloadUrl { get; set; }

    /// <summary>
    /// 图片名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 推广口号
    /// </summary>
    public string Slogan { get; set; }

    /// <summary>
    /// 图片简介
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 图片标签，以逗号分开
    /// </summary>
    public string Tags { get; set; }

    /// <summary>
    /// 图片对应的广告文案
    /// </summary>
    public string AdvertText { get; set; }

    /// <summary>
    /// 广告图自动生成二维码位置（1-9对应左上-右下）
    /// </summary>
    public int QrCodePosition { get; set; }

    /// <summary>
    /// 广告图二维码大小
    /// </summary>
    public int QrCodeSize { get; set; }

    /// <summary>
    /// 广告图位置偏移相对位置X偏移量
    /// </summary>
    public int QrCodeXOffset { get; set; }

    /// <summary>
    /// 广告图位置偏移相对位置Y偏移量
    /// </summary>
    public int QrCodeYOffset { get; set; }

    /// <summary>
    /// 广告图扫码提示文字大小
    /// </summary>
    public int QrCodeTextSize { get; set; }

    /// <summary>
    /// 广告图扫码提示文字
    /// </summary>
    public string QrCodeText { get; set; }

    /// <summary>
    /// 生成需要关注公众号的二维码（0=生成链接形式二维码）
    /// </summary>
    public bool SubscribeQrCode { get; set; }

    /// <summary>
    /// 审核通过
    /// </summary>
    public bool Approved { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatOnUtc { get; set; }

}
