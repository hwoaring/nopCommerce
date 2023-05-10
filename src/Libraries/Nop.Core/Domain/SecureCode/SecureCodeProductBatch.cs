using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 产品批次信息
    /// </summary>
    public partial class SecureCodeProductBatch : BaseEntity,ISoftDeletedEntity
    {
        /// <summary>
        /// 产品信息
        /// </summary>
        public int SecureCodeProductId { get; set; }

        /// <summary>
        /// 销售公司ID
        /// </summary>
        public int SecureCodeSellerId { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CreaterId { get; set; }

        /// <summary>
        /// 激活人ID
        /// </summary>
        public int ActiverId { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 本批次生产件数
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 生产线名称
        /// </summary>
        public string ProductionLine { get; set; }

        /// <summary>
        /// 检验员名称
        /// </summary>
        public string InspectorName { get; set; }

        /// <summary>
        /// 生产时间
        /// </summary>
        public DateTime? ManufactureDateUtc { get; set; }

        /// <summary>
        /// 过期时间（用于数据服务过期）
        /// </summary>
        public DateTime? ExpireDateUtc { get; set; }

        /// <summary>
        /// 数据激活时间
        /// </summary>
        public DateTime? ActiveDateUtc { get; set; }

        /// <summary>
        /// 激活
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 数据创建时间
        /// </summary>
        public DateTime CreatDateUtc { get; set; }
    }
}
