using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 代理商店铺自定义分类
/// </summary>
public partial class VendorStoreCategory : BaseEntity, ISlugSupported, ISoftDeletedEntity
{
    /// <summary>
    /// VendorStore id
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 对外展示统一加密id（URL参数）
    /// </summary>
    public long UnifiedId { get; set; }

    /// <summary>
    /// 分类名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 店铺描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 模板ID
    /// </summary>
    public int? CategoryTemplateId { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 关键词
    /// </summary>
    public string MetaKeywords { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string MetaTitle { get; set; }

    /// <summary>
    /// 父级ID
    /// </summary>
    public int ParentCategoryId { get; set; }

    /// <summary>
    /// 图片id
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 限制到store
    /// </summary>
    public bool LimitedToStores { get; set; }

    /// <summary>
    /// 审核通过
    /// </summary>
    public bool Approved { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// 创建日期
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// 修改日期
    /// </summary>
    public DateTime UpdatedOnUtc { get; set; }

    /// <summary>
    /// 价格筛选
    /// </summary>
    public bool PriceRangeFiltering { get; set; }

    /// <summary>
    /// Gets or sets the "from" price
    /// </summary>
    public decimal PriceFrom { get; set; }

    /// <summary>
    /// Gets or sets the "to" price
    /// </summary>
    public decimal PriceTo { get; set; }



}
