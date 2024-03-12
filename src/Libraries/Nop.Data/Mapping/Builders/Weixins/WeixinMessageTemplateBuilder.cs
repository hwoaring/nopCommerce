using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixins;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixins
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class WeixinMessageTemplateBuilder : NopEntityBuilder<WeixinMessageTemplate>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WeixinMessageTemplate.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WeixinMessageTemplate.TemplateId)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(WeixinMessageTemplate.Title)).AsString(64).NotNullable()
                .WithColumn(nameof(WeixinMessageTemplate.PrimaryIndustry)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinMessageTemplate.DeputyIndustry)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinMessageTemplate.Example)).AsString(512).Nullable()
                .WithColumn(nameof(WeixinMessageTemplate.Url)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(WeixinMessageTemplate.AppId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WeixinMessageTemplate.PagePath)).AsAnsiString(512).Nullable()
                ;
        }

        #endregion
    }
}