using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.News;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// Represents a Vendor Store 模板 entity builder
    /// </summary>
    public partial class NewsTemplateBuilder : NopEntityBuilder<NewsTemplate>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsTemplate.Name)).AsString(400).NotNullable()
                .WithColumn(nameof(NewsTemplate.ViewPath)).AsString(512).NotNullable();
        }

        #endregion
    }
}