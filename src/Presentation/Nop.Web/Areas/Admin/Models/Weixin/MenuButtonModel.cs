using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Core.Domain.Weixin;

namespace Nop.Web.Areas.Admin.Models.Weixin
{
    /// <summary>
    /// Represents a Menu Button Model
    /// </summary>
    public partial class MenuButtonModel : BaseNopEntityModel
    {
        public MenuButtonModel()
        {
            AvailableWMenus = new List<SelectListItem>();
            AvailableMenuButtonTypes = new List<SelectListItem>();
        }

        #region Properties

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.WMenuId")]
        public int WMenuId { get; set; }
        public IList<SelectListItem> AvailableWMenus { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.MenuButtonTypeId")]
        public int MenuButtonTypeId { get; set; }
        public string MenuButtonTypeNameString { get; set; }
        public IList<SelectListItem> AvailableMenuButtonTypes { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.ParentId")]
        public int ParentId { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.Value")]
        public string Value { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.Url")]
        public string Url { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.Key")]
        public string Key { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.MediaId")]
        public string MediaId { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.AppId")]
        public string AppId { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.PagePath")]
        public string PagePath { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.WAutoreplyNewsInfoIds")]
        public string WAutoreplyNewsInfoIds { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.RootButton")]
        public bool RootButton { get; set; }

        [NopResourceDisplayName("Admin.Weixin.MenuButtons.Fields.Published")]
        public bool Published { get; set; }

        #endregion
    }
}