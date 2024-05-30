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
/// 用户等级设置
/// </summary>
public partial class CustomerLevelSettingBuilder : NopEntityBuilder<CustomerLevelSetting>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(CustomerLevelSetting.Name)).AsString(128).NotNullable()
            .WithColumn(nameof(CustomerLevelSetting.SystemName)).AsString(128).Nullable()

            ;
    }

    #endregion
}