using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// Represents a Vendor 管理区域（访客没有对应Vendor时,采取默认区域查询）
    /// 查询时自动判断传入参数是0-9数字使用Code查询，否则使用中文查询
    /// </summary>
    public partial class VendorRegion : BaseEntity
    {
        /// <summary>
        /// Vendor Id
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 区域查询关键词（省-Api返回Code时使用）
        /// </summary>
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 区域查询关键词（Api返回中文时使用）
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 区域查询关键词（市-Api返回Code时使用）
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// 区域查询关键词（Api返回中文时使用）
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 区域查询关键词（区/县-Api返回Code时使用）
        /// </summary>
        public string CountyCode { get; set; }

        /// <summary>
        /// 区域查询关键词（Api返回中文时使用）
        /// </summary>
        public string CountyName { get; set; }

        /// <summary>
        /// 时间段规则值（0-23小时段，以逗号分割：0,1,2,3,4,7,8）
        /// </summary>
        public string TimeRuleValue { get; set; }

        /// <summary>
        /// 启用时间段规则（时间段内才有效）
        /// </summary>
        public bool TimeRuleEnable { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Active { get; set; }

    }
}
