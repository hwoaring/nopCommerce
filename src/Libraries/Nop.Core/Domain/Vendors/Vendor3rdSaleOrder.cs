using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 第三方平台分销销售的订单申请（京东，淘宝，抖音等平台），通过三方平台的交易号申请
    /// 三方平台的分销功能，成交后通过三方平台的交易号核对
    /// 后期看是否有对应平台的分销接口数据
    /// </summary>
    public partial class Vendor3rdSaleOrder : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 佣金申请信息提交人ID
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 第三方平台类型ID，京东，淘宝，抖音等
        /// </summary>
        public int Product3rdSalePlatformId { get; set; }

        /// <summary>
        /// 第三方平台的交易号
        /// </summary>
        public string OrderSerialNumber { get; set; }

        /// <summary>
        /// 订单处理状态
        /// </summary>
        public int OrderStatusId { get; set; }

        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal CommissionAmount { get; set; }

        /// <summary>
        /// 扣除金额，平台扣除金额（实际支付需要扣除平台费用）
        /// </summary>
        public decimal DeductAmount { get; set; }

        /// <summary>
        /// 佣金Commission结算到个人现金资产结算ID
        /// </summary>
        public int AssetsCashsHistoryId { get; set; }

        /// <summary>
        /// 是否已结算
        /// </summary>
        public bool Balanced { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? UpdatedOnUtc { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
