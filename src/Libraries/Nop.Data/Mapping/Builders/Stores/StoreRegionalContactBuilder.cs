using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Stores
{
    /// <summary>
    /// Represents a Store Regional Contact entity builder
    /// </summary>
    public partial class StoreRegionalContactBuilder : NopEntityBuilder<StoreRegionalContact>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(StoreRegionalContact.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(StoreRegionalContact.RegionalKey)).AsString(64).NotNullable()
                .WithColumn(nameof(StoreRegionalContact.CompanyName)).AsString(64).NotNullable()
                .WithColumn(nameof(StoreRegionalContact.CompanyImage)).AsString(512).Nullable()
                .WithColumn(nameof(StoreRegionalContact.ContactName)).AsString(512).Nullable()
                .WithColumn(nameof(StoreRegionalContact.CompanyPhoneNumber)).AsString(512).Nullable()
                .WithColumn(nameof(StoreRegionalContact.MapURL)).AsString(512).Nullable()
                .WithColumn(nameof(StoreRegionalContact.RedirectUrl)).AsAnsiString(1024).Nullable()
                ;
        }

        #endregion
    }
}