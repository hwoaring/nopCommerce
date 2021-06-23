using FluentMigrator;
using Nop.Core.Domain.Directory;

namespace Nop.Data.Migrations.Indexes
{
    [NopMigration("2020/04/13 09:36:08:9057686")]
    public class AddDivisionsCodeAreaCodeIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_DivisionsCode_AreaCode").OnTable(nameof(DivisionsCode))
                .OnColumn(nameof(DivisionsCode.AreaCode)).Ascending()
                .WithOptions().NonClustered()
                ;
        }

        #endregion
    }
}