using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake
{
    /// <summary>
    /// 防伪外箱码、物流码，大码
    /// </summary>
    public partial class AntiFakeBoxCode : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 快速筛选：印刷版面批号（用以快速设置二维码绑定的产品信息，交给印刷公司前要确定）
        /// 以日期 + 当日印刷批号1位 +5位序列号版面号：231208 + 1 +00001，一共12位，以印刷版面递增序号
        /// </summary>
        public long PrintPageCode { get; set; }

        /// <summary>
        /// 快速筛选：大码序列号（用以快速设置二维码绑定的产品信息，序列号在每个大标，交给印刷公司前要确定）
        /// 以日期+0+随机5位：231208+0+xxxxx，一共12位，然后以这个数作为起点，向后序列增加（避免别人猜出数量）
        /// </summary>
        public long BoxCodeSerialNumber { get; set; }

        /// <summary>
        /// 大码/箱码/物流码（外包装）（以1开头+6位生产公司条码编号+8位随机码+1位校验码）
        /// 二维码链接加上特殊标识参数，系统识别后马上跳转或更改url去掉特殊标识，防止别人通过链接生成二维码
        /// </summary>
        public long BoxCode { get; set; }

        /// <summary>
        /// 创建日期（系统控制）
        /// </summary>
        public DateTime CreatOnUtc { get; set; }

        /// <summary>
        /// 【由生产公司控制】：绑定产品（后期使用的时候绑定，避免乱设置产品信息）
        /// </summary>
        public int AntiFakeProductId { get; set; }

        /// <summary>
        /// 【由生产公司或系统平台控制】：绑定到销售公司,销售公司可以控制属于自己的序列号
        /// 此处可以为独立绑定，在产品平台可以统一绑定
        /// 可以不绑定
        /// </summary>
        public int AntiFakeVendorCompanyId { get; set; }

        /// <summary>
        /// 绑定到销售ID扫码的时候可以显示购买电话
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 【由生产公司控制】:产品信息绑定日期，不可更改，绑定后作为过期时间计算的参考值
        /// 生产公司也可作为生产日期使用
        /// </summary>
        public DateTime? BindDateUtc { get; set; }

        /// <summary>
        /// 【由销售公司控制】是否启用生效
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 【由系统平台控制】是否可用
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }
    }
}
