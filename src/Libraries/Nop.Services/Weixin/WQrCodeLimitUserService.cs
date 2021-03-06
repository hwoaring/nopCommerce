﻿using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Weixin;
using Nop.Core.Html;
using Nop.Data;
using Nop.Services.Events;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeLimitUser Service
    /// </summary>
    public partial class WQrCodeLimitUserService : IWQrCodeLimitUserService
    {
        #region Fields

        private readonly IRepository<WUser> _wUserRepository;
        private readonly IRepository<WQrCodeLimit> _wQrCodeLimitRepository;
        private readonly IRepository<WQrCodeLimitUserMapping> _wQrCodeLimitUserMappingRepository;

        #endregion

        #region Ctor

        public WQrCodeLimitUserService(
            IRepository<WUser> wUserRepository,
            IRepository<WQrCodeLimit> wQrCodeLimitRepository,
            IRepository<WQrCodeLimitUserMapping> wQrCodeLimitUserMappingRepository)
        {
            _wUserRepository = wUserRepository;
            _wQrCodeLimitRepository = wQrCodeLimitRepository;
            _wQrCodeLimitUserMappingRepository = wQrCodeLimitUserMappingRepository;
        }

        #endregion

        #region Methods

        public virtual void InsertEntity(WQrCodeLimitUserMapping entity)
        {
            _wQrCodeLimitUserMappingRepository.Insert(entity);
        }

        public virtual void DeleteEntity(WQrCodeLimitUserMapping entity)
        {
            _wQrCodeLimitUserMappingRepository.Delete(entity);
        }

        public virtual void DeleteEntities(IList<WQrCodeLimitUserMapping> entities)
        {
            _wQrCodeLimitUserMappingRepository.Delete(entities);
        }

        public virtual void UpdateEntity(WQrCodeLimitUserMapping entity)
        {
            _wQrCodeLimitUserMappingRepository.Update(entity);
        }

        public virtual void UpdateEntities(IList<WQrCodeLimitUserMapping> entities)
        {
            _wQrCodeLimitUserMappingRepository.Update(entities);
        }

        public virtual WQrCodeLimitUserMapping GetEntityById(int id)
        {
            return _wQrCodeLimitUserMappingRepository.GetById(id, cache => default);
        }

        public virtual WQrCodeLimitUserMapping GetActiveEntityByQrCodeLimitIdOrUserId(int qrCodeLimitId, int userId)
        {
            if (qrCodeLimitId == 0 && userId == 0)
                return null;

            var query = _wQrCodeLimitUserMappingRepository.Table;
            query = query.Where(t => t.Published);
            query = query.Where(t => t.ExpireTime > DateTime.Now);
            if (qrCodeLimitId > 0)
            {
                query = query.Where(t => t.QrCodeLimitId == qrCodeLimitId);
            } 
            if (userId > 0)
            {
                query = query.Where(t => t.UserId == userId);
            }

            return query.FirstOrDefault();
        }

        public virtual WQrCodeLimitUserMapping GetEntityByQrCodeLimitIdAndUserId(int qrCodeLimitId, int userId)
        {
            if (qrCodeLimitId == 0 || userId == 0)
                return null;

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where t.QrCodeLimitId == qrCodeLimitId &&
                        t.UserId == userId
                        select t;

            return query.FirstOrDefault();
        }

        public virtual List<WQrCodeLimitUserMapping> GetEntitiesByQrcodeLimitId(int qrCodeLimitId)
        {
            if (qrCodeLimitId == 0)
                return new List<WQrCodeLimitUserMapping>();

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where t.QrCodeLimitId == qrCodeLimitId
                        select t;

            return query.ToList();
        }

        public virtual List<WQrCodeLimitUserMapping> GetEntitiesByUserId(int userId)
        {
            if (userId == 0)
                return new List<WQrCodeLimitUserMapping>();

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where t.UserId== userId
                        select t;

            return query.ToList();
        }

        public virtual List<WQrCodeLimitUserMapping> GetEntitiesByIds(int[] wEntityIds)
        {
            if (wEntityIds is null)
                return new List<WQrCodeLimitUserMapping>();

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where wEntityIds.Contains(t.Id)
                        select t;

            return query.ToList();
        }

        public virtual IPagedList<WQrCodeLimitUserMapping> GetEntities(
            int userId = 0,
            int qrCodeLimitId = 0,
            DateTime? expireTime = null,
            bool? published = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wQrCodeLimitUserMappingRepository.Table;

            if (userId > 0)
                query = query.Where(v => v.UserId == userId);
            if (qrCodeLimitId > 0)
                query = query.Where(v => v.QrCodeLimitId == qrCodeLimitId);
            if (expireTime.HasValue)
            {
                query = query.Where(v => v.ExpireTime >= expireTime);
            }
            if (published.HasValue)
                query = query.Where(v => v.Published == published);

            query = query.OrderBy(v => v.Id);

            return new PagedList<WQrCodeLimitUserMapping>(query, pageIndex, pageSize);
        }


        #endregion
    }
}