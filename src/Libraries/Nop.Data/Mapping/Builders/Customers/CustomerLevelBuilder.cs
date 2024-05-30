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
/// 用户的全局等级
/// </summary>
public partial class CustomerLevelBuilder : NopEntityBuilder<CustomerLevel>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(CustomerLevel.CustomerId)).AsInt32().ForeignKey<Customer>()
            .WithColumn(nameof(CustomerLevel.ExpireTimeOnUtc)).AsDateTime2().Nullable()
            .WithColumn(nameof(CustomerLevel.UpgradeTimeOnUtc)).AsDateTime2().Nullable()

            ;
    }

    #endregion
}