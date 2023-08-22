using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Memberships
{
    /// <summary>
    /// 会员卡记录
    /// </summary>
    public partial class MemberInfo : BaseEntity
    {
        /// <summary>
        /// 对应的会员卡ID
        /// </summary>
        public int MemberShipCardId { get; set; }

        /// <summary>
        /// 是否会员本人信息
        /// </summary>
        public bool SelfInfo { get; set; }

        /// <summary>
        /// 如果不是会员本人信息，填写与会员的关系
        /// </summary>
        public string RelationShip { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 会员头像
        /// </summary>
        public string HeaderImage { get; set; }

        /// <summary>
        /// 联系电话1
        /// </summary>
        public string PhoneNumber1 { get; set; }

        /// <summary>
        /// 联系电话2
        /// </summary>
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 会员生日（选择国历生日）
        /// </summary>
        public string MemberBirthOfDateUtc { get; set; }

        /// <summary>
        /// 是否过农历生日
        /// </summary>
        public bool ChineseBirthOfDate { get; set; }

        /// <summary>
        /// 是否生日提醒
        /// </summary>
        public bool BirthdayRemind { get; set; }

        /// <summary>
        /// 是否自动发送生日祝福
        /// </summary>
        public bool AutoSendMessage { get; set; }

        /// <summary>
        /// 提前多少天发送
        /// </summary>
        public int SendAheadDays { get; set; }

        /// <summary>
        /// 祝福语
        /// </summary>
        public string BlessingMessage { get; set; }

        /// <summary>
        /// 发送消息审核通过
        /// </summary>
        public bool MessageApproved { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

    }
}
