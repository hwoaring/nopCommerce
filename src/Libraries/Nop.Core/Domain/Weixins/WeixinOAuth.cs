using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Weixins;

/// <summary>
/// 微信授权信息存储，暂时存在缓存中
/// </summary>
public partial class WeixinOAuth : BaseEntity
{
    /// <summary>
    /// UnionId
    /// </summary>
    public string UnionId { get; set; }

    /// <summary>
    /// OpenId
    /// </summary>
    public string OpenId { get; set; }
    /// <summary>
    /// 有效期2小时
    /// </summary>
    public string AccessToken { get; set; }
    /// <summary>
    /// 用户刷新access_token,有效期30天
    /// </summary>
    public string RefreshToken { get; set; }
    /// <summary>
    /// 用户授权的作用域，使用逗号（,）分隔
    /// </summary>
    public string Scope { get; set; }
    /// <summary>
    /// 是否为快照页模式虚拟账号，只有当用户是快照页模式虚拟账号时返回，值为1
    /// </summary>
    public int IsSnapshotuser { get; set; }
    /// <summary>
    /// access_token接口调用凭证超时时间，单位（秒）
    /// </summary>
    public int ExpiresIn { get; set; }
    /// <summary>
    /// CreatTime 最后创建/更新时间
    /// </summary>
    public DateTime UpdateOnUtc { get; set; }
}
