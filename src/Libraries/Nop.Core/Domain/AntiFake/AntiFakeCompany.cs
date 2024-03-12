using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 生产公司信息
/// </summary>
public partial class AntiFakeCompany : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 生产公司名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 公司地址
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// 商品产地（产品介绍上显示）
    /// </summary>
    public string ProducingArea { get; set; }

    /// <summary>
    /// 生产公司电话
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 营业执照
    /// </summary>
    public int BusinessLicensePictureId { get; set; }

    /// <summary>
    /// 营业执照号
    /// </summary>
    public string BusinessLicenseCode { get; set; }

    /// <summary>
    /// 生产许可证
    /// </summary>
    public int ProductionLicensePictureId { get; set; }

    /// <summary>
    /// 生产许可证号
    /// </summary>
    public string ProductionLicenseCode { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
