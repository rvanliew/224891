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

namespace NafTestForm.Interfaces
{
    public interface IEncompassCredentials
    {
        string User { get; set; }
        string Password { get; set; }
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string Instance { get; set; }
    }

    public class EncompassCredentials : IEncompassCredentials
    {
        private readonly IConfiguration _configuration;
        public EncompassCredentials(IConfiguration configuration)
        {
            _configuration = configuration;

            // Todo : encode configuration data
            User = _configuration.GetRequiredValue<string>("Encompass:User:Id");
            Password = _configuration.GetRequiredValue<string>("Encompass:User:Password");
            ClientId = _configuration.GetRequiredValue<string>("Encompass:Client:Id");
            ClientSecret = _configuration.GetRequiredValue<string>("Encompass:Client:Secret");
            Instance = _configuration.GetRequiredValue<string>("Encompass:Client:Instance");
        }

        public string User { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Instance { get; set; }
    }
}
