using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStoreCategoryBuilder : NopEntityBuilder<VendorStoreCategory>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStoreCategory.VendorStoreId)).AsInt32().ForeignKey<VendorStore>()
            .WithColumn(nameof(VendorStoreCategory.Name)).AsString(32).NotNullable()
            .WithColumn(nameof(VendorStoreCategory.Description)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStoreCategory.MetaKeywords)).AsString(128).Nullable()
            .WithColumn(nameof(VendorStoreCategory.MetaDescription)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStoreCategory.MetaTitle)).AsString(128).Nullable()
            ;
    }

    #endregion

}
