using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface ISupplierVoucherCouponAppliedValueService
    {
        Task InsertEntityAsync(SupplierVoucherCouponAppliedValue entity);

        Task DeleteEntityAsync(SupplierVoucherCouponAppliedValue entity);

        Task DeleteEntitiesAsync(IList<SupplierVoucherCouponAppliedValue> entities);

        Task UpdateEntityAsync(SupplierVoucherCouponAppliedValue entity);

        Task UpdateEntitiesAsync(IList<SupplierVoucherCouponAppliedValue> entities);

        Task<SupplierVoucherCouponAppliedValue> GetEntityByIdAsync(int id);
    }
}