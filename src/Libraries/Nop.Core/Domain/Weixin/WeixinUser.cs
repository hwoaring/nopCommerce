using System;
using System.Text.RegularExpressions;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;
using StackExchange.Redis;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// 微信客户端用户信息
    /// </summary>
    public partial class WeixinUser : BaseEntity, ISoftDeletedEntity
    {

        /// <summary>
        /// 用户OpenId
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 用户个人资料填写的省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 普通用户个人资料填写的城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 国家，如中国为CN
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 用户没有头像时该项为空。若用户更换头像，原有头像 URL 将失效
        /// </summary>
        public string HeadimgUrl { get; set; }

        /// <summary>
        /// 用户特权信息，json 数组
        /// </summary>
        public string Privilege { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 关注时间
        /// </summary>
        public string SubscribeTime { get; set; }

        /// <summary>
        /// 取消关注时间
        /// </summary>
        public string UnSubscribeTime { get; set; }

        /// <summary>
        /// 统一ID
        /// </summary>
        public string UnionId { get; set; }

        /// <summary>
        /// 微信平台备注名称
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 分组ID
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 用户被打上的标签 ID 列表
        /// </summary>
        public string TagidList { get; set; }

        /// <summary>
        /// 关注的渠道来源ID
        /// </summary>
        public int SubscribeSceneTypeId { get; set; }

        /// <summary>
        /// 自定义二维码场景类型
        /// </summary>
        public int CustomSceneTypeId { get; set; }

        /// <summary>
        /// 用户来源场景值（永久或临时，默认0）,存储永久二维码ID或临时二维码广告图ID(CustomSceneTypeId=0是永久二维码，大于0是临时二维码广告图)
        /// </summary>
        public string CustomSceneValue { get; set; }

        /// <summary>
        /// 二维码扫码场景
        /// </summary>
        public string QrScene { get; set; }

        /// <summary>
        /// 二维码扫码场景描述
        /// </summary>
        public string QrSceneStr { get; set; }

        /// <summary>
        /// 用户状态，可用于管理是否屏蔽用户请求信息
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 是否关注
        /// </summary>
        public bool Subscribe { get; set; }

        /// <summary>
        /// 是否已进入黑名单
        /// </summary>
        public bool BlackList { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
