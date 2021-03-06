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
    /// WUserTag Service
    /// </summary>
    public partial class WUserTagService : IWUserTagService
    {
        #region Fields

        private readonly IRepository<WUserTag> _wUserTagRepository;

        #endregion

        #region Ctor

        public WUserTagService(
            IRepository<WUserTag> wUserTagRepository)
        {
            _wUserTagRepository = wUserTagRepository;
        }

        #endregion

        #region Methods

        public virtual void InsertWUserTag(WUserTag userTag)
        {
            _wUserTagRepository.Insert(userTag);
        }

        public virtual void DeleteWUserTag(WUserTag userTag, bool delete = false)
        {
            if (userTag == null)
                throw new ArgumentNullException(nameof(userTag));

            if(delete)
            {
                _wUserTagRepository.Delete(userTag);
            }
            else
            {
                userTag.Deleted = true;
                _wUserTagRepository.Update(userTag);
            }
        }

        public virtual void DeleteWUserTags(IList<WUserTag> userTags, bool deleted = false)
        {
            if (userTags == null)
                throw new ArgumentNullException(nameof(userTags));

            if(deleted)
            {
                //delete wUser
                _wUserTagRepository.Delete(userTags);
            }
            else
            {
                foreach (var userTag in userTags)
                {
                    userTag.Deleted = true;
                }

                _wUserTagRepository.Update(userTags);
            }
        }

        public virtual void UpdateWUserTag(WUserTag userTag)
        {
            _wUserTagRepository.Update(userTag);
        }

        public virtual void UpdateWUserTags(IList<WUserTag> userTags)
        {
            _wUserTagRepository.Update(userTags);
        }

        public virtual WUserTag GetWUserTagById(int id)
        {
            return _wUserTagRepository.GetById(id, cache => default);
        }

        public virtual WUserTag GetWUserTagByOfficialId(int officialId, int? configId = null)
        {
            if (officialId == 0)
                return null;

            var query = _wUserTagRepository.Table;

            query = query.Where(v => v.OfficialId == officialId);

            if (configId.HasValue)
                query = query.Where(v => v.WConfigId == configId);

            return query.FirstOrDefault();
        }

        public virtual List<WUserTag> GetWUserTagsByOfficialIds(int[] officialIds, int? configId = null)
        {
            if (officialIds is null)
                throw new ArgumentNullException(nameof(officialIds));

            var query = _wUserTagRepository.Table;

            query = query.Where(v => officialIds.Contains(v.OfficialId));

            if (configId.HasValue)
                query = query.Where(v => v.WConfigId == configId);

            query = query.OrderBy(v => v.UpdateTime).ThenBy(v => v.Id);

            return query.ToList();
        }

        public virtual IPagedList<WUserTag> GetWUserTags(int? configId = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false)
        {
            var query = _wUserTagRepository.Table;

            if (configId.HasValue)
                query = query.Where(v => v.WConfigId == configId);

            query = query.OrderBy(v => v.UpdateTime).ThenBy(v => v.Id);

            return new PagedList<WUserTag>(query, pageIndex, pageSize);
        }

        #endregion
    }
}