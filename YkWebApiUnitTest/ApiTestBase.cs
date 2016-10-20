using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Web.Http;
using Newtonsoft.Json;

namespace YkWebApiUnitTest
{
    public abstract class ApiTestBase
    {

       /// <summary>
       /// 注册ApiController所在程序集的路由配置
       /// </summary>
        protected abstract void RegisterRoute(HttpConfiguration config);

        /// <summary>
        /// 模拟Api请求的基地址
        /// </summary>
        /// <returns></returns>
        protected virtual string GetBaseAddress()=>"http://localhost";

        protected string Get(string api)
        {
            using (var invoker = CreateMessageInvoker())
            {
                using (var cts = new CancellationTokenSource())
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, GetBaseAddress() + api);
                    using (HttpResponseMessage response = invoker.SendAsync(request, cts.Token).Result)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                }
            }
        }

        protected TResult Get<TResult>(string api) where TResult:new()
        {
            return JsonConvert.DeserializeObject<TResult>(Get(api));
        }

        protected TResult Post<TResult>(string api, object arg=null) where TResult : new()
        {
            var invoker = CreateMessageInvoker();
            using (var cts = new CancellationTokenSource())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, GetBaseAddress() + api);
                if(arg!=null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(arg),Encoding.UTF8,"application/json");
                }
                using (HttpResponseMessage response = invoker.SendAsync(request, cts.Token).Result)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<TResult>(result);
                }
            }
        }

        private HttpMessageInvoker CreateMessageInvoker()
        {
            var config = new HttpConfiguration();
            RegisterRoute(config);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            var server = new HttpServer(config);
            var messageInvoker = new HttpMessageInvoker(server);
            return messageInvoker;
        }
    }
}
