using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.RelationShips;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.RelationShips
{
    /// <summary>
    /// 公共标签
    /// </summary>
    public partial class PersonalRelationShipBuilder : NopEntityBuilder<PersonalRelationShip>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(PersonalRelationShip.Name)).AsString(64).Nullable()
                .WithColumn(nameof(PersonalRelationShip.Notes)).AsString(128).Nullable()
                .WithColumn(nameof(PersonalRelationShip.CourtesyName)).AsString(32).Nullable()
                .WithColumn(nameof(PersonalRelationShip.PhoneNumber)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(PersonalRelationShip.OtherPhoneNumbers)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(PersonalRelationShip.Description)).AsString(512).Nullable()
                .WithColumn(nameof(PersonalRelationShip.Company)).AsString(128).Nullable()
                .WithColumn(nameof(PersonalRelationShip.PostName)).AsString(64).Nullable()
   
                ;
        }

        #endregion
 
    }
}