using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Data.Extensions;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// 场所码
    /// </summary>
    public partial class PlaceCodeBuilder : NopEntityBuilder<PlaceCode>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(PlaceCode.PlaceCodeId)).AsAnsiString(32).NotNullable()
                .WithColumn(nameof(PlaceCode.PlaceName)).AsString(64).Nullable()
                .WithColumn(nameof(PlaceCode.Province)).AsString(32).Nullable()
                .WithColumn(nameof(PlaceCode.City)).AsString(32).Nullable()
                .WithColumn(nameof(PlaceCode.County)).AsString(32).Nullable()
                .WithColumn(nameof(PlaceCode.PlaceAddress)).AsString(128).Nullable()
                .WithColumn(nameof(PlaceCode.PlaceImage)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(PlaceCode.PlaceTitle)).AsString(64).Nullable()
                .WithColumn(nameof(PlaceCode.PlaceDescription)).AsString(1024).Nullable()
                .WithColumn(nameof(PlaceCode.PlaceQrcodeUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(PlaceCode.ExpirationDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(PlaceCode.CustomerId)).AsInt32().ForeignKey<Customer>(onDelete: Rule.SetNull).Nullable()
                ;
        }

        #endregion
    }
}