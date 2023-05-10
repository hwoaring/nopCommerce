using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// 代理商选择要代理的产品
    /// </summary>
    public partial class VendorProductMappingBuilder : NopEntityBuilder<VendorProductMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorProductMapping.VendorId)).AsInt32().ForeignKey<Vendor>()
                .WithColumn(nameof(VendorProductMapping.ProductId)).AsInt32().ForeignKey<Product>()
                ;
        }

        #endregion
    }
}