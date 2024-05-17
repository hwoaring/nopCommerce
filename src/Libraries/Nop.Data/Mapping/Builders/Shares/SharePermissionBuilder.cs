using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Shares;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Shares;

/// <summary>
/// Represents a news item entity builder
/// </summary>
public partial class SharePermissionBuilder : NopEntityBuilder<SharePermission>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(SharePermission.ProductId)).AsInt32().ForeignKey<Product>()
            ;
    }

    #endregion
}