namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a Category-vendor mapping class
    /// </summary>
    public partial class CategoryVendorMapping : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Category identifier
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier
        /// </summary>
        public int VendorId { get; set; }
    }
}