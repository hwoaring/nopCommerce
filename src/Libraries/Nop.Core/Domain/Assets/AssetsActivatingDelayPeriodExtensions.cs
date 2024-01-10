namespace Nop.Core.Domain.Assets
{
    /// <summary>
    /// 日期转换
    /// </summary>
    public static class AssetsActivatingDelayPeriodExtensions
    {
        /// <summary>
        /// Returns a delay period before activating points in hours
        /// </summary>
        /// <param name="period">Reward points activating delay period</param>
        /// <param name="value">Value of delay</param>
        /// <returns>Value of delay in hours</returns>
        public static int ToHours(this AssetsActivatingDelayPeriod period, int value)
        {
            return period switch
            {
                AssetsActivatingDelayPeriod.Hours => value,
                AssetsActivatingDelayPeriod.Days => value * 24,
                _ => throw new ArgumentOutOfRangeException(nameof(period)),
            };
        }
    }
}