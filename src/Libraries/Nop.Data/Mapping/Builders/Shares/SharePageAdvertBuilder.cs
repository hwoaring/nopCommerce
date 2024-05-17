using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Shares;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Shares;

/// <summary>
/// Represents a news item entity builder
/// </summary>
public partial class SharePageAdvertBuilder : NopEntityBuilder<SharePageAdvert>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(SharePageAdvert.SharePageId)).AsInt32().ForeignKey<SharePage>()
            .WithColumn(nameof(SharePageAdvert.CustomerId)).AsInt32().ForeignKey<Customer>()
            .WithColumn(nameof(SharePageAdvert.PublishArea)).AsAnsiString(8000).Nullable()
            .WithColumn(nameof(SharePageAdvert.EndDateOnUtc)).AsDateTime2().Nullable()

            ;
    }

    #endregion
}