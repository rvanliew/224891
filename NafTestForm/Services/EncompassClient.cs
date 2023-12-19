using NafTestForm.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NafTestForm.Extensions;
using Newtonsoft.Json;
using NafTestForm.Global;

namespace NafTestForm.Services
{
    public class EncompassClient : IEncompassClient
    {
        private readonly HttpClient _httpClient;

        public EncompassClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.elliemae.com");
            _httpClient = client;
        }

        public async Task<HttpResponseMessage> GetAccessToken()
        {
            var parameters = new Dictionary<string, string>
            {
                {"grant_type", "password" },
                {"username", $"ron.vanliew@encompass:TEBE11218921" },
                {"password", $"DEVMontana1!" },
                {"client_id", $"60bgkn0" },
                {"client_secret", $"iHWiiMW1*#sEIn4iyop3U4i*bsgcJ8GQ8BHSQdSWlvngH2mm072E29vb0RP5zRzj" },
                {"scope", "lp" }
            };
            var content = new FormUrlEncodedContent(parameters);
            var response = await _httpClient.PostAsync("oauth2/v1/token", content);
            return response;
        }

        public async Task<HttpResponseMessage> OrderService(string accessToken, string partnerId, StringContent payload)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://api.elliemae.com/services/v1/partners/{partnerId}/transactions"),
                Content = payload
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> GetServiceStatus(string accessToken, string transactionId, string partnerId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.elliemae.com/services/v1/partners/{partnerId}/transactions/{transactionId}?generateFileUrls=true")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> SubmitRequestForDuFiles(string accessToken, StringContent payload, string partnerId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://api.elliemae.com/services/v1/partners/{partnerId}/transactions"),
                Content = payload
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> DownloadReportFile(string url, string elliSignature)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{url}")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", elliSignature);
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        public Task<HttpResponseMessage> GetAusTrackingLogs(string accessToken, string loanGuid)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> CreateAusTrackingLog(string accessToken, string loanGuid, StringContent payload)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetLoan(string accessToken, string loanGuid)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> GetListofUsers(string accessToken)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.elliemae.com/encompass/v1/company/users")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.SendAsync(request);
            return response;
        }
    }
}
