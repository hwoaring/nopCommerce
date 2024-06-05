using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 代理商库房产品品类，自己库房的产品品类、名称
/// </summary>
public partial class VendorStockProduct : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 代理ID
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 平台销售的产品ID（非必须绑定，如果未绑定，订单销售的产品不能查询到Vendor的库存量，影响Vendor发货功能）
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 防伪产品详细ID（可以不绑定）
    /// </summary>
    public int AntiFakeProductId { get; set; }

    /// <summary>
    /// 产品图片ID
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 每箱最小单位数量
    /// </summary>
    public int QuantityPerBox { get; set; }

    /// <summary>
    /// 每个单瓶的数值（如500ml，填写500）
    /// </summary>
    public decimal UnitValue { get; set; }

    /// <summary>
    /// 单瓶单位，如：500ml，填写ml
    /// </summary>
    public string UnitName { get; set; }

    /// <summary>
    /// 产品名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 产品体积：长
    /// </summary>
    public decimal Length { get; set; }

    /// <summary>
    /// 产品体积：宽
    /// </summary>
    public decimal Width { get; set; }

    /// <summary>
    /// 产品体积：高
    /// </summary>
    public decimal Height { get; set; }

    /// <summary>
    /// 重量
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// 是否可以按最小单位出库（否则只能按整件出库）
    /// </summary>
    public bool OutboundByUnit { get; set; }

    /// <summary>
    /// 是否激活（个人控制）
    /// </summary>
    public bool Actived { get; set; }

    /// <summary>
    /// 是否展示（系统控制）
    /// </summary>
    public bool Displayed { get; set; }

    /// <summary>
    /// 允许自己添加入库
    /// </summary>
    public bool EnableSelfInbound { get; set; }

    /// <summary>
    /// 允许自己添加出库
    /// </summary>
    public bool EnableSelfOutbound { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
