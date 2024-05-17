using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Shares;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Shares;

/// <summary>
/// 新闻标签映射
/// </summary>
public partial class SharePageSharePictureMappingBuilder : NopEntityBuilder<SharePageSharePictureMapping>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(SharePageSharePictureMapping.SharePageId)).AsInt32().ForeignKey<SharePage>()
            .WithColumn(nameof(SharePageSharePictureMapping.SharePictureId)).AsInt32().ForeignKey<SharePicture>()
            ;
    }

    #endregion
}