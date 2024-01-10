using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Publics;

namespace Nop.Data.Mapping.Builders.Publics
{
    /// <summary>
    /// 公共标签
    /// </summary>
    public partial class PublicTagBuilder : NopEntityBuilder<PublicTag>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(PublicTag.Name)).AsString(32).NotNullable();
        }

        #endregion
    }
}