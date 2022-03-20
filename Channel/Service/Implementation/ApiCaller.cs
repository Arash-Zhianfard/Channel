using Newtonsoft.Json;
using Service.Interfaces;
using Service.Model;
using System.Net;
using System.Text;

namespace Service.Implementation
{
    public class ApiCaller : IApiCaller
    {
        public async Task<T> GetAsync<T>(RequestOption requestOption)
        {
            ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => true;

            var httpClient = new HttpClient();
            var builder = new UriBuilder(requestOption.Url);
            if (requestOption.HeaderParameters != null)
            {
                foreach (var header in requestOption.HeaderParameters)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            if (requestOption.QueryStringItems != null)
            {
                var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
                foreach (var item in requestOption.QueryStringItems)
                {
                    queryString.Add(item.Key, item.Value);
                }
                builder.Query = queryString.ToString();
            }
            if (requestOption.Timeout.HasValue)
                httpClient.Timeout = requestOption.Timeout.Value;

            using (var response = await httpClient.GetAsync(builder.ToString()))
            {
                try
                {
                    var result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    });
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex();
                }
            }
        }

        public async Task<T> PutAsync<T>(RequestOption requestOption)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => true;
            var httpClient = new HttpClient();
            var builder = new UriBuilder(requestOption.Url);
            StringContent httpContent = null;
            string jsonBody = null;
            if (requestOption.HeaderParameters != null)
            {
                foreach (var header in requestOption.HeaderParameters)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            if (requestOption.Body != null)
            {
                jsonBody = JsonConvert.SerializeObject(requestOption.Body,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });
                httpContent = new StringContent(jsonBody, Encoding.UTF8, requestOption.ContentType);
            }
            if (requestOption.Timeout.HasValue)
                httpClient.Timeout = requestOption.Timeout.Value;
            if (requestOption.QueryStringItems != null)
            {
                var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
                foreach (var item in requestOption.QueryStringItems)
                {
                    queryString.Add(item.Key, item.Value);
                }
                builder.Query = queryString.ToString();
            }
            try
            {
                using (var response = await httpClient.PutAsync(builder.ToString(), httpContent))
                {

                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
