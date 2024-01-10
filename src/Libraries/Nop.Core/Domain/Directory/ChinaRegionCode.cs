using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// 中国区划代码表
    /// </summary>
    public partial class ChinaRegionCode : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 6位区划代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 层级（0=省/直辖市，1=市，2=县/区）
        /// </summary>
        public int AreaLevel { get; set; }

        /// <summary>
        /// 名称大写字母（便于索引）
        /// </summary>
        public string CapitalNameIndex { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 短名称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 区划代码是否撤销
        /// </summary>
        public bool Revoked { get; set; }

        /// <summary>
        /// 发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
