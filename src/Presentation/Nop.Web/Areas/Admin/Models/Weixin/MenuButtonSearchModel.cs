using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Weixin
{
    /// <summary>
    /// Represents a Menu Button Search Model
    /// </summary>
    public partial record MenuButtonSearchModel : BaseSearchModel
    {

        #region Properties

        public int MenuId { get; set; }

        #endregion
    }
}