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
    public partial interface IActivitiesThemeService
    {
        Task InsertEntityAsync(ActivitiesTheme entity);

        Task DeleteEntityAsync(ActivitiesTheme entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<ActivitiesTheme> entities, bool delete = false);

        Task UpdateEntityAsync(ActivitiesTheme entity);

        Task UpdateEntitiesAsync(IList<ActivitiesTheme> entities);

        Task<ActivitiesTheme> GetEntityByIdAsync(int id);

        Task<IPagedList<ActivitiesTheme>> GetEntitiesAsync(
            string title = "",
            int customerRoleId = 0,
            int storeId = 0,
            DateTime? startDateTimeUtc = null,
            DateTime? endDateTimeUtc = null,
            bool? sysActivities = null,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}