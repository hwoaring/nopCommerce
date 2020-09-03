using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Common
{
    /// <summary>
    /// Represents a address entity builder
    /// </summary>
    public partial class AddressBuilder : NopEntityBuilder<Address>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Address.CountryId)).AsInt32().Nullable().ForeignKey<Country>(onDelete: Rule.None)
                .WithColumn(nameof(Address.StateProvinceId)).AsInt32().Nullable().ForeignKey<StateProvince>(onDelete: Rule.None)
                .WithColumn(nameof(Address.AddressLable)).AsString(64).Nullable()
                .WithColumn(nameof(Address.FirstName)).AsString(128).Nullable()
                .WithColumn(nameof(Address.LastName)).AsString(128).Nullable()
                .WithColumn(nameof(Address.Email)).AsString(128).Nullable()
                .WithColumn(nameof(Address.Company)).AsString(128).Nullable()
                .WithColumn(nameof(Address.County)).AsString(128).Nullable()
                .WithColumn(nameof(Address.City)).AsString(128).Nullable()
                .WithColumn(nameof(Address.Address1)).AsString(512).Nullable()
                .WithColumn(nameof(Address.Address2)).AsString(512).Nullable()
                .WithColumn(nameof(Address.ZipPostalCode)).AsString(64).Nullable()
                .WithColumn(nameof(Address.PhoneNumber)).AsString(64).Nullable()
                .WithColumn(nameof(Address.FaxNumber)).AsString(64).Nullable()
                .WithColumn(nameof(Address.DivisionsCode)).AsAnsiString(15).Nullable()
                ;
        }

        #endregion
    }
}