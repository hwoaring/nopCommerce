using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 瓶盖内码验证，代理商/销售商验证数量后可兑换指定的产品
/// </summary>
public partial class AntiFakeExchangeConfig : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 所属销售公司ID
    /// </summary>
    public int AntiFakeVendorCompanyId { get; set; }

    /// <summary>
    /// 活动序列号（随机生成）
    /// </summary>
    public long RewardsSerialNumber { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 描述（备注，客户不可看）
    /// </summary>
    public string Description { get; set; }

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
    /// 兑换需要电话号码
    /// </summary>
    public bool NeedPhoneNumber { get; set; }

    /// <summary>
    /// 瓶盖是否需要回收
    /// </summary>
    public bool NeedCoverRecovery { get; set; }

    /// <summary>
    /// 是否需要登记领取人
    /// </summary>
    public bool NeedReceiveCustomer { get; set; }

    /// <summary>
    /// 需要几个瓶盖或者二维码才能兑换
    /// </summary>
    public int NumberOfCode { get; set; }

    /// <summary>
    /// 奖励产品总数量（奖励产品）
    /// </summary>
    public decimal RewardAmount { get; set; }

    /// <summary>
    /// 奖励数量的单位名称（如：瓶，件）
    /// </summary>
    public string RewardProductUnitName { get; set; }

    /// <summary>
    /// 奖励的产品ID（可用于连接到销售链接）
    /// </summary>
    public int RewardProductId { get; set; }

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
