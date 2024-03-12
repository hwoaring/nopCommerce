using Nop.Core.Domain.Common;
using Nop.Core.Domain.Publics;

namespace Nop.Core.Domain.Shares
{
    /// <summary>
    /// 用户分享页记录
    /// </summary>
    public partial class SharePageRecords : BaseEntity, ISoftDeletedEntity
    {

        /// <summary>
        /// 实例ID
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// 实例页面类型ID
        /// </summary>
        public int PublicEntityTypeId { get; set; }

        /// <summary>
        /// 分享码（备用：用于减少URL参数）
        /// </summary>
        public int SharePageCode { get; set; }

        /// <summary>
        /// 分享链接（各种需要的参数组合成的url）
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 生成可以关注公众号的临时二维码ID（本系统的ID）
        /// </summary>
        public int QrCodeTemporaryId { get; set; }

        /// <summary>
        /// 分享用户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 使用的分享海报ID（可为空：统计海报共享人，分析海报引用数量和阅读效果）
        /// </summary>
        public int SharePictureId { get; set; }

        /// <summary>
        /// 本条阅读总数汇总（需要本阅读统计日期结束后才能汇总）
        /// </summary>
        public int ViewsSummary { get; set; }

        /// <summary>
        /// 系统广告费结算流水号（本系统内，并设置结算时间BalanceDateUtc）
        /// </summary>
        public long SerialNumber { get; set; }

        /// <summary>
        /// 开启线下广告分享（开启后，本条记录没有统计结束时间，宣传单印刷后可长时间使用）
        /// </summary>
        public bool OfflineShare { get; set; }

        /// <summary>
        /// 是否无效
        /// </summary>
        public bool Invalid { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 结算日期（结算后可以删除访客对应阅读记录
        /// </summary>
        public DateTime? BalanceDateUtc { get; set; }

        /// <summary>
        /// 创建日期（用创建日期+ShareCycleDays判断是否需要新建记录）
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// 页面类型
        /// </summary>
        public PublicEntityType PublicEntityType
        {
            get => (PublicEntityType)PublicEntityTypeId;
            set => PublicEntityTypeId = (int)value;
        }

    }
}
