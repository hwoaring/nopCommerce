namespace Nop.Core.Domain.Memberships
{
    /// <summary>
    /// 回访方式
    /// </summary>
    public enum ReVisitType
    {
        None = 0,

        /// <summary>
        /// 线下拜访
        /// </summary>
        Offline = 1,

        /// <summary>
        /// 电话沟通
        /// </summary>
        Telephone = 2,

        /// <summary>
        /// 短信沟通
        /// </summary>
        Message = 3,

        /// <summary>
        /// 微信沟通
        /// </summary>
        WeChat = 4,

        /// <summary>
        /// 邮件沟通
        /// </summary>
        Email = 5,
    }
}
