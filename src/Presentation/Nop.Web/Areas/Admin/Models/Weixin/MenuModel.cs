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
    /// Represents a Menu Model
    /// </summary>
    public partial record MenuModel : BaseNopEntityModel
    {
        public MenuModel()
        {
            MenuButtonSearchModel = new MenuButtonSearchModel();
        }

        #region Properties

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.MenuId")]
        public long MenuId { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.SystemName")]
        public string SystemName { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.MenuJsonCode")]
        public string MenuJsonCode { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.TagId")]
        public string TagId { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.Sex")]
        public string Sex { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.ClientPlatformType")]
        public string ClientPlatformType { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.Country")]
        public string Country { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.Province")]
        public string Province { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.City")]
        public string City { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.LanguageTypeId")]
        public int LanguageTypeId { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.Status")]
        public int Status { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.PublishTime")]
        public int PublishTime { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.UnPublishTime")]
        public int UnPublishTime { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.DefaultMenu")]
        public bool DefaultMenu { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.IsMenuOpen")]
        public bool IsMenuOpen { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.Published")]
        public bool Published { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.Personal")]
        public bool Personal { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.Fields.Deleted")]
        public bool Deleted { get; set; }

        public MenuButtonSearchModel MenuButtonSearchModel { get; set; }

        #endregion
    }
}