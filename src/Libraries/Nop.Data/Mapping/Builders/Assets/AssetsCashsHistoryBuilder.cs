using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Assets;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Assets
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AssetsCashsHistoryBuilder : NopEntityBuilder<AssetsCashsHistory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AssetsCashsHistory.BankCode)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(AssetsCashsHistory.BankNumber)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(AssetsCashsHistory.BankAccount)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(AssetsCashsHistory.PayeeName)).AsString(64).Nullable()
                .WithColumn(nameof(AssetsCashsHistory.PayeeSerialNumber)).AsString(128).Nullable()
                .WithColumn(nameof(AssetsCashsHistory.Remark)).AsString(64).Nullable()
                .WithColumn(nameof(AssetsCashsHistory.Purpose)).AsString(64).Nullable()
                .WithColumn(nameof(AssetsCashsHistory.Message)).AsString(512).Nullable()
                .WithColumn(nameof(AssetsCashsHistory.HashCode)).AsString(128).Nullable()
                .WithColumn(nameof(AssetsCashsHistory.LockRemark)).AsString(64).Nullable()
                ;
        }

        #endregion
    }
}
