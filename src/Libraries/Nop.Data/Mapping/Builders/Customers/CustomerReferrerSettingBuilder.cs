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
/// 不同StoreId下的推荐人设置
/// </summary>
public partial class CustomerReferrerSettingBuilder : NopEntityBuilder<CustomerReferrerSetting>
{
    #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(CustomerReferrerSetting.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(CustomerReferrerSetting.CustomerId)).AsInt32().ForeignKey<Customer>()
                ;
        }

    #endregion
}