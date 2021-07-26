using FluentMigrator;
using Nop.Core.Domain.Weixin;

namespace Nop.Data.Migrations.Indexes
{
    [NopMigration("2020/04/13 09:36:08:9037684")]
    public class AddWxShareLinkLinkIdIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_AddWxShareLink_LinkId").OnTable(nameof(WxShareLink))
                .OnColumn(nameof(WxShareLink.LinkId)).Ascending()
                .OnColumn(nameof(WxShareLink.Deleted)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}