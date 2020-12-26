using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface IUserSupplierVoucherCouponService
    {
        Task InsertEntityAsync(UserSupplierVoucherCoupon entity);

        Task DeleteEntityAsync(UserSupplierVoucherCoupon entity);

        Task DeleteEntitiesAsync(IList<UserSupplierVoucherCoupon> entities);

        Task UpdateEntityAsync(UserSupplierVoucherCoupon entity);

    }
}