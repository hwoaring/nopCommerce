using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 店铺的会员卡等级设置
/// </summary>
public partial class VendorStoreMemberLevelSetting : BaseEntity
{
    /// <summary>
    /// VendorStore ID
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 等级值
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 会员等级（卡片）名称，对外显示
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 会员等级（卡片）描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 会员等级（卡片）权益内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 系统名称
    /// </summary>
    public string SystemName { get; set; }

    /// <summary>
    /// 会员卡片头部背景图
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// Logo图标ID
    /// </summary>
    public int LogoPictureId { get; set; }

    /// <summary>
    /// 升级要求：本店消费金额满
    /// </summary>
    public decimal? ConsumeAmounts { get; set; }

    /// <summary>
    /// 升级要求：本店邀请/分享人数满
    /// </summary>
    public int InviteCounts { get; set; }

    /// <summary>
    /// 升级要求：购买产品（开启后，至少一个升级条件不为0）
    /// </summary>
    public int PurchasedProductId { get; set; }

    /// <summary>
    /// 升级要求：充值金额（开启后，至少一个升级条件不为0）
    /// </summary>
    public decimal RechargeAmount { get; set; }

    /// <summary>
    /// 升级要求：升级经验值
    /// </summary>
    public int UpgradePoints { get; set; }

    /// <summary>
    /// 开启升级要求：总消费必须（筛选条件为：and且）
    /// </summary>
    public bool ConsumeNecessary { get; set; }

    /// <summary>
    /// 开启升级要求：要求人数必须（筛选条件为：and且）
    /// </summary>
    public bool InviteNecessary { get; set; }

    /// <summary>
    /// 开启升级要求：购买产品必须（筛选条件为：and且）
    /// </summary>
    public bool PurchasedProductNecessary { get; set; }

    /// <summary>
    /// 开启升级要求：充值必须（筛选条件为：and且）
    /// </summary>
    public bool RechargeAmountNecessary { get; set; }

    /// <summary>
    /// 开启升级要求：积分数量必须（筛选条件为：and且）
    /// </summary>
    public bool PointNecessary { get; set; }

    /// <summary>
    /// 免费邮寄
    /// </summary>
    public bool FreeShipping { get; set; }

    /// <summary>
    /// 自动升级
    /// </summary>
    public bool AutoUpdate { get; set; }

    /// <summary>
    /// 启用
    /// </summary>
    public bool Actived { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }
}