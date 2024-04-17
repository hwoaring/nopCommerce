using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Stores;

/// <summary>
/// Represents a store
/// </summary>
public partial class Store : BaseEntity, ILocalizedEntity, ISoftDeletedEntity
{
    /// <summary>
    /// Gets or sets the store name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the meta keywords
    /// </summary>
    public string DefaultMetaKeywords { get; set; }

    /// <summary>
    /// Gets or sets the meta description
    /// </summary>
    public string DefaultMetaDescription { get; set; }

    /// <summary>
    /// Gets or sets the meta title
    /// </summary>
    public string DefaultTitle { get; set; }

    /// <summary>
    /// Home page title
    /// </summary>
    public string HomepageTitle { get; set; }

    /// <summary>
    /// Home page description
    /// </summary>
    public string HomepageDescription { get; set; }

    /// <summary>
    /// Gets or sets the store URL
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether SSL is enabled
    /// </summary>
    public bool SslEnabled { get; set; }

    /// <summary>
    /// Gets or sets the comma separated list of possible HTTP_HOST values
    /// </summary>
    public string Hosts { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the default language for this store; 0 is set when we use the default language display order
    /// </summary>
    public int DefaultLanguageId { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets the company name
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// Gets or sets the company address
    /// </summary>
    public string CompanyAddress { get; set; }

    /// <summary>
    /// Gets or sets the store phone number
    /// </summary>
    public string CompanyPhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the company VAT (used in Europe Union countries)
    /// </summary>
    public string CompanyVat { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted
    /// </summary>
    public bool Deleted { get; set; }


    #region === 扩展属性 ===

    /// <summary>
    /// 临时推荐人过期分钟数
    /// 0：表示不使用临时推荐人功能
    /// </summary>
    public int TempReferrerExpireMinutes { get; set; }

    /// <summary>
    /// 过期保护（临时推荐人过期前，不允许更新临时推荐人）
    /// </summary>
    public bool TempReferrerExpireProtect { get; set; }

    /// <summary>
    /// 是否开启推荐功能
    /// </summary>
    public bool ReferrerEnable { get; set; }

    /// <summary>
    /// 是否开启按品牌区分推荐人
    /// 即：不同店铺，不同品牌，不同推荐人
    /// </summary>
    public bool ReferrerByBrand { get; set; }

    /// <summary>
    /// 创建新推荐信息时候，默认是否允许成为推荐人
    /// </summary>
    public bool DefaultCustomerReferrerEnable { get; set; }

    /// <summary>
    /// 创建新推荐信息时候，默认是否允许被推荐人，不允许时，该用户不会成为其他用户的推荐客户或临时推荐客户
    /// </summary>
    public bool DefaultCustomerRecommendedEnable { get; set; }

    /// <summary>
    /// 创建新推荐信息时候，默认是否允许成为临时推荐人（False=不允许覆盖临时推荐信ID）
    /// </summary>
    public bool DefaultCustomerTempReferrerEnable { get; set; }

    /// <summary>
    /// 店铺最大产品数量
    /// </summary>
    public int MaxProductCount { get; set; }

    /// <summary>
    /// 最大发布新闻数量
    /// </summary>
    public int MaxNewsCount { get; set; }

    #endregion

}