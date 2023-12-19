using EllieMae.Encompass.Automation;
using NafTestForm.Interfaces;
using NafTestForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NafTestForm.Services
{
    public class OrderService
    {
        private readonly TokenHandler _tokenHandler;
        private readonly IEncompassClient _client;
        private InputForm _inputForm { get; set; }

        public OrderService(TokenHandler tokenHandler, IEncompassClient client, InputForm inputForm)
        {
            _tokenHandler = tokenHandler;
            _client = client;
            _inputForm = inputForm;
        }

        public async Task OrderDU()
        {
            var token = await _tokenHandler.GetEncompassToken();
            if (token == null)
            {
                _inputForm.mtbServiceOutput.Text += $"Token is null, something went wrong.";
            }
            else
            {
                _inputForm.mtbServiceOutput.Text += $"AccessToken: {token.AccessToken}";
            }

            var payload = CreateNewServiceRequestPayload();
            string payloadDisplayContent = await payload.ReadAsStringAsync();
            _inputForm.mtbServiceOutput.Text += payloadDisplayContent;
            var orderServiceResponse = await _client.OrderService(token.AccessToken, "10000034", payload);

            if (orderServiceResponse.IsSuccessStatusCode)
            {
                var content = await orderServiceResponse.Content.ReadAsStringAsync();
                _inputForm.mtbServiceOutput.Text += Environment.NewLine;
                _inputForm.mtbServiceOutput.Text += $"{content}";
            }
        }

        private StringContent CreateNewServiceRequestPayload()
        {
            var payload = new NewOrderPayloadModel
            {
                newProduct = new NewProduct
                {
                    entityRef = new NewEntityRef
                    {
                        entityId = $"{EncompassApplication.CurrentLoan.Guid}#_borrower1",
                        entityType = "urn:elli:encompass:loan"
                    },
                    name = "AUS-DU",
                    credentials = new Credentials
                    {
                        userName = "2007676",
                        password = "N@f2023T",
                        //institutionID = "635904",
                        creditProviderUserName = "",
                        creditProviderPassword = ""
                    },
                    options = new NewOptions
                    {
                        requestType = "newOrder",
                        productDescription = "Standard LCOR",
                        //ausReportIdentifier = "",
                        creditProviderCode = "3",
                        orderCreditDetails = new OrderCreditDetail[]
                        {
                            new OrderCreditDetail
                            {
                                applicationID = "_borrower1",
                                creditReportIdentifier = ""
                            }
                        }
                    },
                    preferences = new Preferences
                    {
                        importConditions = "",
                        conditionType = ""
                    }
                }
            };

            var orderServiceContent = new StringContent(
                JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            return orderServiceContent;
        }
    }
}
