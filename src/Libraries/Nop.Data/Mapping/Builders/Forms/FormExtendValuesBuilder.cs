using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Forms;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Forms
{
    /// <summary>
    /// Represents a forum buil entity builder
    /// </summary>
    public partial class FormExtendValuesBuilder : NopEntityBuilder<FormExtendValues>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(FormExtendValues.Name)).AsString(128).NotNullable()
                .WithColumn(nameof(FormExtendValues.Value)).AsString(512).Nullable()
                .WithColumn(nameof(FormExtendValues.DefaultValue)).AsString(128).Nullable()
                .WithColumn(nameof(FormExtendValues.RegularExpression)).AsAnsiString(128).Nullable()

                .WithColumn(nameof(FormExtendValues.FormId)).AsInt32().ForeignKey<Form>()
                ;
        }

        #endregion

    }
}
