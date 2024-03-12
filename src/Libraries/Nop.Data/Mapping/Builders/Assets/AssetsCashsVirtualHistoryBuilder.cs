using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Assets;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Assets
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AssetsCashsVirtualHistoryBuilder : NopEntityBuilder<AssetsCashsVirtualHistory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AssetsCashsVirtualHistory.BankCode)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(AssetsCashsVirtualHistory.BankNumber)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(AssetsCashsVirtualHistory.BankAccount)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(AssetsCashsVirtualHistory.PayeeName)).AsString(64).Nullable()
                .WithColumn(nameof(AssetsCashsVirtualHistory.PayeeSerialNumber)).AsString(128).Nullable()
                .WithColumn(nameof(AssetsCashsVirtualHistory.Remark)).AsString(64).Nullable()
                .WithColumn(nameof(AssetsCashsVirtualHistory.Purpose)).AsString(64).Nullable()
                .WithColumn(nameof(AssetsCashsVirtualHistory.Message)).AsString(512).Nullable()
                .WithColumn(nameof(AssetsCashsVirtualHistory.HashCode)).AsString(128).Nullable()
                .WithColumn(nameof(AssetsCashsVirtualHistory.LockRemark)).AsString(64).Nullable()
                ;
        }

        #endregion
    }
}
