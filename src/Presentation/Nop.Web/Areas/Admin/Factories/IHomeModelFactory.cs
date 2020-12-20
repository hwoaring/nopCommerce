﻿using System.Threading.Tasks;
using Nop.Web.Areas.Admin.Models.Home;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the home models factory
    /// </summary>
    public partial interface IHomeModelFactory
    {
        /// <summary>
        /// Prepare dashboard model
        /// </summary>
        /// <param name="model">Dashboard model</param>
        /// <returns>Dashboard model</returns>
        Task<DashboardModel> PrepareDashboardModelAsync(DashboardModel model);

        /// <summary>
        /// Prepare nopCommerce news model
        /// </summary>
        /// <returns>nopCommerce news model</returns>
        Task<NopCommerceNewsModel> PrepareNopCommerceNewsModelAsync();
    }
}