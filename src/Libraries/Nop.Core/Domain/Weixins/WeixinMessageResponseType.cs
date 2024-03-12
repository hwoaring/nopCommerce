namespace Nop.Core.Domain.Weixins;

/// <summary>
/// 微信消息回复类型
/// </summary>
public enum WeixinMessageResponseType
{
    /// <summary>
    /// 未知，不回复任何消息SUCCESS
    /// </summary>
    None = 0,

    /// <summary>
    /// 文本消息
    /// </summary>
    Text = 1,

    /// <summary>
    /// 图片消息
    /// </summary>
    Image = 2,

    /// <summary>
    /// 语音消息
    /// </summary>
    Voice = 3,

    /// <summary>
    /// 视频消息
    /// </summary>
    Video = 4,

    /// <summary>
    /// 音乐消息
    /// </summary>
    Music = 5,

    /// <summary>
    /// 图文消息
    /// </summary>
    News = 6,

    /// <summary>
    /// 个人名片
    /// </summary>
    CARD = 7,

    /// <summary>
    /// 场所码
    /// </summary>
    PLACE = 8,

    /// <summary>
    /// 其他
    /// </summary>
    OTHER = 99
}
