using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 销售公司信息
/// </summary>
public partial class AntiFakeVendorCompany : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 销售公司名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 销售公司编号
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 销售公司地址
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// 服务电话
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 官方微信号
    /// </summary>
    public int QrcodePictureId { get; set; }

    /// <summary>
    /// 营业执照
    /// </summary>
    public int BusinessLicensePictureId { get; set; }

    /// <summary>
    /// 营业执照号
    /// </summary>
    public string BusinessLicenseCode { get; set; }

    /// <summary>
    /// 食品经营许可证
    /// </summary>
    public int FoodLicensePictureId { get; set; }

    /// <summary>
    /// 食品经营许可证号
    /// </summary>
    public string FoodLicenseCode { get; set; }

    /// <summary>
    /// 销售电话：是否显示销售电话
    /// </summary>
    public bool EnableSalesPhone { get; set; }

    /// <summary>
    /// 销售电话：是否开通区域代理电话（不同区域展示不同代理的销售电话）
    /// </summary>
    public bool EnableRegionalSales { get; set; }

    /// <summary>
    /// 销售电话：是否开通产品跟踪（可以将产品销售信息精确到一件进行跟踪）
    /// 跟踪信息记录到AntiFakeBoxVendorRecords中
    /// </summary>
    public bool EnableProductTrack { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 创建日期
    /// </summary>
    public DateTime CreatDateUtc { get; set; }

    /// <summary>
    /// 首次开始服务有效期开始时间
    /// </summary>
    public DateTime? StartDateUtc { get; set; }
    
    /// <summary>
    /// 服务有效期结束
    /// </summary>
    public DateTime? EndDateUtc { get; set; }

    /// <summary>
    /// 最近认证日期（最新审核日期）
    /// </summary>
    public DateTime? VerifiedDateUtc { get; set; }
}
