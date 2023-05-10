using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 区域销售代表（主要根据扫码区域提供不同联系电话）
    /// </summary>
    public partial class SecureCodeRegionSeller : BaseEntity
    {
        /// <summary>
        /// 销售公司ID
        /// </summary>
        public int SecureCodeSellerId { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 代理区域代码，以逗号分开
        /// </summary>
        public string RegionCodes { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 代理类型：代理，门市，个人渠道
        /// </summary>
        public int SecureCodeRegionTypeId { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 激活
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 对应的用户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CreaterId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatDateUtc { get; set; }
    }
}
