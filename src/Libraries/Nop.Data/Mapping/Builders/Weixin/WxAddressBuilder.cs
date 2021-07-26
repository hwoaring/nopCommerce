using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WxAddressBuilder : NopEntityBuilder<WxAddress>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxAddress.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(WxAddress.UserName)).AsString(50).NotNullable()
                .WithColumn(nameof(WxAddress.PostalCode)).AsAnsiString(15).Nullable()
                .WithColumn(nameof(WxAddress.TelNumber)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(WxAddress.ProvinceName)).AsString(15).Nullable()
                .WithColumn(nameof(WxAddress.CityName)).AsString(15).Nullable()
                .WithColumn(nameof(WxAddress.CountryName)).AsString(15).Nullable()
                .WithColumn(nameof(WxAddress.DetailInfo)).AsString(255).Nullable()
                .WithColumn(nameof(WxAddress.AddressLable)).AsString(64).Nullable()
                .WithColumn(nameof(WxAddress.NationalCode)).AsAnsiString(15).Nullable()
                ;
        }

        #endregion
    }
}
