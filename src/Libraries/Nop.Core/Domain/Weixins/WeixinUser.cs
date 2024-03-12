using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Weixins;

/// <summary>
/// 微信用户信息
/// </summary>
public partial class WeixinUser : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 用户注册或关注的StoreId
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 用户CustomerId
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 微信用户ID，未加密的微信公众号原号（备用）
    /// </summary>
    public string WeixinId { get; set; }

    /// <summary>
    /// 用户OpenId
    /// </summary>
    public string OpenId { get; set; }

    /// <summary>
    /// 统一ID
    /// </summary>
    public string UnionId { get; set; }

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
    /// 头像保存到数据库中的ID
    /// </summary>
    public int HeadimgPictureId { get; set; }

    /// <summary>
    /// 用户特权信息，json 数组
    /// </summary>
    public string Privilege { get; set; }

    /// <summary>
    /// 微信平台的备注名称
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 网站系统后台的备注名称
    /// </summary>
    public string SystemRemark { get; set; }

    /// <summary>
    /// 分组ID
    /// </summary>
    public string GroupId { get; set; }

    /// <summary>
    /// 用户被打上的标签 ID 列表
    /// </summary>
    public string TagidList { get; set; }

    /// <summary>
    /// 自定义二维码场景类型
    /// </summary>
    public int QrCodeSceneTypeId { get; set; }

    /// <summary>
    /// 用户来源场景值（永久或临时，默认0）,存储永久二维码ID或临时二维码广告图ID(CustomSceneTypeId=0是永久二维码，大于0是临时二维码广告图)
    /// </summary>
    public string CustomSceneValue { get; set; }

    /// <summary>
    /// 二维码扫码场景(开发者自定义)
    /// </summary>
    public string QrScene { get; set; }

    /// <summary>
    /// 二维码扫码场景(开发者自定义)
    /// </summary>
    public string QrSceneStr { get; set; }

    /// <summary>
    /// 从关注的二维码场景值中提取永久推荐人ID（如果有推荐人ID信息）
    /// 新创建Customer信息时，可能会用到
    /// </summary>
    public int ReferrerCustomerId { get; set; }

    /// <summary>
    /// 关注的渠道来源ID
    /// </summary>
    public int SubscribeSceneTypeId { get; set; }

    /// <summary>
    /// 8位个人推荐码（备用，当被推荐人直接使用公众号关注二维码时，临时存储推荐人的代码）
    /// 如果系统功能能够直接创建新的Customer信息，则不使用本字段
    /// </summary>
    public long ReferrerCode { get; set; }

    /// <summary>
    /// 是否允许用户在微信平台交互信息。不允许交互时全部返回success
    /// </summary>
    public bool AllowResponse { get; set; }

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
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// 关注时间
    /// </summary>
    public DateTime? SubscribeTime { get; set; }

    /// <summary>
    /// 取消关注时间
    /// </summary>
    public DateTime? UnSubscribeTime { get; set; }

    /// <summary>
    /// 更新时间(新创建时，更新时间为创建时间)
    /// </summary>
    public DateTime UpdatedOnUtc { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    #region Weixin User Properties

    public QrCodeSceneType QrCodeSceneType
    {
        get => (QrCodeSceneType)QrCodeSceneTypeId;
        set => QrCodeSceneTypeId = (int)value;
    }

    public SubscribeSceneType SubscribeSceneType
    {
        get => (SubscribeSceneType)SubscribeSceneTypeId;
        set => SubscribeSceneTypeId = (int)value;
    }

    #endregion
}
