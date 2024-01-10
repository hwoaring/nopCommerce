using FluentMigrator.Builders.Create.Table;
using Microsoft.SqlServer.Server;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Forms;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Forms
{
    /// <summary>
    /// Represents a forum buil entity builder
    /// </summary>
    public partial class FormCustomerMappingBuilder : NopEntityBuilder<FormCustomerMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(FormCustomerMapping.FormId)).AsInt32().ForeignKey<Form>()
                .WithColumn(nameof(FormCustomerMapping.CustomerId)).AsInt32().ForeignKey<Customer>()

                ;
        }

        #endregion

    }
}
