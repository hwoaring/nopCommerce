namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 商店图片
/// </summary>
public partial class VendorStorePicture : BaseEntity
{
    /// <summary>
    /// 商店id
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 图片id
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 图片描述
    /// </summary>
    public string Discription { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }
}
