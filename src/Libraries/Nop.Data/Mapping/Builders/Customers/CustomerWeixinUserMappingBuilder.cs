using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Customers
{
    /// <summary>
    /// Represents a customer 微信用户 mapping entity builder
    /// </summary>
    public partial class CustomerWeixinUserMappingBuilder : NopEntityBuilder<CustomerWeixinUserMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(CustomerWeixinUserMapping), nameof(CustomerWeixinUserMapping.WeixinUserId)))
                    .AsInt32().ForeignKey<WeixinUser>().PrimaryKey()
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(CustomerWeixinUserMapping), nameof(CustomerWeixinUserMapping.CustomerId)))
                    .AsInt32().ForeignKey<Customer>().PrimaryKey();
        }

        #endregion
    }
}