﻿using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.FriendCircles;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Common;

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
                
                .WithColumn(nameof(Address.AddressLable)).AsString(32).Nullable()
                .WithColumn(nameof(Address.Latitude)).AsDecimal(9, 6).Nullable()
                .WithColumn(nameof(Address.Longitude)).AsDecimal(9, 6).Nullable()

                ;
        }

    #endregion
}