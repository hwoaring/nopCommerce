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
    public partial interface IDivisionsCodeChinaService
    {
        Task InsertEntityAsync(DivisionsCodeChina entity);

        Task DeleteEntityAsync(DivisionsCodeChina entity);

        Task DeleteEntitiesAsync(IList<DivisionsCodeChina> entities);

        Task UpdateEntityAsync(DivisionsCodeChina entity);

        Task UpdateEntitiesAsync(IList<DivisionsCodeChina> entities);

        Task<DivisionsCodeChina> GetEntityByIdAsync(int id);

        Task<DivisionsCodeChina> GetEntityByAreaCodeAsync(string areaCode);

        Task<IList<DivisionsCodeChina>> GetEntitiesByAreaCodeAsync(string areaCode, int areaLevel); //通过areaLevel，切分不同长度的areaCode进行contain查找

        Task<List<DivisionsCodeChina>> GetEntitiesByProductIdAsync(int productId, int top = 1, bool asc = true);

        Task<IList<DivisionsCodeChina>> GetEntitiesBySupplierVoucherCouponIdAsync(int supplierVoucherCouponId, int top = 1, bool asc = true);


        Task<IPagedList<DivisionsCodeChina>> GetEntitiesAsync(
            string areaCode = "",
            string areaName = "",
            int areaLevel = 0,
            bool? published = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}