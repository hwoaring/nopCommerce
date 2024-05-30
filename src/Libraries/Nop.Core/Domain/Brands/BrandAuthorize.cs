namespace Nop.Core.Domain.Brands;

/// <summary>
/// 商标品牌授权
/// </summary>
public partial class BrandAuthorize : BaseEntity
{
    /// <summary>
    /// 店铺Id
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 商标ID
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// 授权文件图片ID
    /// </summary>
    public int AuthorizePictureId { get; set; }

    /// <summary>
    /// 是否授权
    /// </summary>
    public bool Authorized { get; set; }

    /// <summary>
    /// 授权通过时间
    /// </summary>
    public DateTime? AuthorizeDateUtc { get; set; }

    /// <summary>
    /// 授权过期时间
    /// </summary>
    public DateTime ExpireDateUtc { get; set; }
}