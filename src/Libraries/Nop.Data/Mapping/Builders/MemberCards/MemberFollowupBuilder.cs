using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.MemberCards;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.MemberCards;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class MemberFollowupBuilder : NopEntityBuilder<MemberFollowup>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(MemberFollowup.StoreMembersId)).AsInt32().ForeignKey<StoreMembers>()
            .WithColumn(nameof(MemberFollowup.Content)).AsString(512).Nullable()

            ;
    }

    #endregion

}
