﻿using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.News;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// Represents a news item entity builder
    /// </summary>
    public partial class NewsItemBuilder : NopEntityBuilder<NewsItem>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsItem.Title)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(NewsItem.Short)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(NewsItem.Full)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(NewsItem.MetaKeywords)).AsString(400).Nullable()
                .WithColumn(nameof(NewsItem.MetaTitle)).AsString(400).Nullable()
                .WithColumn(nameof(NewsItem.LanguageId)).AsInt32().ForeignKey<Language>()

                //扩展
                .WithColumn(nameof(NewsItem.AuthorName)).AsString(32).Nullable()
                .WithColumn(nameof(NewsItem.PublisherArea)).AsString(32).Nullable()
                .WithColumn(nameof(NewsItem.PublisherIp)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(NewsItem.SubTitle)).AsString(512).Nullable()
                .WithColumn(nameof(NewsItem.SourceName)).AsString(64).Nullable()
                .WithColumn(nameof(NewsItem.SourceUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(NewsItem.StartDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(NewsItem.EndDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(NewsItem.UpdatedOnUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}