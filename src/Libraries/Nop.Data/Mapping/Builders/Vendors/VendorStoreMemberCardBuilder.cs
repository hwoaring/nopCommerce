using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a affiliate entity builder
/// </summary>
public partial class VendorStoreMemberCardBuilder : NopEntityBuilder<VendorStoreMemberCard>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStoreMemberCard.VendorStoreMemberId)).AsInt32().ForeignKey<VendorStoreMember>()
            .WithColumn(nameof(VendorStoreMemberCard.PhysicalCardNumber)).AsAnsiString(64).Nullable()
            .WithColumn(nameof(VendorStoreMemberCard.Notes)).AsString(64).Nullable()
            .WithColumn(nameof(VendorStoreMemberCard.HashCode)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(VendorStoreMemberCard.LockRemark)).AsString(128).Nullable()

            ;
    }

    #endregion

}