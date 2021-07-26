namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents a 回复的类型
    /// </summary>
    public enum AutoReplyType : byte
    {
        /// <summary>
        /// 文本
        /// </summary>
        Text = 1,
        /// <summary>
        /// 图片
        /// </summary>
        Img = 2,
        /// <summary>
        /// 语音
        /// </summary>
        Voice = 3,
        /// <summary>
        /// 视频
        /// </summary>
        Video = 4,
        /// <summary>
        /// 关键词自动回复则还多了图文消息
        /// </summary>
        News = 5
    }
}
