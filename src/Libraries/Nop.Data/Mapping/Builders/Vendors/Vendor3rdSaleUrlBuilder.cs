using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class Vendor3rdSaleUrlBuilder : NopEntityBuilder<Vendor3rdSaleUrl>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(Vendor3rdSaleUrl.VendorId)).AsInt32().ForeignKey<Vendor>()
            .WithColumn(nameof(Vendor3rdSaleUrl.ProductId)).AsInt32().ForeignKey<Product>()
            .WithColumn(nameof(Vendor3rdSaleUrl.Url)).AsAnsiString(512).Nullable()

            ;
    }

    #endregion




}
