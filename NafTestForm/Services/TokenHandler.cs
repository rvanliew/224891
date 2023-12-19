using NafTestForm.Interfaces;
using NafTestForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NafTestForm.Services
{
    public class TokenHandler
    {
        private readonly IEncompassClient _encompassClient;
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private static EncompassToken _encompassToken = new EncompassToken();

        public TokenHandler(IEncompassClient encompassClient)
        {
            _encompassClient = encompassClient;
        }

        public async Task<EncompassToken> GetEncompassToken()
        {
            await _semaphore.WaitAsync();
            try
            {
                if (!EncompassTokenIsActive())
                {
                    await RequestEncompassToken();
                }
            }
            finally
            {
                _semaphore.Release();
            }
            return _encompassToken;
        }

        public bool EncompassTokenIsActive()
        {
            if (string.IsNullOrWhiteSpace(_encompassToken.AccessToken))
            {
                return false;
            }
            var offset = DateTimeOffset.FromUnixTimeSeconds(_encompassToken.Exp);
            if (DateTime.UtcNow.AddMinutes(5) < offset.UtcDateTime)
            {
                return true;
            }
            return false;
        }

        public async Task RequestEncompassToken()
        {
            var response = await _encompassClient.GetAccessToken();
            var responseContent = await response.Content.ReadAsStringAsync();
            var newToken = JsonConvert.DeserializeObject<EncompassToken>(responseContent);
            _encompassToken = newToken;
        }
    }
}
