using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.RelationShips;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.RelationShips
{
    /// <summary>
    /// 公共标签
    /// </summary>
    public partial class PersonalRelationFollowupBuilder : NopEntityBuilder<PersonalRelationFollowup>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(PersonalRelationFollowup.PersonalRelationShipId)).AsInt32().ForeignKey<PersonalRelationShip>()
                .WithColumn(nameof(PersonalRelationFollowup.Content)).AsString(1024).Nullable()
                
                ;
        }

        #endregion

    }
}
