namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an WxKeywordAutoreplyReply
    /// </summary>
    public partial class WxKeywordAutoreplyReply : BaseEntity
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
        /// 【AutoreplyType】自动回复的类型。关注后自动回复和消息自动回复的类型仅支持文本（text）、图片（img）、语音（voice）、视频（video），关键词自动回复则还多了图文消息（news）
        /// </summary>
        public byte AutoreplyTypeId { get; set; }
        /// <summary>
        /// 匹配方式
        /// </summary>
        public AutoReplyType AutoReplyType
        {
            get => (AutoReplyType)AutoreplyTypeId;
            set => AutoreplyTypeId = (byte)value;
        }
        /// <summary>
        /// 对于文本类型，content是文本内容，对于图文、图片、语音、视频类型，content是mediaID
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 【WAutoreplyNewsInfo】Id列表，以逗号分开，多条图文，首个Id为显示封面
        /// </summary>
        public string WxAutoreplyNewsInfoIds { get; set; }

    }
}
