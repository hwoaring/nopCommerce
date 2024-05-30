using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 产品订单备注标签，如菜单设置标签可选项为：少盐，少辣等订单多选项
/// </summary>
public partial class ProductOrderNotice : BaseEntity, ILocalizedEntity
{
    /// <summary>
    /// 标签名称
    /// </summary>
    public string Name { get; set; }
}