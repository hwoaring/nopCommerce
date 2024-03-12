

namespace Nop.Core.Domain.Weixins;

/// <summary>
/// 永久二维码
/// </summary>
public partial class QrCodeLimit : BaseEntity
{
    /// <summary>
    /// 区分公众号平台
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 绑定到用户Id（为空或0=没有绑定到用户）
    /// QrCodeLimitCustomerMapping 中没有设置绑定或绑定过期，则判断本CustomerId值
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 微信自动回复消息内容ID
    /// </summary>
    public int WeixinMessageResponseId { get; set; }

    /// <summary>
    /// 数字id参数
    /// </summary>
    public int SceneId { get; set; }

    /// <summary>
    /// 字符参数
    /// </summary>
    public string SceneStr { get; set; }

    /// <summary>
    /// 自定义场景类型
    /// </summary>
    public int QrCodeSceneTypeId { get; set; }

    /// <summary>
    /// 二维码类型
    /// </summary>
    public int QrcodeActionTypeId { get; set; }

    /// <summary>
    /// 过期秒数
    /// </summary>
    public int ExpireSeconds { get; set; }

    /// <summary>
    /// 二维码名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 二维码描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 获取的二维码ticket
    /// </summary>
    public string Ticket { get; set; }

    /// <summary>
    /// 二维码图片解析后的地址
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 二维码分组ID
    /// </summary>
    public int QrCodeCategoryId { get; set; }

    /// <summary>
    /// 二维码渠道ID
    /// </summary>
    public int QrCodeChannelId { get; set; }

    /// <summary>
    /// 用户被自动打上的标签ID列表（扫描该二维码用户自动打上标签）
    /// </summary>
    public string TagIdList { get; set; }

    /// <summary>
    /// 固定分配使用（将二维码永久分配占用）
    /// </summary>
    public bool FixedUse { get; set; }

    /// <summary>
    /// 添加/更新时间
    /// </summary>
    public DateTime UpdateOnUtc { get; set; }


    public QrcodeActionType QrcodeActionType
    {
        get => (QrcodeActionType)QrcodeActionTypeId;
        set => QrcodeActionTypeId = (int)value;
    }

}
