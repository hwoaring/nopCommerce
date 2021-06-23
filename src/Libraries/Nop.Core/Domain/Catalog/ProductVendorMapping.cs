﻿namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a product-vendor mapping class
    /// </summary>
    public partial class ProductVendorMapping : BaseEntity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier
        /// </summary>
        public int VendorId { get; set; }
    }
}