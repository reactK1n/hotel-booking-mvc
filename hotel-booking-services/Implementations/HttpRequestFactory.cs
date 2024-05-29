using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class HttpRequestFactory : IHttpRequestFactory
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _url;
        public HttpRequestFactory(IHttpClientFactory clientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
            // _url = configuration["BaseUrl"];
            _url = " http://localhost:5000";

		}

        public async Task<TRes> GetRequestAsync<TRes>(string requestUrl, string baseUrl = null) where TRes : class
        {
            var client = CreateClient(baseUrl);
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            return await GetResponseResultAsync<TRes>(client, request);
        }
        public async Task<TRes> PostRequestAsync<TReq, TRes>(string requestUrl, TReq content, string baseUrl = null) where TRes : class where TReq : class
        {
            var client = CreateClient(baseUrl);
            var reqContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl) { Content = reqContent };
            return await GetResponseResultAsync<TRes>(client, request);
        }
        public async Task<TRes> UpdateRequestAsync<TReq, TRes>(string requestUrl, TReq content, string baseUrl = null) where TRes : class where TReq : class
        {
            var client = CreateClient(baseUrl);
            var reqContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Patch, requestUrl) { Content = reqContent };
            return await GetResponseResultAsync<TRes>(client, request);
        }

        public async Task<TRes> DeleteRequestAsync<TRes>(string requestUrl, string baseUrl = null) where TRes : class
        {
            var client = CreateClient(baseUrl);
            var request = new HttpRequestMessage(HttpMethod.Delete, requestUrl);
            return await GetResponseResultAsync<TRes>(client, request);
        }

        public async Task<TRes> UploadFileAsync<TReq, TRes>(string requestUrl, TReq file, string baseUrl = null) where TReq : IFormFile where TRes : class
        {
            var client = CreateClient(baseUrl);
            var form = new MultipartFormDataContent();
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var fileContent = new ByteArrayContent(memoryStream.ToArray());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, nameof(file), file.FileName);
            }
            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl) { Content = form };
            return await GetResponseResultAsync<TRes>(client, request);
        }

        private async Task<TRes> GetResponseResultAsync<TRes>(HttpClient client, HttpRequestMessage request) where TRes : class
        {
            var response = await client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TRes>(responseString);
            return result;
        }

        private HttpClient CreateClient(string baseUrl = null)
        {
            baseUrl ??= _url;
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(baseUrl);
            var token = _httpContextAccessor.HttpContext.Session.GetString("access_token");

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
            return client;
        }
    }
}
