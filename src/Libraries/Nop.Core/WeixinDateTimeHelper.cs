using System.Security.Cryptography;

namespace Nop.Core
{
    /// <summary>
    /// Weixin Date Time Helper class
    /// </summary>
    public partial class WeixinDateTimeHelper
    {
        private static readonly DateTimeOffset _baseTime = new(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        #region  === 微信类时间助手 ===

        /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromXml(long dateTimeFromXml)
        {
            return GetDateTimeOffsetFromXml(dateTimeFromXml).LocalDateTime;
        }

        /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromXml(string dateTimeFromXml)
        {
            return GetDateTimeFromXml(long.Parse(dateTimeFromXml));
        }

        /// <summary>
        /// 转换微信DateTimeOffset时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTimeOffset GetDateTimeOffsetFromXml(long dateTimeFromXml)
        {
            return _baseTime.AddSeconds(dateTimeFromXml).ToLocalTime();
        }

        /// <summary>
        /// 转换微信DateTimeOffset时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTimeOffset GetDateTimeOffsetFromXml(string dateTimeFromXml)
        {
            return GetDateTimeFromXml(long.Parse(dateTimeFromXml));
        }

        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long GetUnixDateTime(DateTimeOffset dateTime)
        {
            return (long)(dateTime - _baseTime).TotalSeconds;
        }

        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long GetUnixDateTime(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - _baseTime).TotalSeconds;
        }


        #endregion
    }
}
