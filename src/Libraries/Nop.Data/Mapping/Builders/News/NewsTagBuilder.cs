using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.News;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// 新闻标签
    /// </summary>
    public partial class NewsTagBuilder : NopEntityBuilder<NewsTag>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(NewsTag.Name)).AsString(32).NotNullable();
        }

        #endregion
    }
}