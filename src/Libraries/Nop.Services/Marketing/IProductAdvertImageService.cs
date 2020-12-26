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
    public partial interface IProductActivitiesThemeMappingService
    {
        Task InsertEntityAsync(ProductActivitiesThemeMapping entity);

        Task DeleteEntityAsync(ProductActivitiesThemeMapping entity);

        Task DeleteEntitiesAsync(IList<ProductActivitiesThemeMapping> entities);

        Task UpdateEntityAsync(ProductActivitiesThemeMapping entity);

        Task UpdateEntitiesAsync(IList<ProductActivitiesThemeMapping> entities);

        Task<ProductActivitiesThemeMapping> GetEntityByIdAsync(int productId, int activitiesThemeId);

        Task<IList<ProductActivitiesThemeMapping>> GetEntitiesByProductIdAsync(int productId);

        Task<IList<ProductActivitiesThemeMapping>> GetEntitiesByActivitiesThemeIdAsync(int activitiesThemeId);

        Task<IPagedList<ProductActivitiesThemeMapping>> GetEntitiesAsync(
            int productId = 0,
            int activitiesThemeId = 0,
            bool? published = null,
            int pageIndex = 0, int pageSize = int.MaxValue);


    }
}