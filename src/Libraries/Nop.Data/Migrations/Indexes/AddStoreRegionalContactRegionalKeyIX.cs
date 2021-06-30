using FluentMigrator;
using Nop.Core.Domain.Stores;

namespace Nop.Data.Migrations.Indexes
{
    [NopMigration("2020/04/13 10:36:09:8057686")]
    public class AddStoreRegionalContactRegionalKeyIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_StoreRegionalContact_RegionalKey").OnTable(nameof(StoreRegionalContact))
                .OnColumn(nameof(StoreRegionalContact.RegionalKey)).Ascending()
                .WithOptions().NonClustered()
                ;
        }

        #endregion
    }
}