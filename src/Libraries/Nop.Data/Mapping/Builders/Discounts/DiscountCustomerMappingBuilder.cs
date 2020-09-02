using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Discounts
{
    /// <summary>
    /// Represents a DiscountCustomerMapping entity builder
    /// </summary>
    public partial class DiscountCustomerMappingBuilder : NopEntityBuilder<DiscountCustomerMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(DiscountCustomerMapping.DiscountId)).AsInt32().ForeignKey<Discount>()
                .WithColumn(nameof(DiscountCustomerMapping.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(DiscountCustomerMapping.CouponCode)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(DiscountCustomerMapping.SceneDescription)).AsString(512).Nullable()
                .WithColumn(nameof(DiscountCustomerMapping.EndDateUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}