using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Brands;

/// <summary>
/// 品牌、商标信息
/// </summary>
public partial class Brand : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 对外展示统一加密id（URL参数）
    /// </summary>
    public long UnifiedId { get; set; }

    /// <summary>
    /// 商标名称或品牌名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 商标内容描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 品牌背景，内容介绍（广告使用）
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 注册地ID，0=默认中国大陆
    /// </summary>
    public int RegistrationLocation { get; set; }

    /// <summary>
    /// 商标长编号
    /// </summary>
    public string LongCode { get; set; }

    /// <summary>
    /// 商标第字号编号
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 所属公司
    /// </summary>
    public string Company { get; set; }

    /// <summary>
    /// 国际编号
    /// </summary>
    public int InternationalCode { get; set; }

    /// <summary>
    /// 国际编号内容
    /// </summary>
    public string InternationalText { get; set; }

    /// <summary>
    /// seo关键词
    /// </summary>
    public string MetaKeywords { get; set; }

    /// <summary>
    /// seo描述
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// seo标题
    /// </summary>
    public string MetaTitle { get; set; }

    /// <summary>
    /// 模板ID
    /// </summary>
    public int BrandTemplateId { get; set; }

    /// <summary>
    /// 商标图片地址
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 授权文件图片
    /// </summary>
    public int AuthorizationPictureId { get; set; }

    /// <summary>
    /// 授权到期日期
    /// </summary>
    public DateTime? AuthorizationExpireDateUtc { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 是否店铺品牌（店铺品牌：如红旗连锁，舞东风等）
    /// 否则为产品品牌
    /// </summary>
    public bool VendorStoreBrand { get; set; }

    /// <summary>
    /// 发布
    /// </summary>
    public bool Published { get; set; }

    /// <summary>
    /// 私有品牌、不在系统中公开
    /// </summary>
     public bool PrivateBrand { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// 商标过期时间
    /// </summary>
    public DateTime? ExpireDateUtc { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }
}