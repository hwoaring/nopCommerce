using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Marketing;

namespace Nop.Services.Marketing
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface IPromotionCommissionService
    {
        Task InsertEntityAsync(PromotionCommission entity);

        Task DeleteEntityAsync(PromotionCommission entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<PromotionCommission> entities, bool deleted = false);

        Task UpdateEntityAsync(PromotionCommission entity);

        Task UpdateEntitiesAsync(IList<PromotionCommission> entities);

        Task<PromotionCommission> GetEntityByIdAsync(int id);

        Task<PromotionCommission> GetEntitiesByProductIdAsync(int productId, int productAttributeValueId = 0);

        Task<IList<PromotionCommission>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<PromotionCommission>> GetEntitiesAsync(
            int productId = 0,
            int productAttributeValueId = 0,
            bool? usePercentage = null,
            DateTime? startDateTimeUtc = null,
            DateTime? endDateTimeUtc = null,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);

    }
}