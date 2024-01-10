using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 店铺员工绑定：旗下关联的员工权限（用于员工管理，员工才允许核销或操作店铺相关功能）
    /// </summary>
    public partial class VendorStoreCustomerAuthority : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 店铺ID
        /// </summary>
        public int VendorStoreId { get; set; }

        /// <summary>
        /// 员工
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 是否超级管理员（有所有权限）
        /// </summary>
        public bool SuperAdmin { get; set; }

        /// <summary>
        /// 是否允许升级会员卡
        /// </summary>
        public bool UpgradeMemberCard { get; set; }

        /// <summary>
        /// 是否回访员，允许回访操作
        /// </summary>
        public bool ReVisiter { get; set; }

        /// <summary>
        /// 是否仅能查看个人的客户。
        /// </summary>
        public bool ViewPrivateCustomer { get; set; }

        /// <summary>
        /// 是否允许添加员工
        /// </summary>
        public bool AddEmployee { get; set; }

        /// <summary>
        /// 出纳员（转款操作）
        /// </summary>
        public bool Cashier { get; set; }

        /// <summary>
        /// 会计员（记账）
        /// </summary>
        public bool Accounter { get; set; }

        /// <summary>
        /// 开票操作
        /// </summary>
        public bool EnableInvoice { get; set; }

        /// <summary>
        /// 服务员或前台（预定确认，到店确认）
        /// </summary>
        public bool EnableBookingConfirm { get; set; }

        /// <summary>
        /// 前台或服务员（临时添加新预定产品）
        /// </summary>
        public bool EnableAddBookingProduct { get; set; }

        /// <summary>
        /// 收款操作（前台收款操作）
        /// </summary>
        public bool EnableCheckout { get; set; }

        /// <summary>
        /// 数据分析员（查看销售数据和核销数据）
        /// </summary>
        public bool DataAnalyst { get; set; }

        /// <summary>
        /// 核销员（允许核销客人订单）
        /// </summary>
        public bool Verifier { get; set; }

        /// <summary>
        /// 商品码转出功能（用于一物一码信息转移功能）
        /// 仅能转移本店的商品，转移后商品信息显示为购买人信息
        /// 操作：本店人员扫码转出产品，生成二维码，购买人员扫码接收产品，
        /// 系统提示出库成功通知，以便管理员查看
        /// </summary>
        public bool ProductCodeTransfer { get; set; }

        /// <summary>
        /// 产品管理员（操作产品价格和上下线操作）
        /// </summary>
        public bool ProductManager { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// 锁定原因备注
        /// </summary>
        public bool LockRemark { get; set; }
    }
}
