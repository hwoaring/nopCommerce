namespace Nop.Core.Domain.Shares
{
    /// <summary>
    /// 分享页面信息
    /// </summary>
    public partial class SharePage : BaseEntity
    {
        /// <summary>
        /// 实例ID
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// 实例页面类型ID
        /// </summary>
        public int PublicEntityTypeId { get; set; }

        /// <summary>
        /// 阅读基数
        /// </summary>
        public int BaseViewCount { get; set; }

        /// <summary>
        /// 推荐基数
        /// </summary>
        public int BaseRecommendeCount { get; set; }

        /// <summary>
        /// 收藏基数
        /// </summary>
        public int BaseFavoriteCount { get; set; }

        /// <summary>
        /// 点赞基数
        /// </summary>
        public int BaseThumbCount { get; set; }

        /// <summary>
        /// 分享基数
        /// </summary>
        public int BaseShareCount { get; set; }

        /// <summary>
        /// 分享标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 标语
        /// </summary>
        public string Slogan { get; set; }

        /// <summary>
        /// 分享描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 分享链接（可用于生成二维码链接）
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 分享小图片链接(分享链接的小图)
        /// </summary>
        public int SmallPictureId { get; set; }

        /// <summary>
        /// 分享大图片链接(分享链接的小图)
        /// </summary>
        public int BigPictureId { get; set; }

        /// <summary>
        /// 开启海报图片设置（海报/广告图）
        /// </summary>
        public bool EnableSharePicture { get; set; }

        /// <summary>
        /// 开启推广计数（计算推广阅读数，结算广告佣金）
        /// </summary>
        public bool EnablePromotion { get; set; }

        /// <summary>
        /// 推广佣金是否现金（现金直接提现或消费，不是现金，则是广告点只能通过兑换或客户产品购买后返佣）
        /// </summary>
        public bool CashPromotion { get; set; }

        /// <summary>
        /// 浏览计数比：访客浏览一次计算多少广告点数
        /// </summary>
        public decimal CommissionRatio { get; set; }

        /// <summary>
        /// 分享循环周期天数（每个周期内只统计一次分享链接）
        /// </summary>
        public int ShareCycleDays { get; set; }

        /// <summary>
        /// 指定到Store
        /// </summary>
        public int LimitToStoreId { get; set; }

        /// <summary>
        /// 指定到VendorStore
        /// </summary>
        public int LimitToVendorStoreId { get; set; }

        /// <summary>
        /// 指定到Brand
        /// </summary>
        public int LimitToBrandId { get; set; }

        /// <summary>
        /// 指定到Product
        /// </summary>
        public int LimitToProductId { get; set; }

        /// <summary>
        /// 展示分享人编码
        /// </summary>
        public bool DisplaySharerCode { get; set; }

        /// <summary>
        /// 展示分享人信息（如头像，昵称）
        /// </summary>
        public bool DisplaySharerUser { get; set; }
    }
}
