using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake;

/// <summary>
/// Represents a affiliate entity builder
/// </summary>
public partial class AntiFakeProductBuilder : NopEntityBuilder<AntiFakeProduct>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(AntiFakeProduct.AntiFakeCompanyId)).AsInt32().ForeignKey<AntiFakeCompany>().OnDelete(Rule.None)
            .WithColumn(nameof(AntiFakeProduct.Name)).AsString(128).NotNullable()
            .WithColumn(nameof(AntiFakeProduct.ProductTypeName)).AsString(128).Nullable()
            .WithColumn(nameof(AntiFakeProduct.ProductEdibleMethod)).AsString(128).Nullable()
            .WithColumn(nameof(AntiFakeProduct.ProductProcessMethod)).AsString(128).Nullable()
            .WithColumn(nameof(AntiFakeProduct.ProductMaterial)).AsString(128).Nullable()
            .WithColumn(nameof(AntiFakeProduct.ProductStandardNumber)).AsString(128).Nullable()
            .WithColumn(nameof(AntiFakeProduct.ProductionLicenseCode)).AsString(128).Nullable()
            .WithColumn(nameof(AntiFakeProduct.ProductStorage)).AsString(128).Nullable()
            .WithColumn(nameof(AntiFakeProduct.BrandName)).AsString(128).Nullable()
            .WithColumn(nameof(AntiFakeProduct.Tips)).AsString(512).Nullable()
            .WithColumn(nameof(AntiFakeProduct.Remark)).AsString(512).Nullable()
            .WithColumn(nameof(AntiFakeProduct.UnitName)).AsString(32).Nullable()

            ;
    }

    #endregion
}
