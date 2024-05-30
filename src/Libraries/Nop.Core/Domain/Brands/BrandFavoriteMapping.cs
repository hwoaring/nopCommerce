namespace Nop.Core.Domain.Brands;

/// <summary>
/// 品牌动态订阅，点赞，收藏等
/// </summary>
public partial class BrandFavoriteMapping : BaseEntity
{
    /// <summary>
    /// 品牌ID
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// 客户ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 不喜欢
    /// </summary>
    public bool Dislike { get; set; }

    /// <summary>
    /// 订阅
    /// </summary>
    public bool Subscribe { get; set; }

    /// <summary>
    /// 收藏
    /// </summary>
    public bool Favorited { get; set; }

    /// <summary>
    /// 推荐
    /// </summary>
    public bool Recommended { get; set; }

    /// <summary>
    /// 点赞
    /// </summary>
    public bool Thumbed { get; set; }
}