using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Weixin
{
    /// <summary>
    /// Represents a user search model
    /// </summary>
    public partial record QrCodeLimitSearchModel : BaseSearchModel
    {
        #region Ctor

        public QrCodeLimitSearchModel()
        {
            AvailableCategories = new List<SelectListItem>();
            AvailableChannels = new List<SelectListItem>();
            AvailableFixedUseOptions = new List<SelectListItem>();
            AvailableHasCreatedOptions = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.List.WConfigId")]
        public int WConfigId { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.List.WQrCodeCategoryId")]
        public int WQrCodeCategoryId { get; set; }
        public IList<SelectListItem> AvailableCategories { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.List.WQrCodeChannelId")]
        public int WQrCodeChannelId { get; set; }
        public IList<SelectListItem> AvailableChannels { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.List.SearchSysName")]
        public string SearchSysName { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.List.SearchFixedUse")]
        public int SearchFixedUse { get; set; }
        public IList<SelectListItem> AvailableFixedUseOptions { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.List.SearchHasCreated")]
        public int SearchHasCreated { get; set; }
        public IList<SelectListItem> AvailableHasCreatedOptions { get; set; }

        #endregion
    }
}