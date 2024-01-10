namespace Nop.Core.Domain.Weixins
{
    /// <summary>
    /// Represents the 自定义场景类型，用于二维码前缀，用于在临时二维码生成时作为类别前缀
    /// </summary>
    public enum CustomSceneType
    {
        /// <summary>
        /// 广告
        /// </summary>
        ADVER = 1,
        /// <summary>
        /// 验证码
        /// </summary>
        VERIFY = 2,
        /// <summary>
        /// 命令行
        /// </summary>
        CMD = 3,
        /// <summary>
        /// 登录
        /// </summary>
        LOGIN = 4,
        /// <summary>
        /// 绑定
        /// </summary>
        BIND = 5,
        /// <summary>
        /// 投票
        /// </summary>
        VOTE = 6,
        /// <summary>
        /// 个人名片
        /// </summary>
        CARD = 7,
        /// <summary>
        /// 场所码
        /// </summary>
        PLACE = 8,
        /// <summary>
        /// 其他
        /// </summary>
        OTHER = 99
    }
}
