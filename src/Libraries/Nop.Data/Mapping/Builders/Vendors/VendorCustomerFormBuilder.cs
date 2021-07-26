﻿using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class VendorCustomerFormBuilder : NopEntityBuilder<VendorCustomerForm>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorCustomerForm.VendorId)).AsInt32().ForeignKey<Vendor>()
                .WithColumn(nameof(VendorCustomerForm.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(VendorCustomerForm.Phone)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(VendorCustomerForm.ReplyDateUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}