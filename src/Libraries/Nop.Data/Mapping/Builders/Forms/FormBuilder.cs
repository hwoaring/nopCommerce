using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Forms;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Forms
{
    /// <summary>
    /// Represents a forum buil entity builder
    /// </summary>
    public partial class FormBuilder : NopEntityBuilder<Form>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Form.Name)).AsString(200).NotNullable()
                .WithColumn(nameof(Form.Description)).AsString(1024).Nullable()

                ;
        }

        #endregion
 
    }
}
