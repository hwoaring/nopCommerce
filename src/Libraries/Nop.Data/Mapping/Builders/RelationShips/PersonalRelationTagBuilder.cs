using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.RelationShips;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.RelationShips
{
    /// <summary>
    /// 公共标签
    /// </summary>
    public partial class PersonalRelationTagBuilder : NopEntityBuilder<PersonalRelationTag>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(PersonalRelationTag.Name)).AsString(32).NotNullable()
                ;
        }

        #endregion

    }
}