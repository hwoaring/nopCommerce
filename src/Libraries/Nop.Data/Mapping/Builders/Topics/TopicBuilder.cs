using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Topics;

namespace Nop.Data.Mapping.Builders.Topics
{
    /// <summary>
    /// Represents a topic template entity builder
    /// </summary>
    public partial class TopicBuilder : NopEntityBuilder<Topic>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Topic.ImageUrl)).AsString(1024).Nullable()
                .WithColumn(nameof(Topic.VideoUrl)).AsString(1024).Nullable()
                .WithColumn(nameof(Topic.MetaImageUrl)).AsString(1024).Nullable()
                .WithColumn(nameof(Topic.MetaLinkUrl)).AsString(1024).Nullable()
                .WithColumn(nameof(Topic.ShareImageUrl)).AsString(1024).Nullable()
                .WithColumn(nameof(Topic.Source)).AsString(512).Nullable()
                .WithColumn(nameof(Topic.Author)).AsString(512).Nullable()
                .WithColumn(nameof(Topic.StartDateTimeUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(Topic.EndDateTimeUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(Topic.UpdateDateTimeUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}