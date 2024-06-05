using Nop.Core.Domain.Common;
using Nop.Core.Domain.Publics;

namespace Nop.Core.Domain.Shares;

/// <summary>
/// 用户分享页记录
/// </summary>
public partial class SharePageRecords : BaseEntity
{
    /// <summary>
    /// 分享用户ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 实例ID
    /// </summary>
    public int EntityId { get; set; }

    /// <summary>
    /// 实例页面类型ID
    /// </summary>
    public int PublicEntityTypeId { get; set; }

    /// <summary>
    /// 分享码（备用：用于减少URL参数）
    /// </summary>
    public int SharePageCode { get; set; }

    /// <summary>
    /// 分享链接（各种需要的参数组合成的url）
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 生成可以关注公众号的临时二维码ID（本系统的ID）
    /// </summary>
    public int QrCodeTemporaryId { get; set; }

    /// <summary>
    /// 使用的分享海报ID（可为空：统计海报共享人，分析海报引用数量和阅读效果）
    /// </summary>
    public int SharePictureId { get; set; }

    /// <summary>
    /// 分享页用户单独设置的场景ID
    /// </summary>
    public int ShareSceneId { get; set; }

    /// <summary>
    /// 开启线下广告分享（开启后，本条记录没有统计结束时间，宣传单印刷后可长时间使用）
    /// </summary>
    public bool OfflineShare { get; set; }

    /// <summary>
    /// 是否无效
    /// </summary>
    public bool Invalid { get; set; }

    /// <summary>
    /// 是否有效区域内的用户创建（SharePageAdvert）
    /// 针对做现金广告的推广用户，要求在指定范围内的人创建朋友圈广告才统计为有效的现金广告
    /// </summary>
    public bool ValidArea { get; set; }

    /// <summary>
    /// 上一次结算日期（结算后可以删除访客对应日期之前的阅读记录
    /// </summary>
    public DateTime? BalanceDateUtc { get; set; }

    /// <summary>
    /// 分享循环周期结束日期(结束后，需要重新创建)
    /// </summary>
    public DateTime? CycleEndDateOnUtc { get; set; }

    /// <summary>
    /// 创建日期（用创建日期+ShareCycleDays判断是否需要新建记录）
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// 页面类型
    /// </summary>
    public PublicEntityType PublicEntityType
    {
        get => (PublicEntityType)PublicEntityTypeId;
        set => PublicEntityTypeId = (int)value;
    }

}
