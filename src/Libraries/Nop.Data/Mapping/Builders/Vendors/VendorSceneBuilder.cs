using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorSceneBuilder : NopEntityBuilder<VendorScene>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorScene.VendorId)).AsInt32().ForeignKey<Vendor>()
            .WithColumn(nameof(VendorScene.Name)).AsString(32).NotNullable()
            .WithColumn(nameof(VendorScene.StrValue)).AsAnsiString(64).Nullable()
            ;
    }

    #endregion

}
