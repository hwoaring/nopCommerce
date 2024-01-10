using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

using Nop.Core.Domain.Stores;

namespace Nop.Data.Mapping.Builders.Media
{
    /// <summary>
    /// 媒体服务器
    /// </summary>
    public partial class MediaServerBuilder : NopEntityBuilder<MediaServer>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(MediaServer.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(MediaServer.DomainName)).AsAnsiString(128).NotNullable()
                .WithColumn(nameof(MediaServer.IpAddress)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(MediaServer.Account)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(MediaServer.Password)).AsAnsiString(64).Nullable()
                
                ;
        }

        #endregion
    }
}