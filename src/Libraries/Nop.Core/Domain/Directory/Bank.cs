using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory;

/// <summary>
/// 银行资源信息表
/// </summary>
public partial class Bank : BaseEntity, ILocalizedEntity
{
    /// <summary>
    /// 银行名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 代码（简码）
    /// </summary>
    public string SimpleCode { get; set; }

    /// <summary>
    /// 数字编码
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 是否线上支付平台（如：支付宝，微信，易宝等）
    /// </summary>
    public bool OnlinePlatform { get; set; }

    /// <summary>
    /// 可用
    /// </summary>
    public bool Available { get; set; }
}
