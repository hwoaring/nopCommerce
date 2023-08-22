namespace Nop.Core.Domain.Memberships
{
    /// <summary>
    /// 收支类型
    /// </summary>
    public enum IncomeExpendTypeId
    {
        /// <summary>
        /// 通过签到方式
        /// </summary>
        SignIn = 1,

        /// <summary>
        /// 通过充值方式
        /// </summary>
        Recharge = 2,

        /// <summary>
        /// 通过订单收入或支出
        /// </summary>
        Order = 3,

        /// <summary>
        /// 通过兑换方式
        /// </summary>
        Exchange = 4,

        /// <summary>
        /// 关注
        /// </summary>
        Follow = 5,

        /// <summary>
        /// 系统奖励/赠送
        /// </summary>
        SystemReward = 6,

        /// <summary>
        /// 供应商赠送
        /// </summary>
        VendorReward = 7,

        /// <summary>
        /// 好友赠送
        /// </summary>
        FriendGift = 8,

        /// <summary>
        /// 抽奖
        /// </summary>
        Raffle = 9,

        /// <summary>
        /// 红包
        /// </summary>
        RedPacket =10,


        /// <summary>
        /// 退款
        /// </summary>
        Refund = 52,

        /// <summary>
        /// 退货
        /// </summary>
        SendBack = 54,

        /// <summary>
        /// 取消关注
        /// </summary>
        UnFollow = 55,

    }
}
