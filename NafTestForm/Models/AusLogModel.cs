using Newtonsoft.Json;
using System;

namespace NafTestForm.Models
{
    public class AusApplication
    {

        [JsonProperty("entityId")]
        public string entityId { get; set; }

        [JsonProperty("entityType")]
        public string entityType { get; set; }

        [JsonProperty("entityUri")]
        public string entityUri { get; set; }
    }

    public class AusLogModel
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("application")]
        public AusApplication application { get; set; }

        [JsonProperty("uwRiskAssessType")]
        public string uwRiskAssessType { get; set; }

        [JsonProperty("submissionDate")]
        public DateTime submissionDate { get; set; }

        [JsonProperty("firstSubmissionDate")]
        public DateTime firstSubmissionDate { get; set; }

        [JsonProperty("submissionNumber")]
        public string submissionNumber { get; set; }

        [JsonProperty("recommendation")]
        public string recommendation { get; set; }

        [JsonProperty("duCaseIdOrLPAUSKey")]
        public string duCaseIdOrLPAUSKey { get; set; }

        [JsonProperty("submittedBy")]
        public string submittedBy { get; set; }

        [JsonProperty("version")]
        public string version { get; set; }
    }
}
