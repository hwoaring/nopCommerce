using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WxKeywordAutoreplyKeywordBuilder : NopEntityBuilder<WxKeywordAutoreplyKeyword>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxKeywordAutoreplyKeyword.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WxKeywordAutoreplyKeyword.Content)).AsString(32).NotNullable()
                ;
        }

        #endregion
    }
}
