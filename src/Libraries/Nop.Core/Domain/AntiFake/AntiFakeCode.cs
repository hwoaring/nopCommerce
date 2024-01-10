using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake
{
    /// <summary>
    /// 防伪码
    /// </summary>
    public partial class AntiFakeCode : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 1：大码/箱码/物流码（外包装）（以1开头+6位生产公司条码编号+8位随机码+1位校验码）
        /// 二维码链接加上特殊标识参数，系统识别后马上跳转或更改url去掉特殊标识，防止别人通过链接生成二维码
        /// </summary>
        public long BoxCode { get; set; }

        /// <summary>
        /// 6：小码编码（内包装）（以6开头+6位生产公司条码编号+8位随机码+1位校验码）
        /// 二维码链接加上特殊标识参数，系统识别后马上跳转或更改url去掉特殊标识，防止别人通过链接生成二维码
        /// </summary>
        public long ItemCode { get; set; }

        /// <summary>
        /// 8：密码内包装密码二维码或掩盖的16位数字（8+随机14位+1位校验码，一共16位密码，）
        /// 二维码链接加上特殊标识参数，系统识别后马上跳转或更改url去掉特殊标识，防止别人通过链接生成二维码
        /// </summary>
        public long Password { get; set; }

        /// <summary>
        /// 绑定到销售ID扫码的时候可以显示购买电话
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 【由销售公司控制】是否启用
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
