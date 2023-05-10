using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 小码设置的促销折扣记录
    /// </summary>
    public partial class SecureCodeDiscountRecord : BaseEntity
    {
        /// <summary>
        /// 对应的小码ID
        /// </summary>
        public int SecureCodeRecordId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amounts { get; set; }

        /// <summary>
        /// 满减金额要求
        /// </summary>
        public decimal ConditionAmounts { get; set; }

        /// <summary>
        /// 换物产品ID，默认为0=再来一瓶
        /// </summary>
        public int ExchangeProductId { get; set; }

        /// <summary>
        /// 兑换商品的密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 折扣类型：现金兑换券，现金抵用券，再来一瓶
        /// </summary>
        public int SecurityCodeDiscountTypeId { get; set; }

        /// <summary>
        /// 商家兑换人ID
        /// </summary>
        public int IssuerCustomerId { get; set; }

        /// <summary>
        /// 领取用户ID
        /// </summary>
        public int ReceiverId { get; set; }

        /// <summary>
        /// 领取人电话
        /// </summary>
        public string RecieverPhone { get; set; }

        /// <summary>
        /// 兑换时间
        /// </summary>
        public DateTime? ExchangeDateUtc { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpireDateUtc { get; set; }

        /// <summary>
        /// 兑换信息登记时间
        /// </summary>
        public DateTime? ExchangeCreatDateUtc { get; set; }

        /// <summary>
        /// 是否已经兑换完成
        /// </summary>
        public bool Exchanged { get; set; }

        /// <summary>
        /// 激活
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CreaterId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedUtc { get; set; }
    }
}
