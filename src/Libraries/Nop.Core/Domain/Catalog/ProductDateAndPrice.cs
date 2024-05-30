
namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 按日期定价
/// </summary>
public partial class ProductDateAndPrice : BaseEntity
{
    /// <summary>
    /// 产品ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 日期价格表(Json格式或XML格式)
    /// 格式：
    /// {date:"2024-01-01",prices:[{id:0,adjust:-3.5,stock:5}]"}
    /// 中文注释：{date:"日期",prices:[{id:产品属性ProductAttributeValueID（0表示没有设置属性价格）,adjust:价格调整值负数为减少量,stock:库存量}]"}
    /// {date:"2024-01-01",prices:[{id:37,adjust:3.5,stock:5},{id:38,adjust:3.5,stock:5}]"}
    /// 中文注释：id表示对应的产品属性ProductAttributeValueId，adjust表示价格调整量，stock表示库存量
    /// </summary>
    public string DatePricesXml { get; set; }

}
