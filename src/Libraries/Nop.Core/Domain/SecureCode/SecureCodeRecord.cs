using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 防伪码记录：产品码，防伪码
    /// </summary>
    public partial class SecureCodeRecord : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 大码编号（1开头）
        /// </summary>
        public long OuterCode { get; set; }

        /// <summary>
        /// 小码编号（6开头）
        /// </summary>
        public long InnerCode { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public long Password { get; set; }

        /// <summary>
        /// 防伪二维码图片地址
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 生产批次ID
        /// </summary>
        public int SecureCodeProductBatchId { get; set; }

        /// <summary>
        /// 扫码次数（没有输入密码）
        /// </summary>
        public int ScanCounts { get; set; }

        /// <summary>
        /// 防伪查询次数（输入防伪密码）
        /// </summary>
        public int SecurityCheckCounts { get; set; }

        /// <summary>
        /// 激活
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Deleted { get; set; }
    }
}
