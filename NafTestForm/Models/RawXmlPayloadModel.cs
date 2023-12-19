using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NafTestForm.Models
{
    public class XmlEntityRef
    {
        [JsonProperty("entityId")]
        public string entityId { get; set; }

        [JsonProperty("entityType")]
        public string entityType { get; set; }
    }

    public class XmlOptions
    {
        [JsonProperty("requestType")]
        public string requestType { get; set; }

        [JsonProperty("applicationID")]
        public string applicationID { get; set; }

        [JsonProperty("reportIdentifier")]
        public string reportIdentifier { get; set; }

        [JsonProperty("loanAttachments")]
        public string loanAttachments { get; set; }
    }

    public class XmlProduct
    {
        [JsonProperty("entityRef")]
        public XmlEntityRef entityRef { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("options")]
        public XmlOptions options { get; set; }
    }

    public class RawXmlPayloadModel
    {
        [JsonProperty("product")]
        public XmlProduct xmlProduct { get; set; }
    }
}
