﻿using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 不同店铺的会员信息（会员信息管理系统）
    /// </summary>
    public partial class VendorStoreMembers : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Store ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// VendorStore ID
        /// </summary>
        public int VendorStoreId { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IDCardNumber { get; set; }

        /// <summary>
        /// 0=未知，1=男，2=女
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 尊称（礼貌名称，发祝福时候使用尊称）
        /// </summary>
        public string CourtesyName { get; set; }

        /// <summary>
        /// 会员头像
        /// </summary>
        public string HeaderImage { get; set; }

        /// <summary>
        /// 联系电话（会员可见，由会员设置）
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 其他联系电话（会员不可见，由商家设置）
        /// </summary>
        public string OtherPhoneNumbers { get; set; }

        /// <summary>
        /// 地址（会员不可见）
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// 描述（会员不可见）
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 会员生日（国历）
        /// </summary>
        public DateTime? BirthOfDateUtc { get; set; }

        /// <summary>
        /// 会员生日（农历）（会员不可见）
        /// </summary>
        public DateTime? LunarBirthOfDateUtc { get; set; }

        /// <summary>
        /// 是否过农历生日（会员不可见）
        /// </summary>
        public bool LunarBirthOfDate { get; set; }

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
        /// 祝福语，消息模板
        /// </summary>
        public int MessageTemplateId { get; set; }

        /// <summary>
        /// 发送消息审核通过
        /// </summary>
        public bool MessageApproved { get; set; }

        /// <summary>
        /// 联系电话是否通过SMS验证
        /// </summary>
        public bool PhoneNumberVerified { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }
    }
}