﻿using System.ComponentModel;
using System.Text.RegularExpressions;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Services.Localization;

namespace Nop.Web.Framework.Mvc.ModelBinding
{
    /// <summary>
    /// Represents model attribute that specifies the display name by passed key of the locale resource
    /// </summary>
    public sealed class NopResourceDisplayNameAttribute : DisplayNameAttribute, IModelAttribute
    {
        #region Fields

        private string _resourceValue = string.Empty;

        #endregion

        #region Ctor

        /// <summary>
        /// Create instance of the attribute
        /// </summary>
        /// <param name="resourceKey">Key of the locale resource</param>
        public NopResourceDisplayNameAttribute(string resourceKey) : base(resourceKey)
        {
            ResourceKey = resourceKey;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets key of the locale resource 
        /// </summary>
        public string ResourceKey { get; set; }

        /// <summary>
        /// Getss the display name
        /// </summary>
        public override string DisplayName
        {
            get
            {
                //判断非英文和符号
                if (!Regex.IsMatch(ResourceKey, "[-A-Za-z0-9._]"))
                    return ResourceKey;  //直接返回key值

                //get working language identifier
                var workingLanguageId = EngineContext.Current.Resolve<IWorkContext>().WorkingLanguage.Id;

                //get locale resource value
                _resourceValue = EngineContext.Current.Resolve<ILocalizationService>().GetResource(ResourceKey, workingLanguageId, true, ResourceKey);

                return _resourceValue;
            }
        }

        /// <summary>
        /// Gets name of the attribute
        /// </summary>
        public string Name => nameof(NopResourceDisplayNameAttribute);

        #endregion
    }
}
