using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Assets;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Assets
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AssetsBankAccountBuilder : NopEntityBuilder<AssetsBankAccount>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AssetsBankAccount.AssetsCashsId)).AsInt32().ForeignKey<AssetsCashs>()
                .WithColumn(nameof(AssetsBankAccount.BankNumber)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(AssetsBankAccount.BankCode)).AsAnsiString(32).NotNullable()
                .WithColumn(nameof(AssetsBankAccount.BankAccount)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(AssetsBankAccount.BankAccountName)).AsString(32).NotNullable()
                .WithColumn(nameof(AssetsBankAccount.HashCode)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(AssetsBankAccount.Remark)).AsString(128).Nullable()
                .WithColumn(nameof(AssetsBankAccount.VerifiedOnUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion

    }
}
