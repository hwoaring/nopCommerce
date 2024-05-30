using AutoMapper.Execution;
using Nop.Core.Domain.Brands;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 代理商店铺
/// </summary>
public partial class VendorStore : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 创建人零售商id（拥有人ID，系统可以创建品牌首页，让对方公司认领，认领时给一定费用）
    /// 认领为企业店铺时，个人无法删除企业认领店铺
    /// 提供公司资质后，可以更换认领人
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 对外展示统一加密id（URL参数）
    /// </summary>
    public long UnifiedId { get; set; }

    /// <summary>
    /// 店铺编号(8位数字码：可用于系统内店铺查询，或印刷到门头上，同时用到会员卡前8位）
    /// </summary>
    public long StoreNumber { get; set; }

    /// <summary>
    /// 店铺是否有品牌（如红旗连锁，舞东风等）
    /// 在Brand中选择属于店铺品牌的商标
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// 店铺名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 商店Slogan
    /// </summary>
    public string Slogan { get; set; }

    /// <summary>
    /// 店铺描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 店铺内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 商店Logo，店铺会员卡Logo图片
    /// </summary>
    public int LogoPictureId { get; set; }

    /// <summary>
    /// 供应商店铺域名
    /// </summary>
    public string DomainUrl { get; set; }

    /// <summary>
    /// 允许自己设置域名链接
    /// </summary>
    public bool CustomizeDomainUrl { get; set; }

    /// <summary>
    /// 店铺图片(封面图)
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 授权图片ID
    /// </summary>
    public int AuthorizePictureId { get; set; }

    /// <summary>
    /// 首页模板Id
    /// </summary>
    public int IndexTemplateId { get; set; }

    /// <summary>
    /// 栏目页模板Id
    /// </summary>
    public int CategoryTemplateId { get; set; }

    /// <summary>
    /// 产品页模板Id
    /// </summary>
    public int ProductTemplateId { get; set; }

    /// <summary>
    /// 关于页模板Id
    /// </summary>
    public int AboutTemplateId { get; set; }

    /// <summary>
    /// 招商/投资页模板Id
    /// </summary>
    public int InvestmentTemplateId { get; set; }

    /// <summary>
    /// 表单页模板Id
    /// </summary>
    public int FormTemplateId { get; set; }

    /// <summary>
    /// 联系页模板Id
    /// </summary>
    public int ContactTemplateId { get; set; }

    /// <summary>
    /// 经度值（用于定位店铺位置，可用于设置定位周边x公里范围的搜索）
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// 纬度值（用于定位店铺位置，可用于设置定位周边x公里范围的搜索）
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// 覆盖公里数（或者通过VendorStoreRegionalAgent表，查找代理人覆盖区域）
    /// </summary>
    public int CoverageKilometers { get; set; }

    /// <summary>
    /// 商店联系人姓名
    /// </summary>
    public string ContactName { get; set; }

    /// <summary>
    /// 密保邮箱
    /// </summary>
    public string SecurityEmail { get; set; }

    /// <summary>
    /// 密保电话
    /// </summary>
    public string SecurityPhone { get; set; }

    /// <summary>
    /// 商店联系电话
    /// </summary>
    public string ContractPhone { get; set; }

    /// <summary>
    /// 商店传真
    /// </summary>
    public string ContractFax { get; set; }

    /// <summary>
    /// 财务联系电话
    /// </summary>
    public string FinancePhone { get; set; }

    /// <summary>
    /// 预定电话
    /// </summary>
    public string BookingPhone { get; set; }

    /// <summary>
    /// 显示电话
    /// </summary>
    public bool DisplayPhone { get; set; }

    /// <summary>
    /// 开店时间
    /// </summary>
    public string OpeningTime { get; set; }

    /// <summary>
    /// 店铺地址ID
    /// </summary>
    public int AddressId { get; set; }

    /// <summary>
    /// 显示地址
    /// </summary>
    public bool DisplayAddress { get; set; }

    /// <summary>
    /// 代理商有货时候仓库配送地址或取货地址
    /// </summary>
    public int VendorWarehouseId { get; set; }

    /// <summary>
    /// 店铺二维码（公众号图片）
    /// </summary>
    public int QrCodePictureId { get; set; }

    /// <summary>
    /// 等级（备用）
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 平台合作承诺书，合作协议图片ID
    /// （内容包括会员个人信息保密与合理使用，自行发布的优惠卡卡券由发布公司承担所有责任，品牌只提供数据存储服务和会员功能服务）
    /// </summary>
    public int AgreementPictureId { get; set; }

    /// <summary>
    /// 营业执照公司名称
    /// </summary>
    public string BusinessName { get; set; }

    /// <summary>
    /// 营业执照图片
    /// </summary>
    public int BusinessPictureId { get; set; }

    /// <summary>
    /// 营业执照号码
    /// </summary>
    public string BusinessCode { get; set; }

    /// <summary>
    /// 营业执照过期时间
    /// </summary>
    public DateTime? BusinessExpireDateUtc { get; set; }

    /// <summary>
    /// 食品经营许可证图片
    /// </summary>
    public int FoodLicensePictureId { get; set; }

    /// <summary>
    /// 食品经营许可证号码
    /// </summary>
    public string FoodCode { get; set; }

    /// <summary>
    /// 食品经营许可证过期时间
    /// </summary>
    public DateTime? FoodLicenseExpireUtc { get; set; }

    /// <summary>
    /// 店铺类型
    /// </summary>
    public int VendorStoreTypeId { get; set; }

    /// <summary>
    /// 合作模式
    /// </summary>
    public int VendorStoreCooperateTypeId { get; set; }

    /// <summary>
    /// 管理员评论
    /// </summary>
    public string AdminComment { get; set; }

    /// <summary>
    /// 是否可提供发票
    /// </summary>
    public bool WithInvoice { get; set; }

    /// <summary>
    /// 是否可提供专票
    /// </summary>
    public bool WithSpecialInvoice { get; set; }

    /// <summary>
    /// 普票点数
    /// </summary>
    public decimal InvoicePoints { get; set; }

    /// <summary>
    /// 专票点数
    /// </summary>
    public decimal SpecialInvoicePoints { get; set; }

    /// <summary>
    /// 浏览量
    /// </summary>
    public int ViewsCount { get; set; }

    /// <summary>
    /// 银行代码（银行代码ICBC，ABC，WECHAT，ALIPAY等）
    /// </summary>
    public string BankCode { get; set; }

    /// <summary>
    /// 银行行号（备用）
    /// </summary>
    public string BankNumber { get; set; }

    /// <summary>
    /// 账号，公账（银行账号或支付宝、微信账号）
    /// </summary>
    public string BankAccount { get; set; }

    /// <summary>
    /// 银行转款操作员验证电话
    /// </summary>
    public string BankOperatorPhone { get; set; }

    /// <summary>
    /// 银行转款验证员验证电话
    /// </summary>
    public string BankVerifierPhone { get; set; }

    /// <summary>
    /// 账号名称/单位名称
    /// </summary>
    public string BankAccountName { get; set; }

    /// <summary>
    /// 银行账号验证金额（向对方打款几分）
    /// </summary>
    public decimal BankVerifyAmount { get; set; }

    /// <summary>
    /// 银行是否验证
    /// </summary>
    public bool BankVerified { get; set; }

    /// <summary>
    /// 公开展示，或直接显示推荐的联系方式,客户可以直接联系，表明自己是供应商
    /// </summary>
    public bool DisplayContactInfo { get; set; }

    /// <summary>
    /// 会员卡功能
    /// </summary>
    public bool MemberCardFun { get; set; }

    /// <summary>
    /// 开通会员信息功能（客户管理系统）
    /// </summary>
    public bool MemberInfoFun { get; set; }

    /// <summary>
    /// 基础会员身份过期
    /// </summary>
    public bool BasicMemberExpired { get; set; }

    /// <summary>
    /// 基础会员身份过期天数（365天默认为1年，按会员开卡时间算起）
    /// </summary>
    public bool BasicMemberExpireDays { get; set; }

    /// <summary>
    /// 跟单回访功能
    /// </summary>
    public bool ReVisitFun { get; set; }

    /// <summary>
    /// 开通菜单/产品预定功能
    /// </summary>
    public bool EnableBookingProduct { get; set; }

    /// <summary>
    /// 开通座位预定功能
    /// </summary>
    public bool EnableBookingSeat { get; set; }

    /// <summary>
    /// 开通预定提醒
    /// </summary>
    public bool EnableBookingNotice { get; set; }

    /// <summary>
    /// 预定成功自动发送预定短信
    /// </summary>
    public bool EnableBookingMessage { get; set; }

    /// <summary>
    /// 预约提前分钟数
    /// </summary>
    public int BookingForwardMinutes { get; set; }

    /// <summary>
    /// 店铺状态停业状态，否则为开业状态
    /// </summary>
    public bool StoreClosed { get; set; }

    /// <summary>
    /// 是否品牌方
    /// </summary>
    public bool BrandOwner { get; set; }
    

    /// <summary>
    /// 是否已认证
    /// </summary>
    public bool Certified { get; set; }

    /// <summary>
    /// 是否企业店铺：区分店铺是个人认领店铺还是公司/企业认领店铺
    /// </summary>
    public bool EnterpriseStore { get; set; }

    /// <summary>
    /// 审核通过
    /// </summary>
    public bool Approved { get; set; }

    /// <summary>
    /// 是否有效
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// 暂停营业提示文字
    /// </summary>
    public string StoreCloseNotice { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// SEO关键词
    /// </summary>
    public string MetaKeywords { get; set; }

    /// <summary>
    /// SEO描述
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// SEO标题
    /// </summary>
    public string MetaTitle { get; set; }

    /// <summary>
    /// 页面大小
    /// </summary>
    public int PageSize { get; set; }

}
