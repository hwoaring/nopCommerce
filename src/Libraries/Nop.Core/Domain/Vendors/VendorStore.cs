using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 销售商商铺（有商铺的使用）
    /// </summary>
    public partial class VendorStore : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 销售商ID
        /// </summary>
        public string VendorId { get; set; }

        /// <summary>
        /// 供应商编号（8位）-会员卡前8位使用到供应商编号
        /// </summary>
        public int VendorStoreNumber { get; set; }

        /// <summary>
        /// 相关店铺ID（针对一个城市自己有多个门店的关联展示）
        /// </summary>
        public string RelatedStoreIds { get; set; }

        /// <summary>
        /// 供应商店铺域名
        /// </summary>
        public string DomainUrl { get; set; }

        /// <summary>
        /// 商店名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商店Slogan
        /// </summary>
        public string Slogan { get; set; }

        /// <summary>
        /// 商店地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 商店联系电话
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 个人二维码
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// 店铺描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 店铺内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 营业执照公司名称
        /// </summary>
        public string BusinessName { get; set; }

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
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区/县
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 微信分享标题
        /// </summary>
        public string ShareTitle { get; set; }

        /// <summary>
        /// 微信分享描述
        /// </summary>
        public string ShareDesc { get; set; }

        /// <summary>
        /// 微信分享链接
        /// </summary>
        public string ShareLink { get; set; }

        /// <summary>
        /// 微信分享图片
        /// </summary>
        public string ShareImgUrl { get; set; }

        /// <summary>
        /// 店铺类型
        /// </summary>
        public int StoreTypeId { get; set; }

        /// <summary>
        /// 合作模式
        /// </summary>
        public int CooperationTypeId { get; set; }

        /// <summary>
        /// 锁定
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// 审核通过
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }
    }
}
