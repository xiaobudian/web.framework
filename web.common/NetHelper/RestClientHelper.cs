using System;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ola.lottery.Helper
{
    /// <summary>
    /// Request Helper
    /// 
    /// Method: Get and Post
    /// Async: True
    /// </summary>
    public class RestClientHelper
    {
        /// <summary>
        /// 初始化Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static RestRequest InitGetRequest(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception("url is incorrect.");
            }
            return new RestRequest(url, Method.GET);
        }

        /// <summary>
        /// Async Get Request
        /// </summary>
        /// <param name="url">请求地址 格式controller/action?parames</param>
        /// <param name="action">回调函数</param>
        public static void Get(string url, Action<string> action)
        {
            var request = InitGetRequest(url);
            client.ExecuteAsync(request, response =>
            {
                action(response.Content);
            });
        }

        /// <summary>
        /// Async Get<T> Request
        /// </summary>
        /// <param name="url">请求地址 格式controller/action?parames</param>
        /// <param name="action">回调函数</param>
        public static void Get<T>(string url, Action<IRestResponse<T>> action) where T : new()
        {
            var request = InitGetRequest(url);
            // async with deserialization
            var asyncHandle = client.ExecuteAsync<T>(request, response =>
            {
                action(response);
            });
        }

        /// <summary>
        /// 初始化Post请求
        /// </summary>
        /// <param name="url">请求地址 格式controller/action?parames</param>
        /// <param name="body">Body</param>
        /// <param name="userInfo">认证信息</param>
        /// <returns></returns>
        private static RestRequest InitPostRequest(string url, object body, string userInfo)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception("url is incorrect.");
            }
            var request = new RestRequest(url, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            //use json need set XmlSerializer null
            request.XmlSerializer = null;
            // easily add HTTP Headers
            if (userInfo != null)
            {
                request.AddHeader("olaAuth", userInfo);
            }
            if (body != null)
            {
                request.AddBody(body);
            }
            return request;
        }

        public static void Postasync(string url, object body, string userInfo, Action<string> action)
        {
            var request = InitPostRequest(url, body, userInfo);

            // easy async support
            client.ExecuteAsync(request, response =>
            {
                action(response.Content);
            });
        }

        public static IRestResponse Post(string url, object body, string userInfo)
        {
            var request = InitPostRequest(url, body, userInfo);

            // easy async support
            var response = client.Post(request);
            return response;

        }

        public static void Postasync<T>(string url, object body, string userInfo, Action<IRestResponse<T>> action) where T : new()
        {
            var request = InitPostRequest(url, body, userInfo);
            // async with deserialization
            var asyncHandle = client.ExecuteAsync<T>(request, response =>
            {
                action(response);
            });
        }

        public static IRestResponse<T> Post<T>(string url, object body, string userInfo) where T : new()
        {
            var request = InitPostRequest(url, body, userInfo);
            // async with deserialization
            return client.Post<T>(request);
        }

        private static RestClient client = new RestClient()
        {
            BaseUrl = new Uri(ClientConfig.BaseAddress)
        };
    }
}
