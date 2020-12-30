using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Weixin
{
    /// <summary>
    /// Represents a QrCodeLimitListModel
    /// </summary>
    public partial record QrCodeLimitListModel : BasePagedListModel<QrCodeLimitModel>
    {
    }
}