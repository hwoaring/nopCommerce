namespace Nop.Core.Configuration
{
    /// <summary>
    /// 微信SenparcSetting
    /// </summary>
    public partial class SenparcSetting : IConfig
    {
        //以下为 CO2NET 的 SenparcSetting 全局配置，请勿修改 key，勿删除任何项

        public bool IsDebug { get; protected set; } = true;

        public string DefaultCacheNamespace { get; protected set; } = "DefaultCache";

        //分布式缓存
        /// <summary>
        /// Redis配置
        /// "Cache_Redis_Configuration": "localhost:6379",//不包含密码
        /// "Cache_Redis_Configuration": "localhost:6379,password=senparc,connectTimeout=1000,connectRetry=2,syncTimeout=10000,defaultDatabase=3",//密码及其他配置
        /// </summary>
        public string Cache_Redis_Configuration { get; protected set; } = "#{Cache_Redis_Configuration}#";

        /// <summary>
        /// Memcached配置
        /// </summary>
        public string Cache_Memcached_Configuration { get; protected set; } = "#{Cache_Memcached_Configuration}#";
        /// <summary>
        /// SenparcUnionAgentKey配置
        /// </summary>
        public string SenparcUnionAgentKey { get; protected set; } = "#{SenparcUnionAgentKey}#";
    }
}