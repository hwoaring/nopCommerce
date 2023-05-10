using System;
using System.Text.RegularExpressions;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Tax;
using StackExchange.Redis;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// 场所码
    /// </summary>
    public partial class PlaceCode : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 场所码ID（随机32位字母+数字）
        /// </summary>
        public string PlaceCodeId { get; set; }

        /// <summary>
        /// 场所名称
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区/县
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 场所地址
        /// </summary>
        public string PlaceAddress { get; set; }

        /// <summary>
        /// 场所图片
        /// </summary>
        public string PlaceImage { get; set; }

        /// <summary>
        /// 经度坐标
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度坐标
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 自定义场所名称
        /// </summary>
        public string PlaceTitle { get; set; }

        /// <summary>
        /// 自定义场所描述
        /// </summary>
        public string PlaceDescription { get; set; }

        /// <summary>
        /// 自定义场所文字内容
        /// </summary>
        public string PlaceContent { get; set; }

        /// <summary>
        /// 微信端生成的临时二维码链接（用于引导用户关注公众号）
        /// </summary>
        public string PlaceQrcodeUrl { get; set; }

        /// <summary>
        /// 永久场所码ID（绑定为永久场所码）
        /// </summary>
        public int LimitSceneId { get; set; }

        /// <summary>
        /// 是否永久场所码
        /// </summary>
        public bool LimitScene { get; set; } = false;

        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 临时二维码链接过期时间
        /// </summary>
        public DateTime? ExpirationDateUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
