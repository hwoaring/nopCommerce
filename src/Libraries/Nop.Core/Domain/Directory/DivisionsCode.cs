﻿using Humanizer;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// 行政区划代码表:http://www.mca.gov.cn/article/sj/xzqh/2020/
    /// </summary>
    public partial class DivisionsCode : BaseEntity
    {
        /// <summary>
        /// 区划代码
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 简写
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// 国家ID
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// 区划等级：0=国家级，1=省级，2=市级，3=区/县级，4=街道，5=居委会
        /// </summary>
        public byte AreaLevel { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 是否开通邮寄
        /// </summary>
        public bool AllowsShipping { get; set; }

        /// <summary>
        /// 是否热门区域
        /// </summary>
        public bool HotArea { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool Published { get; set; }

    }
}