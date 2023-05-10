using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SecureCode;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SecureCode
{
    /// <summary>
    /// Represents a SecureCodeDiscountRecord entity builder
    /// </summary>
    public partial class SecureCodeDiscountRecordBuilder : NopEntityBuilder<SecureCodeDiscountRecord>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SecureCodeDiscountRecord.Password)).AsString(32).Nullable()
                .WithColumn(nameof(SecureCodeDiscountRecord.RecieverPhone)).AsAnsiString(16).Nullable()
                .WithColumn(nameof(SecureCodeDiscountRecord.ExchangeDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeDiscountRecord.ExpireDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeDiscountRecord.ExchangeCreatDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeDiscountRecord.SecureCodeRecordId)).AsInt32().ForeignKey<SecureCodeRecord>()
                ;
        }

        #endregion
    }
}