using Nop.Core.Configuration;
using Nop.Core.Domain.Tax;

namespace Nop.Core.Domain.Common;

/// <summary>
/// Address
/// </summary>
public partial class Address : BaseEntity
{
    /// <summary>
    /// Gets or sets the first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the company
    /// </summary>
    public string Company { get; set; }

    /// <summary>
    /// Gets or sets the country identifier
    /// </summary>
    public int? CountryId { get; set; }

    /// <summary>
    /// Gets or sets the state/province identifier
    /// </summary>
    public int? StateProvinceId { get; set; }

    /// <summary>
    /// Gets or sets the county
    /// </summary>
    public string County { get; set; }

    /// <summary>
    /// Gets or sets the city
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the address 1
    /// </summary>
    public string Address1 { get; set; }

    /// <summary>
    /// Gets or sets the address 2
    /// </summary>
    public string Address2 { get; set; }

    /// <summary>
    /// Gets or sets the zip/postal code
    /// </summary>
    public string ZipPostalCode { get; set; }

    /// <summary>
    /// Gets or sets the phone number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the fax number
    /// </summary>
    public string FaxNumber { get; set; }

    /// <summary>
    /// Gets or sets the custom attributes (see "AddressAttribute" entity for more info)
    /// </summary>
    public string CustomAttributes { get; set; }

    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    #region === 扩展属性 ===

    /// <summary>
    /// 地址类型ID
    /// </summary>
    public int AddressTypeId { get; set; }

    /// <summary>
    /// 地址的区划代码ID
    /// </summary>
    public int RegionCodeId { get; set; }

    /// <summary>
    /// 地址短标签（用户自己对地址设置的标签）
    /// </summary>
    public string AddressLable { get; set; }

    /// <summary>
    /// 经度值
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// 纬度值
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// 电话号码是否已经短信认证
    /// </summary>
    public bool PhoneNumberVerified { get; set; }

    /// <summary>
    /// 是否默认地址（一个用户下只有1个默认）
    /// </summary>
    public bool IsDefault { get; set; }

    public AddressType AddressType
    {
        get => (AddressType)AddressTypeId;
        set => AddressTypeId = (int)value;
    }

    #endregion

}
