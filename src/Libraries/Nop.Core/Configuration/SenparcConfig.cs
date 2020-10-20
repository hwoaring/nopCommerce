namespace Nop.Core.Configuration
{
    /// <summary>
    /// Represents SenparcSetting configuration parameters
    /// </summary>
    public partial class SenparcSettingTemp : IConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsDebug { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        public string DefaultCacheNamespace { get; set; } = "DefaultCache";
        /// <summary>
        /// Redis配置 #{Cache_Redis_Configuration}#
        /// </summary>
        public string Cache_Redis_Configuration { get; set; } = string.Empty;
        /// <summary>
        /// Memcached配置 #{Cache_Memcached_Configuration}#
        /// </summary>
        public string Cache_Memcached_Configuration { get; set; } = string.Empty;
        /// <summary>
        /// SenparcUnionAgentKey
        /// </summary>
        public string SenparcUnionAgentKey { get; set; } = "#{SenparcUnionAgentKey}#";
    }
}