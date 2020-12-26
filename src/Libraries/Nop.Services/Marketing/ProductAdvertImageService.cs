using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Marketing;
using Nop.Core.Domain.Suppliers;
using Nop.Core.Html;
using Nop.Data;
using Nop.Services.Events;

namespace Nop.Services.Marketing
{
    /// <summary>
    /// WConfig Service
    /// </summary>
    public partial class ProductAdvertImageService : IProductAdvertImageService
    {
        #region Fields

        private readonly IRepository<ProductAdvertImage> _productAdvertImageRepository;

        #endregion

        #region Ctor

        public ProductAdvertImageService(IRepository<ProductAdvertImage> productAdvertImageRepository)
        {
            _productAdvertImageRepository = productAdvertImageRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(ProductAdvertImage productAdvertImage)
        {
            await _productAdvertImageRepository.InsertAsync(productAdvertImage);

        }

        public virtual async Task DeleteEntityAsync(ProductAdvertImage productAdvertImage)
        {
            await _productAdvertImageRepository.DeleteAsync(productAdvertImage);
        }

        public virtual async Task DeleteEntitiesAsync(IList<ProductAdvertImage> productAdvertImages)
        {
            await _productAdvertImageRepository.DeleteAsync(productAdvertImages);
        }

        public virtual async Task UpdateEntityAsync(ProductAdvertImage productAdvertImage)
        {
            await _productAdvertImageRepository.UpdateAsync(productAdvertImage);
        }

        public virtual async Task UpdateEntitiesAsync(IList<ProductAdvertImage> productAdvertImages)
        {
            await _productAdvertImageRepository.UpdateAsync(productAdvertImages);
        }

        public virtual async Task<ProductAdvertImage> GetEntityByIdAsync(int id)
        {
            return await _productAdvertImageRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<ProductAdvertImage>> GetEntitiesByIdsAsync(int[] entityIds)
        {
            return await _productAdvertImageRepository.GetByIdsAsync(entityIds, cache => default);
        }

        public virtual async Task<IList<ProductAdvertImage>> GetEntitiesByProductIdAsync(int productId, int top = 1, bool asc = true)
        {
            if (productId <= 0)
                return new List<ProductAdvertImage>();

            var query = _productAdvertImageRepository.Table;
            query = query.Where(q => q.ProductId == productId);

            if (top < 1)
                top = 1;
            query = query.Take(top);

            if (asc)
                query = query.OrderBy(q => q.DisplayOrder);
            else
                query = query.OrderByDescending(q => q.DisplayOrder);

            return await query.ToListAsync();
        }

        public virtual async Task<IList<ProductAdvertImage>> GetEntitiesBySupplierVoucherCouponIdAsync(int supplierVoucherCouponId, int top = 1, bool asc = true)
        {
            if (supplierVoucherCouponId <= 0)
                return new List<ProductAdvertImage>();

            var query = _productAdvertImageRepository.Table;
            query = query.Where(q => q.SupplierVoucherCouponId == supplierVoucherCouponId);

            if (top < 1)
                top = 1;
            query = query.Take(top);

            if (asc)
                query = query.OrderBy(q => q.DisplayOrder);
            else
                query = query.OrderByDescending(q => q.DisplayOrder);

            return await query.ToListAsync();
        }


        public virtual async Task<IPagedList<ProductAdvertImage>> GetEntitiesAsync(
            string title = "",
            int productId = 0,
            bool? isDiscountAdver = null,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _productAdvertImageRepository.Table;

            if (productId > 0)
                query = query.Where(q => q.ProductId == productId);
            if (!string.IsNullOrEmpty(title))
                query = query.Where(q => q.Title.Contains(title));
            if (isDiscountAdver.HasValue)
                query = query.Where(q => q.IsDiscountAdver == isDiscountAdver);
            if (published.HasValue)
                query = query.Where(q => q.Published == published);
            if (deleted.HasValue)
                query = query.Where(q => q.Deleted == deleted);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }


  

        #endregion
    }
}