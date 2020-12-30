using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Weixin
{
    /// <summary>
    /// Represents a user list model
    /// </summary>
    public partial record UserListModel : BasePagedListModel<UserModel>
    {
    }
}