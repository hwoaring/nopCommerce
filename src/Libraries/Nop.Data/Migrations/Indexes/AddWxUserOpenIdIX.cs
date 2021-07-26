using FluentMigrator;
using FluentMigrator.SqlServer;
using Nop.Core.Domain.Weixin;

namespace Nop.Data.Migrations.Indexes
{
    [NopMigration("2020/04/13 09:36:08:9037685")]
    public class AddWxUserOpenIdIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_AddWxUser_OpenId").OnTable(nameof(WxUser))
                .OnColumn(nameof(WxUser.OpenId)).Ascending()
                .WithOptions().NonClustered()
                
                ;
        }

        #endregion
    }
}