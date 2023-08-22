namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents a customer role
    /// </summary>
    public partial class CustomerRole : BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer role name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is marked as free shipping
        /// </summary>
        public bool FreeShipping { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is marked as tax exempt
        /// </summary>
        public bool TaxExempt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is system
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// Gets or sets the customer role system name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customers must change passwords after a specified time
        /// </summary>
        public bool EnablePasswordLifetime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customers of this role have other tax display type chosen instead of the default one
        /// </summary>
        public bool OverrideTaxDisplayType { get; set; }

        /// <summary>
        /// Gets or sets identifier of the default tax display type (used only with "OverrideTaxDisplayType" enabled)
        /// </summary>
        public int DefaultTaxDisplayTypeId { get; set; }

        /// <summary>
        /// Gets or sets a product identifier that is required by this customer role. 
        /// A customer is added to this customer role once a specified product is purchased.
        /// </summary>
        public int PurchasedWithProductId { get; set; }

        /// <summary>
        /// 自动升级
        /// </summary>
        public bool AutoUpdate { get; set; }

        /// <summary>
        /// 是否默认角色
        /// </summary>
        public bool DefaultRole { get; set; }

        /// <summary>
        /// 购物折扣
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 预存款
        /// </summary>
        public decimal PreDeposits { get; set; }

        /// <summary>
        /// 最小经验值
        /// </summary>
        public int MinExp { get; set; }

        /// <summary>
        /// 最大经验值
        /// </summary>
        public int MaxExp { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedOnUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}