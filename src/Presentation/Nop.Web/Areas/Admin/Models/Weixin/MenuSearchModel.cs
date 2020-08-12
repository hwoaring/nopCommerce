using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Weixin
{
    /// <summary>
    /// Represents a Menu Search Model
    /// </summary>
    public partial class MenuSearchModel : BaseSearchModel
    {
        #region Ctor

        public MenuSearchModel()
        {
            AvailablePersonals = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Weixin.Menus.List.SearchSystemName")]
        public string SearchSystemName { get; set; }

        [NopResourceDisplayName("Admin.Weixin.Menus.List.Personal")]
        public int SeletedPersonalId { get; set; }
        public IList<SelectListItem> AvailablePersonals { get; set; }

        #endregion
    }
}