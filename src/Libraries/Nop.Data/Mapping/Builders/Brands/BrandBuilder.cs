using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Brands;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Brands
{
    /// <summary>
    /// 品牌商标
    /// </summary>
    public partial class BrandBuilder : NopEntityBuilder<Brand>
    {
        #region Methods

        /// <summary>
        /// 商标
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Brand.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(Brand.LongCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(Brand.Code)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(Brand.Company)).AsString(128).Nullable()
                .WithColumn(nameof(Brand.InternationalText)).AsString(1024).Nullable()
                .WithColumn(nameof(Brand.MetaTitle)).AsString(512).Nullable()
                .WithColumn(nameof(Brand.MetaKeywords)).AsString(512).Nullable()
                .WithColumn(nameof(Brand.MetaDescription)).AsString(1024).Nullable()
                .WithColumn(nameof(Brand.AuthorizationExpireDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(Brand.ExpireDateUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}