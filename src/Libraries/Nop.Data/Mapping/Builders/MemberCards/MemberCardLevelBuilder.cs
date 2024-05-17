using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.MemberCards;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.MemberCards;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class MemberCardLevelBuilder : NopEntityBuilder<MemberCardLevel>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(MemberCardLevel.VendorStoreId)).AsInt32().ForeignKey<VendorStore>()
            .WithColumn(nameof(MemberCardLevel.Name)).AsString(64).NotNullable()
            .WithColumn(nameof(MemberCardLevel.Description)).AsString(512).Nullable()
            .WithColumn(nameof(MemberCardLevel.Content)).AsString(4000).Nullable()
            .WithColumn(nameof(MemberCardLevel.SystemName)).AsString(64).Nullable()

            ;
    }

    #endregion

}