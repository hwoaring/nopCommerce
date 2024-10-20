﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual void InsertEntity(ProductAdvertImage productAdvertImage)
        {
            if (productAdvertImage == null)
                throw new ArgumentNullException(nameof(productAdvertImage));

            _productAdvertImageRepository.Insert(productAdvertImage);

        }

        public virtual void DeleteEntity(ProductAdvertImage productAdvertImage, bool delete = false)
        {
            if (productAdvertImage == null)
                throw new ArgumentNullException(nameof(productAdvertImage));

            if (delete)
            {
                _productAdvertImageRepository.Delete(productAdvertImage);
            }
            else
            {
                productAdvertImage.Deleted = true;
                _productAdvertImageRepository.Update(productAdvertImage);
            }
        }

        public virtual void DeleteEntities(IList<ProductAdvertImage> productAdvertImages, bool deleted = false)
        {
            if (productAdvertImages == null)
                throw new ArgumentNullException(nameof(productAdvertImages));

            if (deleted)
            {
                _productAdvertImageRepository.Delete(productAdvertImages);
            }
            else
            {
                foreach (var productAdvertImage in productAdvertImages)
                {
                    productAdvertImage.Deleted = true;
                }
                _productAdvertImageRepository.Update(productAdvertImages);
            }
        }

        public virtual void UpdateEntity(ProductAdvertImage productAdvertImage)
        {
            _productAdvertImageRepository.Update(productAdvertImage);
        }

        public virtual void UpdateEntities(IList<ProductAdvertImage> productAdvertImages)
        {
            //update
            _productAdvertImageRepository.Update(productAdvertImages);
        }

        public virtual ProductAdvertImage GetEntityById(int id)
        {
            return _productAdvertImageRepository.GetById(id, cache => default);
        }

        public virtual List<ProductAdvertImage> GetEntitiesByIds(int[] entityIds)
        {
            if (entityIds is null)
                return new List<ProductAdvertImage>();

            var query = from t in _productAdvertImageRepository.Table
                        where entityIds.Contains(t.Id) &&
                        !t.Deleted &&
                        t.Published
                        select t;

            return query.ToList();
        }

        public virtual List<ProductAdvertImage> GetEntitiesByProductId(int productId, int top = 1, bool asc = true)
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

            return query.ToList();
        }

        public virtual List<ProductAdvertImage> GetEntitiesBySupplierVoucherCouponId(int supplierVoucherCouponId, int top = 1, bool asc = true)
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

            return query.ToList();
        }


        public virtual IPagedList<ProductAdvertImage> GetEntities(
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

            return new PagedList<ProductAdvertImage>(query, pageIndex, pageSize);
        }


  

        #endregion
    }
}