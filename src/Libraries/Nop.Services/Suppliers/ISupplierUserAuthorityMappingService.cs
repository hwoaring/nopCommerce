using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface ISupplierUserAuthorityMappingService
    {
        Task InsertEntityAsync(SupplierUserAuthorityMapping entity);

        Task DeleteEntityAsync(SupplierUserAuthorityMapping entity);

        Task DeleteEntitiesAsync(IList<SupplierUserAuthorityMapping> entities);

        Task UpdateEntityAsync(SupplierUserAuthorityMapping entity);

        Task UpdateEntitiesAsync(IList<SupplierUserAuthorityMapping> entities);

        Task<SupplierUserAuthorityMapping> GetEntityByIdAsync(int id);

        Task<SupplierUserAuthorityMapping> GetEntityByUserIdAsync(int userId);

        Task<IList<SupplierUserAuthorityMapping>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IList<SupplierUserAuthorityMapping>> GetEntitiesBySupplierIdAsync(int supplierId, int supplierShopId = 0);

        Task<IPagedList<SupplierUserAuthorityMapping>> GetEntitiesAsync(
            int supplierId = 0,
            int supplierShopId = 0,
            bool? financialManager = null,
            bool? verifyManager = null,
            bool? orderConfirmer = null,
            bool? productPulisher = null,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}