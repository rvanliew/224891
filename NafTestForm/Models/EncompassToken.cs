using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NafTestForm.Models
{
    public class EncompassToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("exp")]
        public long Exp { get; set; }
        [JsonProperty("sub")]
        public string Sub { get; set; }
        [JsonProperty("bearer_token")]
        public string BearerToken { get; set; }
        [JsonProperty("encompass_instance_id")]
        public string EncompassInstanceId { get; set; }
        [JsonProperty("user_name")]
        public string User_Name { get; set; }
        [JsonProperty("user_key")]
        public string UserKey { get; set; }
        [JsonProperty("encompass_user")]
        public string EncompassUser { get; set; }
        [JsonProperty("identity_type")]
        public string IdentityType { get; set; }
        [JsonProperty("encompass_client_id")]
        public string EncompassClientId { get; set; }
        [JsonProperty("realm_name")]
        public string RealmName { get; set; }
    }
}
