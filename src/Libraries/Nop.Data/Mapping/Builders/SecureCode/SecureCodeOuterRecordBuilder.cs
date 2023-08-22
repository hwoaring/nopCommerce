using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SecureCode;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SecureCode
{
    /// <summary>
    /// Represents a SecureCodeOuterRecord entity builder
    /// </summary>
    public partial class SecureCodeOuterRecordBuilder : NopEntityBuilder<SecureCodeOuterRecord>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SecureCodeOuterRecord.SecureCodeRegionSellerId)).AsInt32().ForeignKey<SecureCodeRegionSeller>(onDelete: Rule.None)
                ;
        }

        #endregion
    }
}