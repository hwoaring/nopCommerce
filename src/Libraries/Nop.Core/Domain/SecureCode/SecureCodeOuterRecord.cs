using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 大码扫码记录，主要记录物流跟踪，区域分配、区域销售负责人、购买联系人信息
    /// </summary>
    public partial class SecureCodeOuterRecord : BaseEntity
    {
        /// <summary>
        /// 大码编号
        /// </summary>
        public long OuterCode { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CreaterId { get; set; }

        /// <summary>
        /// 设置收货人ID：
        /// 收货人是普通收货人：有区域销售电话的按区域销售电话显示
        /// 收货人是销售人员：则调取销售人员的销售电话展示
        /// </summary>
        public int ReceiverId { get; set; }

        /// <summary>
        /// 指定的区域销售ID
        /// </summary>
        public int SecureCodeRegionSellerId { get; set; }

        /// <summary>
        /// 操作类型：物流信息变更，代理信息变更
        /// </summary>
        public int OperationType { get; set; }

        /// <summary>
        /// 商品跟踪信息
        /// </summary>
        public string TrackInfo { get; set; }

        /// <summary>
        /// 激活
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedUtc { get; set; }
    }
}
