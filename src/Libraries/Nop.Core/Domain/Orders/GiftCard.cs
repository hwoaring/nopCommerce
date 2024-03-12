using Nop.Core.Domain.Catalog;

namespace Nop.Core.Domain.Orders;

/// <summary>
/// Represents a gift card
/// </summary>
public partial class GiftCard : BaseEntity
{
    /// <summary>
    /// Gets or sets the associated order item identifier
    /// </summary>
    public int? PurchasedWithOrderItemId { get; set; }

    /// <summary>
    /// Gets or sets the gift card type identifier
    /// </summary>
    public int GiftCardTypeId { get; set; }

    /// <summary>
    /// Gets or sets the amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether gift card is activated
    /// </summary>
    public bool IsGiftCardActivated { get; set; }

    /// <summary>
    /// Gets or sets a gift card coupon code
    /// </summary>
    public string GiftCardCouponCode { get; set; }

    /// <summary>
    /// Gets or sets a recipient name
    /// </summary>
    public string RecipientName { get; set; }

    /// <summary>
    /// Gets or sets a recipient email
    /// </summary>
    public string RecipientEmail { get; set; }

    /// <summary>
    /// Gets or sets a sender name
    /// </summary>
    public string SenderName { get; set; }

    /// <summary>
    /// Gets or sets a sender email
    /// </summary>
    public string SenderEmail { get; set; }

    /// <summary>
    /// Gets or sets a message
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether recipient is notified
    /// </summary>
    public bool IsRecipientNotified { get; set; }

    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the gift card type
    /// </summary>
    public GiftCardType GiftCardType
    {
        get => (GiftCardType)GiftCardTypeId;
        set => GiftCardTypeId = (int)value;
    }


    #region

    /// <summary>
    /// 卡券密码（可以通过设置密码，保持couponcode不变情况下禁止他人消费）
    /// </summary>
    public string GiftCardPassword { get; set; }

    /// <summary>
    /// 接收人电话
    /// </summary>
    public string RecipientPhone { get; set; }

    /// <summary>
    /// 发送人电话
    /// </summary>
    public string SenderPhone { get; set; }

    /// <summary>
    /// 有效期开始日期
    /// </summary>
    public DateTime? GiftCardStartUseDateTimeUtc { get; set; }

    /// <summary>
    /// 最大有效期结束日期
    /// </summary>
    public DateTime? GiftCardEndUseDateTimeUtc { get; set; }

    #endregion


}
