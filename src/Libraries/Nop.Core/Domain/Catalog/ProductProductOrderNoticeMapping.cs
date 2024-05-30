namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 产品备注选项（下单时多选）
/// </summary>
public partial class ProductProductOrderNoticeMapping : BaseEntity
{
    /// <summary>
    /// 产品ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 备注名称ID
    /// </summary>
    public int ProductOrderNoticeId { get; set; }
}