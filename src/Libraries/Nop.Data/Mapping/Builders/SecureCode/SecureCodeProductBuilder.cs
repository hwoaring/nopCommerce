using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SecureCode;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SecureCode
{
    /// <summary>
    /// Represents a SecureCodeProduct entity builder
    /// </summary>
    public partial class SecureCodeProductBuilder : NopEntityBuilder<SecureCodeProduct>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SecureCodeProduct.SecurityProductId)).AsAnsiString(32).NotNullable()
                .WithColumn(nameof(SecureCodeProduct.Title)).AsString(128).Nullable()
                .WithColumn(nameof(SecureCodeProduct.SubTitle)).AsString(512).Nullable()
                .WithColumn(nameof(SecureCodeProduct.ImagesUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(SecureCodeProduct.Description)).AsString(1024).Nullable()
                ;
        }

        #endregion
    }
}