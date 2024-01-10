﻿using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AntiFakeCodeScanRecordsBuilder : NopEntityBuilder<AntiFakeCodeScanRecords>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AntiFakeCodeScanRecords.CustomerId)).AsInt32().ForeignKey<Customer>().OnDelete(Rule.None)
                .WithColumn(nameof(AntiFakeCodeScanRecords.Longitude)).AsDecimal(9, 6).Nullable()
                .WithColumn(nameof(AntiFakeCodeScanRecords.Latitude)).AsDecimal(9, 6).Nullable()

                ;
        }

        #endregion

    }
}
