using Nop.Core.Configuration;

namespace Nop.Core.Domain.Topics
{
    /// <summary>
    /// Media settings
    /// </summary>
    public class TopicSettings : ISettings
    {
        /// <summary>
        /// 是否允许分享（分类总控）
        /// </summary>
        public bool AllowSharing { get; set; }
    }
}