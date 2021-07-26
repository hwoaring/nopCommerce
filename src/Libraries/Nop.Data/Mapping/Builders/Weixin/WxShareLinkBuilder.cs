using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WxShareLinkBuilder : NopEntityBuilder<WxShareLink>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxShareLink.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(WxShareLink.LinkId)).AsAnsiString(8).NotNullable()
                .WithColumn(nameof(WxShareLink.Url)).AsString(1024).NotNullable()
                ;
        }

        #endregion
    }
}
