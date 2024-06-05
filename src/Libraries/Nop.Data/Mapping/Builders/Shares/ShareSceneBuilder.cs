using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shares;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class ShareSceneBuilder : NopEntityBuilder<ShareScene>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ShareScene.CustomerId)).AsInt32().ForeignKey<Customer>()
            .WithColumn(nameof(ShareScene.Name)).AsString(32).NotNullable()
            .WithColumn(nameof(ShareScene.StrValue)).AsAnsiString(64).Nullable()
            ;
    }

    #endregion

}
