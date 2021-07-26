using System;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an WxLocation
    /// </summary>
    public partial class WxLocation : BaseEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public decimal Latitude { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public decimal Longitude { get; set; }
        /// <summary>
        /// 地理位置精度
        /// </summary>
        public decimal Precision { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public int CreateTime { get; set; }

    }
}
