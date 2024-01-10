namespace Nop.Core.Domain.Weixins
{
    /// <summary>
    /// Represents the 微信关注类型
    /// </summary>
    public enum SubscribeSceneType
    {
        /// <summary>
        /// 公众号搜索
        /// </summary>
        ADD_SCENE_SEARCH = 1,
        /// <summary>
        /// 公众号迁移
        /// </summary>
        ADD_SCENE_ACCOUNT_MIGRATION = 2,
        /// <summary>
        /// 名片分享
        /// </summary>
        ADD_SCENE_PROFILE_CARD = 3,
        /// <summary>
        /// 扫描二维码
        /// </summary>
        ADD_SCENE_QR_CODE = 4,
        /// <summary>
        /// 图文页内名称点击
        /// </summary>
        ADD_SCENE_PROFILE_LINK = 5,
        /// <summary>
        /// 图文页右上角菜单
        /// </summary>
        ADD_SCENE_PROFILE_ITEM = 6,
        /// <summary>
        /// 支付后关注
        /// </summary>
        ADD_SCENE_PAID = 7,
        /// <summary>
        /// 微信广告
        /// </summary>
        ADD_SCENE_WECHAT_ADVERTISEMENT = 8,
        /// <summary>
        /// 他人转载
        /// </summary>
        ADD_SCENE_REPRINT = 9,
        /// <summary>
        /// 视频号直播
        /// </summary>
        ADD_SCENE_LIVESTREAM = 10,
        /// <summary>
        /// 视频号
        /// </summary>
        ADD_SCENE_CHANNELS = 11,
        /// <summary>
        /// 其他
        /// </summary>
        ADD_SCENE_OTHERS = 99
    }
}
