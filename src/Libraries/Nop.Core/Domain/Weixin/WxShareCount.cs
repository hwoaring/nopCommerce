﻿using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an WxShareCount
    /// </summary>
    public partial class WxShareCount : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// WxShareLink.Id值
        /// </summary>
        public int WxShareLinkId { get; set; }

        /// <summary>
        /// 阅读用户ID
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 是否点赞，默认=false
        /// </summary>
        public bool IsThumbUp { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }
        /// <summary>
        /// 是否无效
        /// </summary>
        public bool Invalid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int CreatTime { get; set; }

    }
}
