namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 小码扫码记录，主要记录扫码位置
    /// </summary>
    public partial class SecureCodeInnerRecord : BaseEntity
    {
        /// <summary>
        /// 对应的小码ID
        /// </summary>
        public int SecureCodeRecordId { get; set; }

        /// <summary>
        /// 扫码用户ID
        /// </summary>
        public int CustomerId { get; set; }

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
        /// 创建时间
        /// </summary>
        public DateTime CreatedUtc { get; set; }

    }
}
