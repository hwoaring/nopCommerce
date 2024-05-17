using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Shares;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Mapping.Builders.Shares;

/// <summary>
/// Represents a product picture entity builder
/// </summary>
public partial class ShareProductApplyBuilder : NopEntityBuilder<ShareProductApply>
{
    #region Methods

    /// <summary>
    /// 分享设置图片映射
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ShareProductApply.CustomerId)).AsInt32().ForeignKey<Customer>()
            .WithColumn(nameof(ShareProductApply.Name)).AsString(32).NotNullable()
            .WithColumn(nameof(ShareProductApply.PhoneNumber)).AsAnsiString(32).NotNullable()
            .WithColumn(nameof(ShareProductApply.ProductName)).AsString(64).NotNullable()
            .WithColumn(nameof(ShareProductApply.ProductDescription)).AsString(512).Nullable()
            .WithColumn(nameof(ShareProductApply.ReplyContent)).AsString(512).Nullable()
            .WithColumn(nameof(ShareProductApply.ReplyOnUtc)).AsDateTime2().Nullable()

            ;
    }

    #endregion
}