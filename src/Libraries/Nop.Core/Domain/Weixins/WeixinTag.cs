using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Weixins;

/// <summary>
/// 微信账号配置
/// </summary>
public partial class WeixinTag : BaseEntity
{
    /// <summary>
    /// StoreId
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 微信官方平台返回的TagId
    /// </summary>
    public int TagId { get; set; }

    /// <summary>
    /// 微信平台的标签名称
    /// </summary>
    public string TagName { get; set; }
}
