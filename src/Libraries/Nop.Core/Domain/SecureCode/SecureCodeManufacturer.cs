using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 生产厂家信息
    /// </summary>
    public partial class SecureCodeManufacturer : BaseEntity, ISoftDeletedEntity
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
        public string MobilePhone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 官方二维码
        /// </summary>
        public string QrCodeUrl { get; set; }

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
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }
    }
}
