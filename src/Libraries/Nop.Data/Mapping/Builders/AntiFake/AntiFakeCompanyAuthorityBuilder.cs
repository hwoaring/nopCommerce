using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake;

/// <summary>
/// Represents a affiliate entity builder
/// </summary>
public partial class AntiFakeCompanyAuthorityBuilder : NopEntityBuilder<AntiFakeCompanyAuthority>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(AntiFakeCompanyAuthority.CustomerId)).AsInt32().ForeignKey<Customer>()
            .WithColumn(nameof(AntiFakeCompanyAuthority.AntiFakeCompanyId)).AsInt32().ForeignKey<AntiFakeCompany>()

            ;
    }

    #endregion
}
