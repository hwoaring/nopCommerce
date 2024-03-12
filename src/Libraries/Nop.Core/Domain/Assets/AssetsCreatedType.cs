namespace Nop.Core.Domain.Assets;

/// <summary>
/// 创建方式
/// </summary>
public enum AssetsCreatedType
{
    ///========================
    ///增加类：
    ///充值，购买，卡券结算，佣金结算，分享活动，兑换活动
    ///签到，关注
    ///系统奖励/赠送
    ///供应商赠送
    ///好友赠送
    ///抽奖，红包
    ///========================

    ///========================
    ///减少类：
    ///提现，消费，退款，退货，取消关注
    ///========================

    /// <summary>
    /// 充值
    /// </summary>
    Recharge = 11,

    /// <summary>
    /// 提现
    /// </summary>
    Withdrawal = 12,
    /// <summary>
    /// 结算
    /// </summary>
    Balance = 13,
    /// <summary>
    /// 消费
    /// </summary>
    Consume = 14,

    /// <summary>
    /// 退款
    /// </summary>
    Refund = 21,
    /// <summary>
    /// 退货
    /// </summary>
    SendBack = 22,

    /// <summary>
    /// 注册
    /// </summary>
    SignIn = 31,
    /// <summary>
    /// 分享
    /// </summary>
    Share = 32,
    /// <summary>
    /// 抽奖
    /// </summary>
    Raffle = 33,
    /// <summary>
    /// 兑换
    /// </summary>
    Exchange = 34,

    /// <summary>
    /// 红包
    /// </summary>
    RedPacket = 35,

    /// <summary>
    /// 系统赠送
    /// </summary>
    SystemReward = 41,
    /// <summary>
    /// 代理赠送
    /// </summary>
    VendorReward = 42,
    /// <summary>
    /// 好友赠送
    /// </summary>
    FriendReward = 43,

    /// <summary>
    /// 关注
    /// </summary>
    Subscribe = 51,
    /// <summary>
    /// 取消关注
    /// </summary>
    UnSubscribe = 52,

}