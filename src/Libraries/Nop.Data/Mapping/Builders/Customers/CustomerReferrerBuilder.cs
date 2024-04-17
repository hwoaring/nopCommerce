using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Customers;

/// <summary>
/// 不同StoreId下的推荐人信息
/// </summary>
public partial class CustomerReferrerBuilder : NopEntityBuilder<CustomerReferrer>
{
    #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(CustomerReferrer.ReferreredInStoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(CustomerReferrer.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(CustomerReferrer.TempReferrerExpireDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(CustomerReferrer.ReferrerSceneStr)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(CustomerReferrer.FirstReferrerPageUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(CustomerReferrer.ReferrerHistory)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(CustomerReferrer.Remark)).AsString(64).Nullable()
                ;
        }

    #endregion
}