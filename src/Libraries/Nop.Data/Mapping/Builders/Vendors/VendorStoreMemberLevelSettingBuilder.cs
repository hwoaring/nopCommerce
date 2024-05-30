using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStoreMemberLevelSettingBuilder : NopEntityBuilder<VendorStoreMemberLevelSetting>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStoreMemberLevelSetting.VendorStoreId)).AsInt32().ForeignKey<VendorStore>()
            .WithColumn(nameof(VendorStoreMemberLevelSetting.Name)).AsString(64).NotNullable()
            .WithColumn(nameof(VendorStoreMemberLevelSetting.Description)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStoreMemberLevelSetting.Content)).AsString(4000).Nullable()
            .WithColumn(nameof(VendorStoreMemberLevelSetting.SystemName)).AsString(64).Nullable()

            ;
    }

    #endregion

}