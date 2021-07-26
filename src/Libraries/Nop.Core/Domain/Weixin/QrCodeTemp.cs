using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an 临时二维码
    /// </summary>
    public partial class QrCodeTemp : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 用户Id，不能为0
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 【SceneType】二维码功能：adver，vote，command等
        /// </summary>
        public byte SceneTypeId { get; set; }

        /// <summary>
        /// 【SceneType】二维码功能：adver，vote，command等
        /// </summary>
        public SceneType SceneType
        {
            get => (SceneType)SceneTypeId;
            set => SceneTypeId = (byte)value;
        }

        /// <summary>
        /// 场景字符串值（只保存中间部分）
        /// </summary>
        public string SceneValue { get; set; }

        /// <summary>
        /// 过期时间 = 创建时间 + 过期秒数
        /// </summary>
        public int ExpireTime { get; set; }

        /// <summary>
        /// 获取的二维码ticket
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 二维码图片解析后的地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public int CreatTime { get; set; }

    }
}
