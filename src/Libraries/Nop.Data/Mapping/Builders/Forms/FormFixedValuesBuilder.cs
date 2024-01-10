﻿using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Forms;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Forms
{
    /// <summary>
    /// Represents a forum buil entity builder
    /// </summary>
    public partial class FormFixedValuesBuilder : NopEntityBuilder<FormFixedValues>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(FormFixedValues.Name)).AsString(128).NotNullable()
                .WithColumn(nameof(FormFixedValues.Value)).AsString(512).Nullable()
                .WithColumn(nameof(FormFixedValues.DefaultValue)).AsString(128).Nullable()
                .WithColumn(nameof(FormFixedValues.RegularExpression)).AsAnsiString(128).Nullable()

                .WithColumn(nameof(FormFixedValues.FormId)).AsInt32().ForeignKey<Form>()

                ;
        }

        #endregion
    }
}
