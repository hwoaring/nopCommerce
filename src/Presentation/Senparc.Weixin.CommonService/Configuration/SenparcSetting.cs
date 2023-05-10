namespace Nop.Core.Configuration
{
    /// <summary>
    /// Represents SenparcSetting parameters
    /// </summary>
    public partial class SenparcSetting : IConfig
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SenparcSetting() : this(isDebug: false) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isDebug"></param>
        public SenparcSetting(bool isDebug) { IsDebug = isDebug; }

        public bool IsDebug { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public string DefaultCacheNamespace { get; protected set; } = "DefaultCache";

        //分布式缓存
        /// <summary>
        /// Redis配置
        ///"Cache_Redis_Configuration": "localhost:6379",//不包含密码
        ///"Cache_Redis_Configuration": "localhost:6379,password=senparc,connectTimeout=1000,connectRetry=2,syncTimeout=10000,defaultDatabase=3",//密码及其他配置
        /// </summary>
        public string Cache_Redis_Configuration { get; protected set; } = "#{Cache_Redis_Configuration}#";

        /// <summary>
        /// Memcached配置
        /// </summary>
        public string Cache_Memcached_Configuration { get; protected set; } = "#{Cache_Memcached_Configuration}#";

        /// <summary>
        /// SenparcUnionAgentKey
        /// </summary>
        public string SenparcUnionAgentKey { get; protected set; } = "#{SenparcUnionAgentKey}#";

    }
}