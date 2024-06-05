using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 产品信息
/// </summary>
public partial class AntiFakeProduct : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 生产厂家ID
    /// </summary>
    public int AntiFakeCompanyId { get; set; }

    /// <summary>
    /// 销售厂家ID
    /// </summary>
    public int AntiFakeVendorCompanyId { get; set; }

    /// <summary>
    /// 产品条码号
    /// </summary>
    public long ProductBarCode { get; set; }

    /// <summary>
    /// 产品图片ID
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 产品透明图片ID
    /// </summary>
    public int TransparentPictureId { get; set; }

    /// <summary>
    /// 在系统中销售的产品ID（可不设置）
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 每箱数量
    /// </summary>
    public int QuantityPerBox { get; set; }

    /// <summary>
    /// 每个单瓶的数值（如500ml，填写500）
    /// </summary>
    public decimal UnitValue { get; set; }

    /// <summary>
    /// 单瓶单位，如：500ml，填写ml
    /// </summary>
    public string UnitName { get; set; }

    /// <summary>
    /// 产品名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 广告语
    /// </summary>
    public string Slogan { get; set; }

    /// <summary>
    /// 产品类型（如浓香型）
    /// </summary>
    public string ProductTypeName { get; set; }

    /// <summary>
    /// 产品食用方法
    /// </summary>
    public string ProductEdibleMethod { get; set; }

    /// <summary>
    /// 产品加工方式
    /// </summary>
    public string ProductProcessMethod { get; set; }

    /// <summary>
    /// 产品原料
    /// </summary>
    public string ProductMaterial { get; set; }

    /// <summary>
    /// 产品标准号
    /// </summary>
    public string ProductStandardNumber{ get; set; }

    /// <summary>
    /// 生产许可证号（不填写采用生产公司默认值）
    /// </summary>
    public string ProductionLicenseCode { get; set; }

    /// <summary>
    /// 产品存储方式
    /// </summary>
    public string ProductStorage { get; set; }

    /// <summary>
    /// 品牌名称
    /// </summary>
    public string BrandName { get; set; }

    /// <summary>
    /// 温馨提示
    /// </summary>
    public string Tips { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 产品体积：长
    /// </summary>
    public decimal Length { get; set; }

    /// <summary>
    /// 产品体积：宽
    /// </summary>
    public decimal Width { get; set; }

    /// <summary>
    /// 产品体积：高
    /// </summary>
    public decimal Height { get; set; }

    /// <summary>
    /// 重量
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// 扫码价格
    /// </summary>
    public decimal ScanPrice { get; set; }

    /// <summary>
    /// 零售价格
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// 显示扫码价格
    /// </summary>
    public bool DisplayScanPrice { get; set; }

    /// <summary>
    /// 显示零售价格
    /// </summary>
    public bool DisplayPrice { get; set; }

    /// <summary>
    /// 产品页模板
    /// </summary>
    public int AntiFakeProductTemplateId { get; set; }

    /// <summary>
    /// 激活状态
    /// </summary>
    public bool Actived { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

}
