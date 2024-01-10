using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Forms;

using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Forms
{
    /// <summary>
    /// Represents a forum buil entity builder
    /// </summary>
    public partial class FormRecordBuilder : NopEntityBuilder<FormRecord>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(FormRecord.Name)).AsString(64).Nullable()
                .WithColumn(nameof(FormRecord.Phone)).AsString(32).Nullable()
                .WithColumn(nameof(FormRecord.Address)).AsString(128).Nullable()
                .WithColumn(nameof(FormRecord.Remark)).AsString(64).Nullable()
                .WithColumn(nameof(FormRecord.SystemRemark)).AsString(128).Nullable()
                .WithColumn(nameof(FormRecord.ExtendValues)).AsString(1024).Nullable()

                .WithColumn(nameof(FormRecord.FormId)).AsInt32().ForeignKey<Form>()
                ;
        }

        #endregion

    }
}
