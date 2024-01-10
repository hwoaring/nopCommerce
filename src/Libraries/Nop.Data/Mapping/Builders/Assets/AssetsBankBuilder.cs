using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Assets;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Assets
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AssetsBankBuilder : NopEntityBuilder<AssetsBank>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AssetsBank.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(AssetsBank.SimpleCode)).AsAnsiString(64).NotNullable()
                ;
        }

        #endregion
 
    }
}
