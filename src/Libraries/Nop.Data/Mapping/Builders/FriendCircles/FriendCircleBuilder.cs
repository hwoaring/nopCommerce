using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.FriendCircles;
using Nop.Data.Extensions;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Brands;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Builders.FriendCircles
{
    /// <summary>
    /// 朋友圈
    /// </summary>
    public partial class FriendCircleBuilder : NopEntityBuilder<FriendCircle>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(FriendCircle.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(FriendCircle.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(FriendCircle.ProductId)).AsInt32().ForeignKey<Product>()
                .WithColumn(nameof(FriendCircle.Content)).AsString(1024).Nullable()  //避免攻击
                .WithColumn(nameof(FriendCircle.PublisherIp)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(FriendCircle.ExternalVideoUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(FriendCircle.Latitude)).AsDecimal(9,6).Nullable()
                .WithColumn(nameof(FriendCircle.Longitude)).AsDecimal(9, 6).Nullable()
                ;
        }

        #endregion
    }
}