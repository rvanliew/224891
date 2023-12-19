using NafTestForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NafTestForm.Models
{
    public class Resource
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("mimeType")]
        public string mimeType { get; set; }

        [JsonProperty("elli-signature")]
        public string ellisignature { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }
    }

    public class StatusEntityRef
    {
        [JsonProperty("entityId")]
        public string entityId { get; set; }

        [JsonProperty("entityType")]
        public string entityType { get; set; }
    }

    public class StatusProduct
    {
        [JsonProperty("partnerID")]
        public string partnerID { get; set; }

        [JsonProperty("productName")]
        public string productName { get; set; }

        [JsonProperty("displayName")]
        public string displayName { get; set; }

        [JsonProperty("category")]
        public string category { get; set; }

        [JsonProperty("entityRef")]
        public StatusEntityRef entityRef { get; set; }

        [JsonProperty("creationDate")]
        public DateTime creationDate { get; set; }

        [JsonProperty("lastUpdatedDate")]
        public DateTime lastUpdatedDate { get; set; }

        [JsonProperty("orderedBy")]
        public string orderedBy { get; set; }
    }

    public class StatusResponseModel
    {

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("resources")]
        public IList<Resource> resources { get; set; }

        [JsonProperty("product")]
        public StatusProduct product { get; set; }
    }
}
