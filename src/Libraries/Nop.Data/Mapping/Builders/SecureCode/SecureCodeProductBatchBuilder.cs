using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SecureCode;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SecureCode
{
    /// <summary>
    /// Represents a SecureCodeProductBatch entity builder
    /// </summary>
    public partial class SecureCodeProductBatchBuilder : NopEntityBuilder<SecureCodeProductBatch>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SecureCodeProductBatch.BatchNumber)).AsString(32).NotNullable()
                .WithColumn(nameof(SecureCodeProductBatch.ProductionLine)).AsString(32).Nullable()
                .WithColumn(nameof(SecureCodeProductBatch.InspectorName)).AsString(16).Nullable()
                .WithColumn(nameof(SecureCodeProductBatch.ManufactureDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeProductBatch.ExpireDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeProductBatch.ActiveDateUtc)).AsDateTime2().Nullable()
                ;

        }

        #endregion
    }
}