﻿using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;


namespace Nop.Data.Mapping.Builders.AntiFake
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AntiFakeCodeBuilder : NopEntityBuilder<AntiFakeCode>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {

        }

        #endregion

    }
}
