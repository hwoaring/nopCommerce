using Humanizer;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 防伪码奖励设置
/// </summary>
public partial class AntiFakeRewardsConfig : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 所属销售公司ID
    /// </summary>
    public int AntiFakeVendorCompanyId { get; set; }

    /// <summary>
    /// 抽奖活动序列号（随机生成）
    /// </summary>
    public long RewardsSerialNumber { get; set; }

    /// <summary>
    /// 公证处公证书图片
    /// </summary>
    public int NotarialDeedPictureId { get; set; }

    /// <summary>
    /// 销售公司承诺书图片
    /// </summary>
    public int CommitmentPictureId { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 描述（备注，客户不可看）
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 支付页面标题（仅展示在红包支付页面）
    /// 后期可加通配符如：标题{amount}元，支付标题显示为：XXXX3.5元
    /// </summary>
    public string PaymenTitle { get; set; }

    /// <summary>
    /// 支付页面描述
    /// </summary>
    public string PaymenDescription { get; set; }

    /// <summary>
    /// 内容（奖励内，客户可看）
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 限定区域，限定使用区域（填写区划码，以逗号分开）
    /// </summary>
    public string LimitToRegionCode { get; set; }

    /// <summary>
    /// 头部图片ID
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 奖励编码类型
    /// 4=瓶盖内码
    /// 8=密码内包装密码
    /// </summary>
    public int CodeSourceType { get; set; }

    /// <summary>
    /// 奖励类型
    /// 是否现金奖励、否则为奖励产品
    /// </summary>
    public bool CashRewards { get; set; }

    /// <summary>
    /// 领取需要电话号码
    /// </summary>
    public bool NeedPhoneNumber { get; set; }

    /// <summary>
    /// 单个小码奖励总金额（奖励现金）
    /// 或奖励产品总数量（奖励产品）
    /// </summary>
    public decimal RewardAmount { get; set; }

    /// <summary>
    /// 导购奖励金额（只限制是导购才能领取奖励金额1次）
    /// 此处单独设置，在扫码奖励金额之外
    /// 导购不能参与奖品领取，只能领取属于自己的导购奖励
    /// </summary>
    public decimal GuiderAmount { get; set; }

    /// <summary>
    /// 奖励的产品ID（非现金）
    /// </summary>
    public int RewardProductId { get; set; }

    /// <summary>
    /// 小码奖金拆分次数（红包金额或产品数量拆分成多少份）
    /// </summary>
    public int SplitCounts { get; set; }

    /// <summary>
    /// 阶梯阅读数，达到阶梯阅读数后，拆分的红包一个人可以领取达到分享的阶梯次数
    /// 默认情况下，拆分的红包没人只能领取一次，
    /// 设置分享领取数字后，分享阅读数达到设定阶梯值后，可以领取第二次，第三次等
    /// 格式为：0,200,500 ，表示允许领取3次，第二次领取需要分享阅读200次，第三次领取需要阅读数500次。
    /// 这里没有设置第四次阅读数要求，表示不能够领取第四次。
    /// </summary>
    public string TierShareCount { get; set; }

    /// <summary>
    /// 阶梯阅读数统计的文章ID
    /// 阅读数统计时间为该用户首次领取奖金时间的24小时内。
    /// </summary>
    public int ShareNewsItemId { get; set; }

    /// <summary>
    /// 是否以随机方式拆分，否则为均分
    /// </summary>
    public bool SplitByRandom { get; set; }

    /// <summary>
    /// 设置时候账户必须有金额或数量
    /// 现金奖励时：可用奖金余额
    /// 产品奖励时：产品数量
    /// </summary>
    public decimal BalanceAmount { get; set; }

    /// <summary>
    /// 账户余额报警（产品数量）
    /// </summary>
    public decimal WarnBelowAmount { get; set; }

    /// <summary>
    /// 分享奖励是否启用：针对领取了红包的人，再次分享朋友圈阅读享受额外奖励
    /// </summary>
    public bool ShareRewards { get; set; }

    /// <summary>
    /// 分享奖励金额（不可提现）
    /// </summary>
    public decimal ShareRewardsAmount { get; set; }

    /// <summary>
    /// 分享奖励获取要求：点赞数量或者阅读数量要求
    /// </summary>
    public int ShareRewardsRequire { get; set; }

    /// <summary>
    /// 分享奖励获广告图片
    /// </summary>
    public int ShareRewardsPictureId { get; set; }

    /// <summary>
    /// 现金奖励可提现
    /// 可提现：立即提现到微信
    /// 不可提现：奖金设置为消费卡券（现金卡券、产品兑换券，发放到个人的卡券资产中）
    /// </summary>
    public bool EnableWithdrawal { get; set; }

    /// <summary>
    /// 不可提现时：限制购买本品牌所有产品
    /// </summary>
    public bool LimitedToBrand { get; set; }

    /// <summary>
    /// 不可提现时：限制购买本产品
    /// </summary>
    public bool LimitedToProduct { get; set; }

    /// <summary>
    /// 不可提现时：限制使用有效期天数（自领取之日起）
    /// 设置为0=不限制
    /// </summary>
    public int LimitedToDays { get; set; }

    /// <summary>
    /// 关键设置组合的Hash值，避免被恶意修改
    /// </summary>
    public string HashCode { get; set; }

    /// <summary>
    /// 绑定确认时间（确认后不可取消）
    /// </summary>
    public DateTime? ConfirmDateUtc { get; set; }

    /// <summary>
    /// 奖励开始时间
    /// </summary>
    public DateTime? StartDateUtc { get; set; }

    /// <summary>
    /// 奖励结束时间
    /// </summary>
    public DateTime? EndDateUtc { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatDateUtc { get; set; }

    /// <summary>
    /// 系统控制（临时中止或暂停原因）
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// 是否暂停（系统控制）
    /// </summary>
    public bool Suspended { get; set; }

    /// <summary>
    /// 是否激活（系统控制）
    /// </summary>
    public bool Actived { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
