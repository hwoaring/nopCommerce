using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Weixin;
using Nop.Web.Areas.Admin.Models.Weixin;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the Weixin model factory
    /// </summary>
    public partial interface IWeixinModelFactory
    {
        /// <summary>
        /// Prepare User model
        /// </summary>
        /// <param name="model">User model</param>
        /// <param name="product">User</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Product model</returns>
        Task<UserModel> PrepareUserModelAsync(UserModel model, WxUser user, bool excludeProperties = false);

        /// <summary>
        /// Prepare User search model
        /// </summary>
        /// <param name="searchModel">User search model</param>
        /// <returns>User search model</returns>
        Task<UserSearchModel> PrepareUserSearchModelAsync(UserSearchModel searchModel);

        /// <summary>
        /// Prepare paged User list model
        /// </summary>
        /// <param name="searchModel">User search model</param>
        /// <returns>User list model</returns>
         Task<UserListModel> PrepareUserListModelAsync(UserSearchModel searchModel);

        /// <summary>
        /// Prepare QrCodeLimit model
        /// </summary>
        /// <param name="model">QrCodeLimit model</param>
        /// <param name="QrCodeLimit">QrCodeLimit</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Product model</returns>
         Task<QrCodeLimitModel> PrepareQrCodeLimitModelAsync(QrCodeLimitModel model, QrCodeLimit qrCodeLimit, bool excludeProperties = false);

        /// <summary>
        /// Prepare QrCodeLimit search model
        /// </summary>
        /// <param name="searchModel">QrCodeLimit search model</param>
        /// <returns>QrCodeLimit search model</returns>
         Task<QrCodeLimitSearchModel> PrepareQrCodeLimitSearchModelAsync(QrCodeLimitSearchModel searchModel);

        /// <summary>
        /// Prepare paged QrCodeLimit list model
        /// </summary>
        /// <param name="searchModel">QrCodeLimit search model</param>
        /// <returns>User list model</returns>
         Task<QrCodeLimitListModel> PrepareQrCodeLimitListModelAsync(QrCodeLimitSearchModel searchModel);

         Task<QrCodeLimitUserListModel> PrepareQrCodeLimitUserListModelAsync(QrCodeLimitUserSearchModel searchModel, QrCodeLimit qrCodeLimit);

         Task<AddUserRelatedSearchModel> PrepareAddUserRelatedSearchModelAsync(AddUserRelatedSearchModel searchModel);

         Task<AddUserRelatedUserListModel> PrepareAddUserRelatedUserListModelAsync(AddUserRelatedSearchModel searchModel);

         Task<QrCodeLimitUserModel> PrepareQrCodeLimitUserModelAsync(QrCodeLimitUserModel model, QrCodeLimitUserMapping qrCodeLimitUser, bool excludeProperties = false);


        #region Menu Model

         Task<MenuSearchModel> PrepareMenuSearchModelAsync(MenuSearchModel searchModel);
         Task<MenuListModel> PrepareMenuListModelAsync(MenuSearchModel searchModel);
         Task<MenuModel> PrepareMenuModelAsync(MenuModel model, WxMenu menu, bool excludeProperties = false);
         Task<MenuButtonListModel> PrepareMenuButtonListModelAsync(MenuButtonSearchModel searchModel, WxMenu menu);


        #endregion


    }
}