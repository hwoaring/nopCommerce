using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 销售公司/贴牌公司信息
    /// </summary>
    public partial class SecureCodeSeller : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 服务电话
        /// </summary>
        public string ServicePhoneNumber { get; set; }

        /// <summary>
        /// 负责人电话
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 官方二维码
        /// </summary>
        public string QrCodeUrl { get; set; }

        /// <summary>
        /// 官方商城地址
        /// </summary>
        public string ShoppingUrl { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        public string BusinessLicense { get; set; }

        /// <summary>
        /// 营业执照号码
        /// </summary>
        public string BusinessCode { get; set; }

        /// <summary>
        /// 营业执照过期时间
        /// </summary>
        public DateTime? BusinessLicenseUtc { get; set; }

        /// <summary>
        /// 生产许可证
        /// </summary>
        public string ProductionLicense { get; set; }

        /// <summary>
        /// 生产许可证号码
        /// </summary>
        public string ProductionCode { get; set; }

        /// <summary>
        /// 生产许可证过期时间
        /// </summary>
        public DateTime? ProductionLicenseUtc { get; set; }

        /// <summary>
        /// 食品经营许可证
        /// </summary>
        public string FoodLicense { get; set; }

        /// <summary>
        /// 食品经营许可证号码
        /// </summary>
        public string FoodCode { get; set; }

        /// <summary>
        /// 食品经营许可证过期时间
        /// </summary>
        public DateTime? FoodLicenseUtc { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
  
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Vip等级
        /// </summary>
        public int VipLevel { get; set; }

        /// <summary>
        /// 显示公司名称
        /// </summary>
        public bool ShowName { get; set; }

        /// <summary>
        /// 显示服务电话
        /// </summary>
        public bool ShowServicePhone { get; set; }

        /// <summary>
        /// 显示地址
        /// </summary>
        public bool ShowAddress { get; set; }

        /// <summary>
        /// 显示二维码
        /// </summary>
        public bool ShowQrCode { get; set; }

        /// <summary>
        /// 显示商城
        /// </summary>
        public bool ShowShopping { get; set; }

        /// <summary>
        /// 显示图片
        /// </summary>
        public bool ShowImage { get; set; }

        /// <summary>
        /// 显示证件
        /// </summary>
        public bool ShowLicense { get; set; }

        /// <summary>
        /// 开启位置记录
        /// </summary>
        public bool EnableLocation { get; set; }

        /// <summary>
        /// 开启区域代理联系信息
        /// </summary>
        public bool EnableRegional { get; set; }

        /// <summary>
        /// 开启跨区域预警
        /// </summary>
        public bool EnableWarning { get; set; }

        /// <summary>
        /// 过期时间（用于公司数据基础服务过期时间）
        /// </summary>
        public DateTime? ExpirationDateUtc { get; set; }

        /// <summary>
        /// 大码最大记录条数
        /// </summary>
        public int OuterRecords { get; set; }

        /// <summary>
        /// 小码位置最大记录条数
        /// </summary>
        public int InnerRecords { get; set; }

        /// <summary>
        /// 激活
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatDateUtc { get; set; }
    }
}
