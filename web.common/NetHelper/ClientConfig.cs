
using System;
using System.Configuration;
namespace ola.lottery.Helper
{
    /// <summary>
    /// 客户端全局配置
    /// </summary>
    public class ClientConfig
    {
        private static string baseAddress;

        public static string BaseAddress
        {
            get
            {
                if (string.IsNullOrEmpty(baseAddress))
                {
                    baseAddress = ConfigurationManager.AppSettings["baseAddress"];
                }
                return ClientConfig.baseAddress;
            }
            set { ClientConfig.baseAddress = value; }
        }

    }
}
