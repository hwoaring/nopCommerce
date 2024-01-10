namespace Nop.Core.Domain.FriendCircles
{
    /// <summary>
    /// 朋友圈隐私策略
    /// </summary>
    public enum FriendPrivacyType
    {
        /// <summary>
        /// 首页
        /// </summary>
        Public = 0,

        /// <summary>
        /// 产品页
        /// </summary>
        Personal = 1,

        /// <summary>
        /// 产品分类页
        /// </summary>
        Friend = 2,
    }
}
