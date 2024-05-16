using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 防伪码关联（瓶盖码，防伪码，瓶子码，三码关联，增加防伪）
/// 用于加强防伪或用在高价收藏兑换中
/// </summary>
public partial class AntiFakeCodeRelateMapping : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 防伪小码ID
    /// </summary>
    public long ItemCode { get; set; }

    /// <summary>
    /// 瓶盖外码ID
    /// </summary>
    public long CoverCode { get; set; }

    /// <summary>
    /// 瓶子码ID
    /// </summary>
    public long BottleCode { get; set; }

    /// <summary>
    /// 盒子防伪码（这里不是外箱防伪码，此处未单独的包装盒子防伪码）
    /// 盒子印刷码或者贴在盒子上的防伪码
    /// </summary>
    public long BoxCode { get; set; }

    /// <summary>
    /// 防伪小码图片（贴在哪个位置的照片）
    /// </summary>
    public int ItemCodePictureId { get; set; }

    /// <summary>
    /// 瓶子码图片（印刷贴在哪个位置的照片）
    /// </summary>
    public int BottleCodePictureId { get; set; }

    /// <summary>
    /// 盒子防伪码（这里不是外箱防伪码，此处未单独的包装盒子防伪码）
    /// 盒子印刷码或者贴在盒子上的防伪码
    /// </summary>
    public int BoxCodePictureId { get; set; }

    /// <summary>
    /// 当前拥有人ID
    /// </summary>
    public int CurrentCustomerId { get; set; }

    /// <summary>
    /// 上一个拥有人ID
    /// </summary>
    public int PreviousCustomerId { get; set; }

    /// <summary>
    /// 是否以及消费
    /// </summary>
    public bool Consumed { get; set; }

    /// <summary>
    /// 价格（备用）
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// 扩展防伪信息（如：后期自己加上去的防伪信息）
    /// </summary>
    public string ExtendCode { get; set; }

    /// <summary>
    /// 是否删除
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

}
