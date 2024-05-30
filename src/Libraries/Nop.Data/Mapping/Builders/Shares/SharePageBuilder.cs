using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Shares;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Shares;

/// <summary>
/// Represents a news item entity builder
/// </summary>
public partial class SharePageBuilder : NopEntityBuilder<SharePage>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(SharePage.MediaId)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(SharePage.ThumbMediaId)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(SharePage.Title)).AsString(128).Nullable()
            .WithColumn(nameof(SharePage.Slogan)).AsString(128).Nullable()
            .WithColumn(nameof(SharePage.Description)).AsString(1024).Nullable()
            .WithColumn(nameof(SharePage.PromotionText)).AsString(512).Nullable()
            .WithColumn(nameof(SharePage.Url)).AsAnsiString(1024).Nullable()

            ;
    }

    #endregion
}