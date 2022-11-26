using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// Represents a CityCounty
    /// </summary>
    public partial class CityCounty : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the stateProvince identifier(省Id)
        /// </summary>
        public int StateProvinceId { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 区划代码
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// 区划等级：0=国家级，1=省级，2=市级，3=区/县级，4=街道，5=居委会
        /// 表中主要使用：2和3
        /// </summary>
        public byte AreaLevel { get; set; }

        /// <summary>
        /// 是否开通邮寄
        /// </summary>
        public bool AllowShipping { get; set; }

        /// <summary>
        /// 是否热门区域
        /// </summary>
        public bool HotArea { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        
    }
}
