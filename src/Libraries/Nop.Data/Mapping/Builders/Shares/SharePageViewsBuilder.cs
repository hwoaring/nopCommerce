using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shares;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Shares
{
    /// <summary>
    /// 广告阅读详情统计
    /// </summary>
    public partial class SharePageViewsBuilder : NopEntityBuilder<SharePageViews>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SharePageViews.SharePageRecordsId)).AsInt32().ForeignKey<SharePageRecords>()
                .WithColumn(nameof(SharePageViews.CustomerId)).AsInt32().ForeignKey<Customer>()
                ;
        }

        #endregion
    }
}