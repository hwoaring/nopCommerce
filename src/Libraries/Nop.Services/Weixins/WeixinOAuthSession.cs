using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Weixins;

namespace Nop.Services.Weixins
{
    /// <summary>
    /// 保存weixin oauth 值
    /// </summary>
    [Serializable]
    public partial class WeixinOAuthSession
    {
        /// <summary>
        /// 原始返回页面，非微信的回调页面(备用)
        /// </summary>
        public string ReturnUrl { get; set; }
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
        public int? IsSnapshotuser { get; set; }
        /// <summary>
        /// access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        public int ExpiresIn { get; set; }
        /// <summary>
        /// CreatTime 最后创建/更新时间
        /// </summary>
        public DateTime CreatTime { get; set; }

    }
}
