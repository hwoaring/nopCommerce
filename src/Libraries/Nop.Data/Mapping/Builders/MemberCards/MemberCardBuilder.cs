using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.MemberCards;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.MemberCards;

/// <summary>
/// Represents a affiliate entity builder
/// </summary>
public partial class MemberCardBuilder : NopEntityBuilder<MemberCard>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(MemberCard.StoreMembersId)).AsInt32().ForeignKey<StoreMembers>()
            .WithColumn(nameof(MemberCard.Relationship)).AsString(32).Nullable()
            .WithColumn(nameof(MemberCard.HashCode)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(MemberCard.LockRemark)).AsString(128).Nullable()

            .WithColumn(nameof(MemberCard.ExpireTimeOnUtc)).AsDateTime2().Nullable()
            .WithColumn(nameof(MemberCard.UpgradeTimeOnUtc)).AsDateTime2().Nullable()

            ;
    }

    #endregion

}