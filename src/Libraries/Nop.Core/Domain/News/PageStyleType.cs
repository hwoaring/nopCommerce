namespace Nop.Core.Domain.News;

/// <summary>
/// 页面模板样式
/// </summary>
public enum PageStyleType
{
    /// <summary>
    /// 微信界面样式
    /// </summary>
    WeChatPage = 1,

    /// <summary>
    /// 新闻界面（头部格式不同）
    /// </summary>
    NewsPage = 2,

    /// <summary>
    /// 图片界面（去掉头部信息）
    /// </summary>
    ImagePage = 3,

    /// <summary>
    /// 视频界面
    /// </summary>
    VideoPage = 4,
}
