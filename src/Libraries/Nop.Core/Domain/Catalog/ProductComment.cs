namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 产品评论
/// </summary>
public partial class ProductComment : BaseEntity
{
    /// <summary>
    /// 产品ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 评论标题
    /// </summary>
    public string CommentTitle { get; set; }

    /// <summary>
    /// 评论内容
    /// </summary>
    public string CommentText { get; set; }

    /// <summary>
    /// 回复内容
    /// </summary>
    public string ReplyCommentText { get; set; }

    /// <summary>
    /// 回复时间
    /// </summary>
    public DateTime? ReplyDateOnUtc { get; set; }

    /// <summary>
    /// 评论发布IP位置
    /// </summary>
    public string PublishArea { get; set; }

    /// <summary>
    /// 评论人IP
    /// </summary>
    public string PublishIp { get; set; }

    /// <summary>
    /// 服务星级
    /// </summary>
    public byte ServiceStars { get; set; }
    /// <summary>
    /// 产品星级
    /// </summary>
    public byte ProductStars { get; set; }
    /// <summary>
    /// 环境星级
    /// </summary>
    public byte EnvStars { get; set; }
    /// <summary>
    /// 邮递星级
    /// </summary>
    public byte ShippingStars { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the comment is approved
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// Gets or sets the store identifier
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }
}