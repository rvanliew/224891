using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NafTestForm.Interfaces
{
    public interface IEncompassClient
    {
        Task<HttpResponseMessage> GetAccessToken();
        Task<HttpResponseMessage> OrderService(string accessToken, string pipelineId, StringContent payload);
        Task<HttpResponseMessage> GetServiceStatus(string accessToken, string transactionId, string partnerId);
        Task<HttpResponseMessage> SubmitRequestForDuFiles(string accessToken, StringContent payload, string partnerId);
        Task<HttpResponseMessage> DownloadReportFile(string url, string elliSignature);
        Task<HttpResponseMessage> GetAusTrackingLogs(string accessToken, string loanGuid);
        Task<HttpResponseMessage> CreateAusTrackingLog(string accessToken, string loanGuid, StringContent payload);
        Task<HttpResponseMessage> GetLoan(string accessToken, string loanGuid);
        Task<HttpResponseMessage> GetListofUsers(string accessToken);
    }
}
