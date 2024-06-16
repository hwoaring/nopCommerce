using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory;

/// <summary>
/// 区划代码表（中国），其他国家可能有区划码
/// </summary>
public partial class RegionCode : BaseEntity, ILocalizedEntity
{
    /// <summary>
    /// 国家ID（数据库中的ID）
    /// </summary>
    public int CountryId { get; set; }

    /// <summary>
    /// 6位区划代码（标准区划码）
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 名称（标准区划码对应的名称）
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 名称大写字母（便于索引）
    /// </summary>
    public string NameIndex { get; set; }

    /// <summary>
    /// 短名称(完整名称如：四川省,成都市,锦江区，显示全部路径名称)
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// 层级（1=省/直辖市，2=市，3=县/区，4=街道）
    /// </summary>
    public int AreaLevel { get; set; }

    /// <summary>
    /// 人口数量
    /// </summary>
    public int NumberOfPeople { get; set; }

    /// <summary>
    /// 人均消费（提现城市的消费能力）
    /// </summary>
    public decimal AverageConsume { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 区划代码是否撤销
    /// </summary>
    public bool Revoked { get; set; }

    /// <summary>
    /// 发布
    /// </summary>
    public bool Published { get; set; }
}
