using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 产品服务标签，特色服务标签
/// 如：破损包退换服务，7天报价等
/// </summary>
public partial class ProductServiceTag : BaseEntity, ILocalizedEntity
{
    /// <summary>
    /// 服务标签名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 标签如果有扩展链接，设置链接文字
    /// </summary>
    public string UrlText { get; set; }

    /// <summary>
    /// 扩展链接
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; }
}