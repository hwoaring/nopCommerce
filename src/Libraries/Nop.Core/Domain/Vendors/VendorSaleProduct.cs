namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 分销人员个人销售的产品（表示选择到自己的代理库中，并不表示该产品供应商属于该Vendor）
    /// </summary>
    public partial class VendorSaleProduct : BaseEntity
    {
        /// <summary>
        /// 销售id
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 产品id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 使用自定义价格
        /// </summary>
        public bool UseCustomerPrice { get; set; }

        /// <summary>
        /// 自定义销售价格
        /// </summary>
        public decimal CustomerPrice { get; set; }

        /// <summary>
        /// 上级Vendor备注给客户的结算价格（上级Vendor可见）
        /// </summary>
        public decimal VendorSettlementPrice { get; set; }

        /// <summary>
        /// 系统给客户备注的结算价格（仅系统可见）
        /// </summary>
        public decimal SystemSettlementPrice { get; set; }

        /// <summary>
        /// 自有库存（只有自己有库存的才能发货，才能在防伪二维码销售联系中显示电话）
        /// 有无货，由上级代理商设置，设置有货后，表示为代理商。
        /// </summary>
        public int StockNumber { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 个人推荐
        /// </summary>
        public bool Recommended { get; set; }

        /// <summary>
        /// 热销
        /// </summary>
        public bool HotSell { get; set; }

        /// <summary>
        /// 是否品牌导购（品牌导购可以获得单独的导购奖励）
        /// 奖励分为两个，一个有上级供货商提供，一个由厂家提供。
        /// 奖励独立设置。
        /// </summary>
        public bool BrandSales { get; set; }

        /// <summary>
        /// 系统控制：是否必须展示线上下单
        /// </summary>
        public bool DefaultOrderOnline { get; set; }

        /// <summary>
        /// 个人控制：是否允许在线下单（不在线下单，则只能通过联系人购买）
        /// </summary>
        public bool EnableOrderOnline { get; set; }

        /// <summary>
        /// 销售商、代理商自己控制是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 平台控制是否通过审核
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// 平台控制是否锁定，默认为不锁定（系统控制，不允许分销或销售本产品）
        /// </summary>
        public bool Locked { get; set; }
    }
}
