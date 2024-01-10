using System.Data;
using FluentMigrator.Builders.Create.Table;

using Nop.Core.Domain.AntiFake;
using Nop.Core.Domain.Common;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AntiFakeCoverCodeBuilder : NopEntityBuilder<AntiFakeCoverCode>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AntiFakeCoverCode.AntiFakeProductId)).AsInt32().ForeignKey<AntiFakeProduct>()
                .WithColumn(nameof(AntiFakeCoverCode.BindDateUtc)).AsDateTime2().Nullable()

                ;
        }

        #endregion

    }
}
