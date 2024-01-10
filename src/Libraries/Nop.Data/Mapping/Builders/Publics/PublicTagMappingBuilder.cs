using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Publics;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Publics
{
    /// <summary>
    /// 公共标签映射
    /// </summary>
    public partial class PublicTagMappingBuilder : NopEntityBuilder<PublicTagMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(PublicTagMapping.PublicTagId)).AsInt32().ForeignKey<PublicTag>()
                ;
        }

        #endregion
    }
}