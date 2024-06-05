using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SMS;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SMS
{
    /// <summary>
    /// 黑名单或短信退订的用户
    /// </summary>
    public partial class SmsSendBlackListBuilder : NopEntityBuilder<SmsSendBlackList>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SmsSendBlackList.VendorId)).AsInt32().ForeignKey<Vendor>()
                .WithColumn(nameof(SmsSendBlackList.PhoneNumber)).AsAnsiString(32).NotNullable()

                ;
        }

        #endregion

   
    }
}
