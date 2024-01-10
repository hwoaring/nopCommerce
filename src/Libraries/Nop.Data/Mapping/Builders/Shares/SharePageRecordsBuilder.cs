using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Shares;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Shares
{
    /// <summary>
    /// 广告费结算记录广告费结算记录
    /// </summary>
    public partial class SharePageRecordsBuilder : NopEntityBuilder<SharePageRecords>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SharePageRecords.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(SharePageRecords.BalanceDateUtc)).AsDateTime2().Nullable()

                ;
        }

        #endregion
    }
}