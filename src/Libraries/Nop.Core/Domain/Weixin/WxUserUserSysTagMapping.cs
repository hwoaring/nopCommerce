namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an WxUserUserSysTagMapping
    /// </summary>
    public partial class WxUserUserSysTagMapping : BaseEntity
    {
        public int CustomerId { get; set; }

        public int WxUserSysTagId { get; set; }
    }
}
