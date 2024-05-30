using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStorePictureBuilder : NopEntityBuilder<VendorStorePicture>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStorePicture.VendorStoreId)).AsInt32().ForeignKey<VendorStore>()
            .WithColumn(nameof(VendorStorePicture.PictureId)).AsInt32().ForeignKey<Picture>()
            .WithColumn(nameof(VendorStorePicture.Discription)).AsString(64).Nullable()

            ;
    }

    #endregion

}
