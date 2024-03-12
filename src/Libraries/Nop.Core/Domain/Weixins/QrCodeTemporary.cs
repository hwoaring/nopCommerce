using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Weixins;

/// <summary>
/// 临时二维码
/// </summary>
public partial class QrCodeTemporary : BaseEntity
{
    /// <summary>
    /// 区分公众号平台
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 创建二维码的用户Id
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 微信自动回复消息内容ID
    /// </summary>
    public int WeixinMessageResponseId { get; set; }

    /// <summary>
    /// 自定义场景类型
    /// </summary>
    public int QrCodeSceneTypeId { get; set; }

    /// <summary>
    /// 二维码类型
    /// </summary>
    public int QrcodeActionTypeId { get; set; }

    /// <summary>
    /// 数字id参数
    /// </summary>
    public int SceneId { get; set; }

    /// <summary>
    /// 字符参数
    /// </summary>
    public string SceneStr { get; set; }

    /// <summary>
    /// 过期秒数
    /// </summary>
    public int ExpireSeconds { get; set; }

    /// <summary>
    /// 获取的二维码ticket
    /// </summary>
    public string Ticket { get; set; }

    /// <summary>
    /// 二维码图片解析后的地址
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 添加/更新时间
    /// </summary>
    public DateTime UpdateOnUtc { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    public DateTime? ExpireOnUtc { get; set; }


    public QrCodeSceneType QrCodeSceneType
    {
        get => (QrCodeSceneType)QrCodeSceneTypeId;
        set => QrCodeSceneTypeId = (int)value;
    }

    public QrcodeActionType QrcodeActionType
    {
        get => (QrcodeActionType)QrcodeActionTypeId;
        set => QrcodeActionTypeId = (int)value;
    }
}
