using Nop.Core.Configuration;

namespace Nop.Core.Domain.Assets;

/// <summary>
/// 资产设置
/// </summary>
public partial class AssetsSettings : ISettings
{
    /// <summary>
    /// 核销密码过期分钟数
    /// </summary>
    public int PassWordExpireMinutes { get; set; }

    /// <summary>
    /// 过期退票时间（过期几天后可退）
    /// </summary>
    public int ExpiredRefundDays { get; set; }
}