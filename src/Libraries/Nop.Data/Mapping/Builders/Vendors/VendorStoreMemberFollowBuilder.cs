using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStoreMemberFollowBuilder : NopEntityBuilder<VendorStoreMemberFollow>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStoreMemberFollow.VendorStoreMemberId)).AsInt32().ForeignKey<VendorStoreMember>()
            .WithColumn(nameof(VendorStoreMemberFollow.Content)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStoreMemberFollow.NextVisitDateUtc)).AsDateTime2().Nullable()
            .WithColumn(nameof(VendorStoreMemberFollow.VisitDateUtc)).AsDateTime2().Nullable()
            ;
    }

    #endregion

}
