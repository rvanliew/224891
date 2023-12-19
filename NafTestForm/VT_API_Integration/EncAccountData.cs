using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.Collections;
using NafTestForm.Extensions;
using NafTestForm.Interfaces;
using NafTestForm.Models;
using NafTestForm.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NafTestForm.VT_API_Integration
{
    public class EncAccountData
    {
        //private List<EncompassUserModel> _encUserDataList = new List<EncompassUserModel>();
        private InputForm _inputForm { get; set; }
        private readonly TokenHandler _tokenHandler;
        private readonly IEncompassClient _client;

        public EncAccountData(InputForm inputForm, TokenHandler tokenHandler, IEncompassClient encompassClient) 
        {
            _tokenHandler = tokenHandler;
            _client = encompassClient;
            _inputForm = inputForm;
        }

        public async void DisplayUserData()
        {
            //await GetUserPersonas();

            //StringBuilder sb = new StringBuilder();

            //foreach (var user in _encUserDataList)
            //{
            //    // reset account status variable for each user
            //    string accountStatus = string.Empty;

            //    // check if user is disabled in encompass
            //    foreach(string status in user.userIndicators)
            //    {
            //        if(!status.Contains("Disabled"))
            //        {
            //            accountStatus = status;
            //        }
            //    }

            //    sb.Append($"FN: {user.firstName} | LN: {user.lastName} | Email: {user.email} | Phone: {user.phone} | Status: {accountStatus} " +
            //        $"VT_AccountType: {user.accountType}\r");

            //    // super admins and a few other misc users don't belong to an org so this will return an object not set to an instance reference
            //    // might need to hard code a value for org id for these specific cases
            //    try
            //    {
            //        sb.Append($"OrgId: {user.organization.entityId}\r");
            //    }
            //    catch(Exception ex)
            //    {
            //        sb.Append($"OrgId: Null\r");
            //    }

            //    sb.Append('\n');
            //}

            //sb.Append($"User Count = {_encUserDataList.Count}");

            //// write data to an output multiline textbox
            //// testing purposes only
            //_inputForm.mtbUserData.Text = sb.ToString();
        }

        private async Task GetUserPersonas()
        {
            // get encompass token
            //var token = await _tokenHandler.GetEncompassToken();

            //if(token != null)
            //{
            //    // get list of all users (v1 api call)
            //    var encUserResponse = await _client.GetListofUsers(token.AccessToken);

            //    // if api call was successful
            //    if (encUserResponse.IsSuccessStatusCode)
            //    {
            //        var content = await encUserResponse.Content.ReadAsStringAsync();
            //        var userData = JsonConvert.DeserializeObject<List<EncompassUserModel>>(content);

            //        // check there is data in the response
            //        if(userData != null)
            //        {
            //            // loop over userData object list
            //            foreach (EncompassUserModel user in userData)
            //            {
            //                // check if user has any of the following personas
            //                foreach (var persona in user.personas)
            //                {
            //                    if (persona.entityName.EqualsAnyOf(Global.Personas.loanProcessor,
            //                        Global.Personas.productionAssistant,
            //                        Global.Personas.appraisalOrdering,
            //                        Global.Personas.opsManager,
            //                        Global.Personas.superAdmin))
            //                    {
            //                        // check if user is a VT admin
            //                        if (user.email.EqualsAnyOf(Global.VtAdmins.mRogers, Global.VtAdmins.dHorton, Global.VtAdmins.mLamb, Global.VtAdmins.kRutherford,
            //                            Global.VtAdmins.nThomas, Global.VtAdmins.jHanley, Global.VtAdmins.rCoss, Global.VtAdmins.sDelatorre, Global.VtAdmins.sVillalobos,
            //                            Global.VtAdmins.mVesey, Global.VtAdmins.jFerri, Global.VtAdmins.nLofton, Global.VtAdmins.cBengtson, Global.VtAdmins.jBell,
            //                            Global.VtAdmins.aKumar, Global.VtAdmins.bSharp, Global.VtAdmins.mLopez, Global.VtAdmins.vMelgarejo, Global.VtAdmins.nPorter,
            //                            Global.VtAdmins.gSmith, Global.VtAdmins.rVanliew))
            //                        {
            //                            // set account type to 1 (admin)
            //                            user.accountType = 1;
            //                            _encUserDataList.Add(user);
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            // set account type to 15 (employee)
            //                            user.accountType = 15;
            //                            _encUserDataList.Add(user);
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //        }                                  
            //    }
            //    else
            //    {
            //        // log error
            //        Macro.Alert("Error retrieving list of all users API call");
            //    }
            //}
            //else
            //{
            //    // error could not retrieve encompass token
            //    Macro.Alert("Encompass API token is null");
            //}
        }
    }
}
