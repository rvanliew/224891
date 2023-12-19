using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NafTestForm.Models
{
    public class NewEntityRef
    {
        [JsonProperty("entityId")]
        public string entityId { get; set; }

        [JsonProperty("entityType")]
        public string entityType { get; set; }
    }

    public class Credentials
    {
        [JsonProperty("userName")]
        public string userName { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("creditProviderUserName")]
        public string creditProviderUserName { get; set; }

        [JsonProperty("creditProviderPassword")]
        public string creditProviderPassword { get; set; }
    }

    public class OrderCreditDetail
    {
        [JsonProperty("applicationID")]
        public string applicationID { get; set; }

        [JsonProperty("creditReportIdentifier")]
        public string creditReportIdentifier { get; set; }
    }

    public class NewOptions
    {
        [JsonProperty("requestType")]
        public string requestType { get; set; }

        [JsonProperty("productDescription")]
        public string productDescription { get; set; }

        [JsonProperty("creditProviderCode")]
        public string creditProviderCode { get; set; }

        [JsonProperty("orderCreditDetails")]
        public IList<OrderCreditDetail> orderCreditDetails { get; set; }
    }

    public class Preferences
    {
        [JsonProperty("importConditions")]
        public string importConditions { get; set; }

        [JsonProperty("conditionType")]
        public string conditionType { get; set; }
    }

    public class NewProduct
    {
        [JsonProperty("entityRef")]
        public NewEntityRef entityRef { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("credentials")]
        public Credentials credentials { get; set; }

        [JsonProperty("options")]
        public NewOptions options { get; set; }

        [JsonProperty("preferences")]
        public Preferences preferences { get; set; }
    }

    public class NewOrderPayloadModel
    {
        [JsonProperty("product")]
        public NewProduct newProduct { get; set; }
    }
}
