namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an 永久二维码
    /// </summary>
    public partial class QrCodeLimit : BaseEntity
    {
        /// <summary>
        /// 站点ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 每个分组下面的1-100000数字永久ID（作为ID的副本保存）
        /// </summary>
        public int QrCodeId { get; set; }

        /// <summary>
        /// 二维码分组ID
        /// </summary>
        public int QrCodeCategoryId { get; set; }
        /// <summary>
        /// 二维码渠道ID
        /// </summary>
        public int QrCodeChannelId { get; set; }

        /// <summary>
        /// 二维码类型
        /// </summary>
        public byte QrCodeActionTypeId { get; set; }

        /// <summary>
        /// 二维码类型
        /// </summary>
        public QrCodeActionType QrCodeActionType
        {
            get => (QrCodeActionType)QrCodeActionTypeId;
            set => QrCodeActionTypeId = (byte)value;
        }

        /// <summary>
        /// 二维码系统名称
        /// </summary>
        public string SysName { get; set; }
        /// <summary>
        /// 二维码描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 获取的二维码ticket
        /// </summary>
        public string Ticket { get; set; }
        /// <summary>
        /// 二维码图片解析后的地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 场景字符串
        /// </summary>
        public string SceneStr { get; set; }
        /// <summary>
        /// 用户被打上的标签ID列表（扫描该二维码用户自动打上标签）
        /// </summary>
        public string TagIdList { get; set; }
        /// <summary>
        /// 固定分配使用（将二维码永久分配占用）
        /// </summary>
        public bool FixedUse { get; set; }
    }
}
