using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Forms
{
    /// <summary>
    /// 表单设置
    /// </summary>
    public partial class Form : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// storeid
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 对外展示统一加密id（URL参数）
        /// </summary>
        public long UnifiedId { get; set; }

        /// <summary>
        /// 表单创建人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 表单使用绑定到个人（专人专享）
        /// </summary>
        public int LimitToCustomerId { get; set; }

        /// <summary>
        /// 表单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 表单描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 表单内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 图片ID
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDateOnUtc { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDateOnUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatOnUtc { get; set; }

        /// <summary>
        /// 是否按Vendor区分客户信息（在Form中区分由vendor推荐的客户，可用于销售现场登记或邀请登记）
        /// Vendor在其后台可以选择是否绑定该表单的分享。
        /// </summary>
        public bool EnableVendor { get; set; }

        /// <summary>
        /// 是否允许不同Vendor邀请的同一客户重复登记
        /// </summary>
        public bool VendorDuplicateRecords { get; set; }

        /// <summary>
        /// 是否允许Vendor查看个人表格信息
        /// </summary>
        public bool EnableVendorView { get; set; }

        /// <summary>
        /// 表单底部显示邀请人信息
        /// </summary>
        public bool DisplayReferrerCustomer { get; set; }

        /// <summary>
        /// 关闭
        /// </summary>
        public bool Closed { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 是否登记姓名
        /// </summary>
        public bool EnableName { get; set; }

        /// <summary>
        /// 是否登记电话
        /// </summary>
        public bool EnablePhone { get; set; }

        /// <summary>
        /// 是否登记年龄
        /// </summary>
        public bool EnableAge { get; set; }

        /// <summary>
        /// 是否登记性别（0=未知，1=男，2=女）
        /// </summary>
        public bool EnableSex { get; set; }

        /// <summary>
        /// 是否登记人数（或者用于其他计数统计）
        /// </summary>
        public bool EnableCount { get; set; }

        /// <summary>
        /// 是否登记地址
        /// </summary>
        public bool EnableAddress { get; set; }

        /// <summary>
        /// 是否登记备注（客人备注）
        /// </summary>
        public bool EnableRemark { get; set; }

        /// <summary>
        /// 是否登记日期选择
        /// </summary>
        public bool EnableCustomerDateTime { get; set; }

    }
}
