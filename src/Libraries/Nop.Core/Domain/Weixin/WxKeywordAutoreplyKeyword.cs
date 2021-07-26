namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an WxKeywordAutoreplyKeyword
    /// </summary>
    public partial class WxKeywordAutoreplyKeyword : BaseEntity
    {
        /// <summary>
        /// 站点ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 【AutoReplyModeType】回复模式，reply_all代表全部回复，random_one代表随机回复其中一条
        /// </summary>
        public byte AutoReplyModeTypeId { get; set; }

        /// <summary>
        /// 回复模式
        /// </summary>
        public AutoReplyModeType AutoReplyModeType
        {
            get => (AutoReplyModeType)AutoReplyModeTypeId;
            set => AutoReplyModeTypeId = (byte)value;
        }

        /// <summary>
        /// 匹配方式
        /// </summary>
        public byte MatchModeTypeId { get; set; }
        /// <summary>
        /// 匹配方式
        /// </summary>
        public AutoReplyMatchModeType MatchModeType
        {
            get => (AutoReplyMatchModeType)MatchModeTypeId;
            set => MatchModeTypeId = (byte)value;
        }
        /// <summary>
        /// 默认为0 = text，暂时无其他值
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否展示或发布
        /// </summary>
        public bool Published { get; set; }

    }
}
