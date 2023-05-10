using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SecureCode;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SecureCode
{
    /// <summary>
    /// Represents a SecureCodeInnerRecord entity builder
    /// </summary>
    public partial class SecureCodeInnerRecordBuilder : NopEntityBuilder<SecureCodeInnerRecord>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SecureCodeInnerRecord.Province)).AsString(16).Nullable()
                .WithColumn(nameof(SecureCodeInnerRecord.City)).AsString(16).Nullable()
                .WithColumn(nameof(SecureCodeInnerRecord.County)).AsString(16).Nullable()
                .WithColumn(nameof(SecureCodeInnerRecord.Longitude)).AsDecimal(10,6)
                .WithColumn(nameof(SecureCodeInnerRecord.Latitude)).AsDecimal(10,6)
                .WithColumn(nameof(SecureCodeInnerRecord.SecureCodeRecordId)).AsInt32().ForeignKey<SecureCodeRecord>()
                ;
        }

        #endregion
    }
}