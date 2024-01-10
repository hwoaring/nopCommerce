namespace Nop.Core.Domain.Shares
{
    /// <summary>
    /// 广告阅读详情统计
    /// SharePageRecords中查询：实体页面id+页面类型+分享人+在统计分享时间内
    /// 情况：1=缓存有记录直接调用id，2=查找数据库有记录存入缓存并调用，3=无记录创建并存入缓存。
    /// </summary>
    public partial class SharePageViews : BaseEntity
    {
        /// <summary>
        /// 用户分享页面ID（调用分享记录ID，才能判断是否有人分享，并记录到阅读记录中）
        /// </summary>
        public int SharePageRecordsId { get; set; }

        /// <summary>
        /// 阅读人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 是否已统计汇总
        /// </summary>
        public bool Balanced { get; set; }
    }
}