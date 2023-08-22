using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a 代理商自定义类别
    /// </summary>
    public partial class VendorCategoryBuilder : NopEntityBuilder<VendorCategory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorCategory.Name)).AsString(16).NotNullable()
                .WithColumn(nameof(VendorCategory.Description)).AsString(1024).Nullable()
                .WithColumn(nameof(VendorCategory.MetaTitle)).AsString(128).Nullable()
                .WithColumn(nameof(VendorCategory.MetaKeywords )).AsString(512).Nullable()
                .WithColumn(nameof(VendorCategory.MetaDescription)).AsString(1024).Nullable()
                .WithColumn(nameof(VendorCategory.VendorId)).AsInt32().ForeignKey<Vendor>();
        }

        #endregion
    }
}