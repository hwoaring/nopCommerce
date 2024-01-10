using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.RelationShips;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.RelationShips
{
    /// <summary>
    /// 公共标签
    /// </summary>
    public partial class PersonalRelationCooperaterBuilder : NopEntityBuilder<PersonalRelationCooperater>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(PersonalRelationCooperater.PersonalRelationShipId)).AsInt32().ForeignKey<PersonalRelationShip>()

                ;
        }

        #endregion

    }
}
