using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an WUser
    /// </summary>
    public partial class WUser : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        ///  对应[WConfig.Id]微信公众号原始ID，用于区分不同平台用户
        /// </summary>
        public int OriginalId { get; set; }

        /// <summary>
        /// 用户OpenId
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// UnionId
        /// </summary>
        public string UnionId { get; set; }

        /// <summary>
        /// 系统名称，只能后台设置
        /// </summary>
        public string SysName { get; set; }

        /// <summary>
        /// 本地系统给用户的备注标签只能后台设置
        /// </summary>
        public string SysRemark { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 公众号运营者对粉丝的备注，公众号运营者可在微信公众平台用户管理界面对粉丝添加备注（30字以内）
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 用户所在的分组ID（兼容旧的用户分组接口）
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 用户被打上的标签ID列
        /// </summary>
        public string TagIdList { get; set; }

        /// <summary>
        /// 头像完整路径
        /// </summary>
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 创建字段，不在数据库中使用：保存到本地磁盘，以/微信公众号原始ID目录/用户OpenId/ HeadImgUrl/图片返回的名称字符串.jpg形式保存。用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效
        /// </summary>
        public string HeadImgUrlShort { get; set; }

        /// <summary>
        /// 多平台下相同unionid，不同openid，查找第一个Id
        /// </summary>
        public int SameId { get; set; }
        /// <summary>
        /// 推荐人Id
        /// </summary>
        public int RefereeId { get; set; }

        /// <summary>
        /// OpenIdHash（为后期准备，如果大数据量没重复，可替换其他表的OpenId字段）
        /// </summary>
        public long OpenIdHash { get; set; }

        /// <summary>
        /// 供应商店铺ID，用于统计公司员工共同推荐下店铺总人数
        /// </summary>
        public int SupplierShopId { get; set; }

        /// <summary>
        /// 用户来源场景ID（永久或临时，默认0） 存储永久二维码ID或临时二维码广告图ID。二维码扫码场景（开发者自定义）场景值ID，临时二维码时为32位非0整型，永久二维码时最大值为100000（目前参数只支持1--100000）
        /// </summary>
        public int QrScene { get; set; }

        /// <summary>
        /// 二维码扫码场景描述（开发者自定义）场景值ID（字符串形式的ID），字符串类型，长度限制为1到64
        /// </summary>
        public string QrSceneStr { get; set; }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public byte Sex { get; set; }

        /// <summary>
        /// 用户语言默认=1中文简体
        /// </summary>
        public byte LanguageTypeId { get; set; }

        /// <summary>
        /// 返回用户关注的渠道来源
        /// </summary>
        public byte SubscribeSceneTypeId { get; set; }

        /// <summary>
        /// 信息登记方式：未知=0；通过Subscribe关注公众号方式登记=1；通过网页Oauth授权登记=2；通过Login授权方式登记=3
        /// </summary>
        public byte CheckInTypeId { get; set; }

        /// <summary>
        /// 自定义角色类型分组
        /// </summary>
        public byte RoleTypeId { get; set; }

        /// <summary>
        /// 场景类型
        /// </summary>
        public byte SceneTypeId { get; set; }

        /// <summary>
        /// 用户状态，可用于管理是否屏蔽用户请求信息，预留
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 是否允许推荐用户，默认true，不允许时，该用户无法执行正常推荐的后续操作
        /// </summary>
        public bool AllowReferee { get; set; }

        /// <summary>
        /// 是否允许平台返回交互信息给用户默认true。不允许交互时全部返回success
        /// </summary>
        public bool AllowResponse { get; set; }

        /// <summary>
        /// 是否允许下单
        /// </summary>
        public bool AllowOrder { get; set; }

        /// <summary>
        /// 是否接受被推荐人的订单提示信息或被推荐人进行某操作后给推荐人的消息提醒
        /// </summary>
        public bool AllowNotice { get; set; }

        /// <summary>
        /// 订单提醒，主要用于分销客户有库存情况下使用，提醒包括表单下单或正常下单。
        /// </summary>
        public bool AllowOrderNotice { get; set; }

        /// <summary>
        /// 是否在黑名单中
        /// </summary>
        public bool InBlackList { get; set; }

        /// <summary>
        /// 是否关注
        /// </summary>
        public bool Subscribe { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 关注时间
        /// </summary>
        public int SubscribeTime { get; set; }

        /// <summary>
        /// 最后取消关注时间
        /// </summary>
        public int UnSubscribeTime { get; set; }

        /// <summary>
        /// 更新时间（可用于定期更新拉取用户数据）
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreatTime { get; set; }



        /// <summary>
        /// 信息登记方式:未知=0；通过Subscribe关注公众号方式登记=1；通过网页Oauth授权登记=2；通过Login授权方式登记=3
        /// </summary>
        public WCheckInType CheckInType
        {
            get => (WCheckInType)CheckInTypeId;
            set => CheckInTypeId = (byte)value;
        }

        /// <summary>
        /// 返回用户关注的渠道来源
        /// </summary>
        public WSubscribeSceneType SubscribeSceneType
        {
            get => (WSubscribeSceneType)SubscribeSceneTypeId;
            set => SubscribeSceneTypeId = (byte)value;
        }

        /// <summary>
        /// 自定义角色类型分组
        /// </summary>
        public WRoleType RoleType
        {
            get => (WRoleType)RoleTypeId;
            set => RoleTypeId = (byte)value;
        }

        /// <summary>
        /// 场景类型
        /// </summary>
        public WSceneType SceneType
        {
            get => (WSceneType)SceneTypeId;
            set => SceneTypeId = (byte)value;
        }

        /// <summary>
        /// 用户语言
        /// </summary>
        public WLanguageType LanguageType
        {
            get => (WLanguageType)LanguageTypeId;
            set => LanguageTypeId = (byte)value;
        }

    }
}
