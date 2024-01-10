using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.SMS;
using Nop.Data.Extensions;
using Nop.Core.Domain.Vendors;

namespace Nop.Data.Mapping.Builders.SMS
{
    /// <summary>
    /// Represents a store entity builder
    /// </summary>
    public partial class SmsAccountBuilder : NopEntityBuilder<SmsAccount>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SmsAccount.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(SmsAccount.VendorStoreId)).AsInt32().ForeignKey<VendorStore>()
                .WithColumn(nameof(SmsAccount.Name)).AsString(400).NotNullable()
                .WithColumn(nameof(SmsAccount.Description)).AsString(400).Nullable()
                .WithColumn(nameof(SmsAccount.AppId)).AsString(128).Nullable()
                .WithColumn(nameof(SmsAccount.AppKey)).AsString(128).Nullable()
                .WithColumn(nameof(SmsAccount.TagName)).AsString(128).Nullable()
                .WithColumn(nameof(SmsAccount.TagValues)).AsString(128).Nullable()
                ;
        }

        #endregion

    }
}
