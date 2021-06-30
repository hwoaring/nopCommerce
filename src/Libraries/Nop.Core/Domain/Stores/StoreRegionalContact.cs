namespace Nop.Core.Domain.Stores
{
    /// <summary>
    /// Represents a Store Regional Contact record（启用区域联系人）
    /// </summary>
    public partial class StoreRegionalContact : BaseEntity
    {
        public int StoreId { get; set; }

        /// <summary>
        /// 区域关键词（地图api返回的区域信息查询使用）
        /// </summary>
        public string RegionalKey { get; set; }

        /// <summary>
        /// 区域代码，以逗号分开
        /// </summary>
        public string RegionalAreaCode { get; set; }

        /// <summary>
        /// 区域等级（1=省级，2=市级，3=县级，4=区域级别）
        /// </summary>
        public int RegionalLevel { get; set; }

        /// <summary>
        /// 绑定到Vendor（与Supplier二选一）
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 绑定到Supplier（与Vendor二选一）
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 公司门头图
        /// </summary>
        public string CompanyImage { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string CompanyPhoneNumber { get; set; }

        /// <summary>
        /// 区域门店地图链接
        /// </summary>
        public string MapURL { get; set; }

        /// <summary>
        /// 跳转链接
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 是否跳转到区域对应的域名
        /// </summary>
        public bool IsRedirectUrl { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Published { get; set; }

    }
}
