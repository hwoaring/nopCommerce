﻿using Nop.Core.Domain.Common;
using Nop.Core.Domain.Tax;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents a customer
    /// </summary>
    public partial class Customer : BaseEntity, ISoftDeletedEntity
    {
        public Customer()
        {
            CustomerGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the customer GUID
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the company
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the street address
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the street address 2
        /// </summary>
        public string StreetAddress2 { get; set; }

        /// <summary>
        /// Gets or sets the zip
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the county
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the country id
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the state province id
        /// </summary>
        public int StateProvinceId { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the fax
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the vat number
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// Gets or sets the vat number status id
        /// </summary>
        public int VatNumberStatusId { get; set; }

        /// <summary>
        /// Gets or sets the time zone id
        /// </summary>
        public string TimeZoneId { get; set; }

        /// <summary>
        /// Gets or sets the custom attributes
        /// </summary>
        public string CustomCustomerAttributesXML { get; set; }

        /// <summary>
        /// Gets or sets the currency id
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the language id
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the tax display type id
        /// </summary>
        public int? TaxDisplayTypeId { get; set; }

        /// <summary>
        /// Gets or sets the email that should be re-validated. Used in scenarios when a customer is already registered and wants to change an email address.
        /// </summary>
        public string EmailToRevalidate { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is tax exempt
        /// </summary>
        public bool IsTaxExempt { get; set; }

        /// <summary>
        /// Gets or sets the affiliate identifier
        /// </summary>
        public int AffiliateId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier with which this customer is associated (manager)
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this customer has some products in the shopping cart
        /// <remarks>The same as if we run ShoppingCartItems.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load "ShoppingCartItems" navigation property for each page load
        /// It's used only in a couple of places in the presentation layer
        /// </remarks>
        /// </summary>
        public bool HasShoppingCartItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is required to re-login
        /// </summary>
        public bool RequireReLogin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating number of failed login attempts (wrong password)
        /// </summary>
        public int FailedLoginAttempts { get; set; }

        /// <summary>
        /// Gets or sets the date and time until which a customer cannot login (locked out)
        /// </summary>
        public DateTime? CannotLoginUntilDateUtc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer account is system
        /// </summary>
        public bool IsSystemAccount { get; set; }

        /// <summary>
        /// Gets or sets the customer system name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the last IP address
        /// </summary>
        public string LastIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last login
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last activity
        /// </summary>
        public DateTime LastActivityDateUtc { get; set; }

        /// <summary>
        ///  Gets or sets the store identifier in which customer registered
        /// </summary>
        public int RegisteredInStoreId { get; set; }

        /// <summary>
        /// Gets or sets the billing address identifier
        /// </summary>
        public int? BillingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the shipping address identifier
        /// </summary>
        public int? ShippingAddressId { get; set; }


        #region === 扩展字段 ===

        /// <summary>
        /// 在平台上的等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 永久推荐人ID
        /// </summary>
        public int ReferrerCustomerId { get; set; }

        /// <summary>
        /// 临时推荐人ID
        /// </summary>
        public int TempReferrerCustomerId { get; set; }

        /// <summary>
        /// 临时推荐人过期时间（更新时间+系统设置的过期市场=过期时间，超出时间属于默认推荐人）
        /// </summary>
        public DateTime? TempReferrerExpireDateUtc { get; set; }

        /// <summary>
        /// 推荐场景值
        /// </summary>
        public string ReferrerSceneStr { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 用户微信UnionID
        /// </summary>
        public string UnionId { get; set; }

        /// <summary>
        /// 8位个人推荐码
        /// </summary>
        public long ReferrerCode { get; set; }

        /// <summary>
        /// 个人微信二维码
        /// </summary>
        public int QrcodePictureId { get; set; }

        /// <summary>
        /// 系统备注名称
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 个人微信二维码是否已审核通过（防止个人添加非法二维码链接）
        /// </summary>
        public bool QrcodeValidated { get; set; }

        /// <summary>
        /// 邮箱地址是否通过验证（能正常接收邮件）
        /// </summary>
        public bool EmailValidated { get; set; }

        /// <summary>
        /// 电话号码是否通过SMS验证（能正常接收短信，修改手机号或找回密码等）
        /// </summary>
        public bool PhoneValidated { get; set; }

        /// <summary>
        /// 用于客户已注册并希望更改电话号码的情况。
        /// </summary>
        public string PhoneToRevalidate { get; set; }

        /// <summary>
        /// 是否允许成为推荐人，默认true，不允许时，该用户发布推荐链接时，不会让其他用户成为他的客户
        /// </summary>
        public bool AsReferrerEnable { get; set; }

        /// <summary>
        /// 是否允许被推荐人，不允许时，该用户不会成为其他用户的推荐客户或临时推荐客户
        /// </summary>
        public bool AsRecommendedEnable { get; set; }

        /// <summary>
        /// 允许成为临时推荐人（False=不允许覆盖临时推荐信ID）
        /// </summary>
        public bool AsTempReferrerEnable { get; set; }


        #endregion

        #region Custom properties

        /// <summary>
        /// Gets or sets the vat number status
        /// </summary>
        public VatNumberStatus VatNumberStatus
        {
            get => (VatNumberStatus)VatNumberStatusId;
            set => VatNumberStatusId = (int)value;
        }

        /// <summary>
        /// Gets or sets the tax display type
        /// </summary>
        public TaxDisplayType? TaxDisplayType
        {
            get => TaxDisplayTypeId.HasValue ? (TaxDisplayType)TaxDisplayTypeId : null;
            set => TaxDisplayTypeId = value.HasValue ? (int)value : null;
        }

        #endregion
    }
}