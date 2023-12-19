using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects.Contacts;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.Collections;
using EllieMae.Encompass.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NafTestForm.Extensions;
using Newtonsoft.Json;
using System.Net.Http;

namespace NafTestForm._210323
{
    public class Main_210323
    {
        private InputForm _inputForm { get; set; }

        public Main_210323(InputForm inputForm)
        {
            _inputForm = inputForm;
        }

        public void Execute()
        {
            RunEpoQueryCheck();
        }

        private void RunEpoQueryCheck()
        {
            //Only for Non-Purchase loans and if EPO hasn't been checked
            if (EncompassApplication.CurrentLoan.Fields["19"].FormattedValue.Equals("Purchase") ||
                EncompassApplication.CurrentLoan.Fields["CX.EPO.CHECK"].FormattedValue.Equals("X", StringComparison.OrdinalIgnoreCase) ||
                EncompassApplication.CurrentLoan.Fields["3142"].UnformattedValue == string.Empty)
            {
                _inputForm.tbLoanReqsMet.Text = "False";
                return;
            }

            //noCoapplicant is true, no Co-Borrower
            bool checkEpo = false;
            bool noCoapplicant = EncompassApplication.CurrentLoan.Fields["3840"].FormattedValue == "Y";
            if (!noCoapplicant)
            {
                if (!string.IsNullOrEmpty(EncompassApplication.CurrentLoan.Fields["65"].FormattedValue) &&
                !string.IsNullOrEmpty(EncompassApplication.CurrentLoan.Fields["URLA.X73"].FormattedValue) &&
                !string.IsNullOrEmpty(EncompassApplication.CurrentLoan.Fields["97"].FormattedValue))
                {
                    checkEpo = true;
                    _inputForm.mtbOutputTest.Text = "checkEpo = true";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(EncompassApplication.CurrentLoan.Fields["65"].FormattedValue) &&
                !string.IsNullOrEmpty(EncompassApplication.CurrentLoan.Fields["URLA.X73"].FormattedValue))
                {
                    checkEpo = true;
                    _inputForm.mtbOutputTest.Text = "checkEpo = true";
                }
            }

            if (checkEpo)
            {
                try
                {
                    _inputForm.mtbOutputTest.Text = string.Empty;
                    PrepareAndExecuteQuery();
                }
                catch (Exception ex)
                {
                    _inputForm.mtbOutputTest.Text = $"{ex.Message}";
                }
                finally
                {
                    Loan loan = EncompassApplication.CurrentLoan;
                    loan.Fields["CX.EPO.CHECK"].Value = "X";
                }
            }
        }

        private void PrepareAndExecuteQuery()
        {
            Loan loan = EncompassApplication.CurrentLoan;
            if (loan == null)
            {
                return;
            }


            #region Borrower fields

            //SSN
            StringFieldCriterion ssn = new StringFieldCriterion();
            ssn.FieldName = "Fields.65";
            ssn.Value = String.Format("{0:000-00-0000}", Convert.ToInt64(loan.Fields["65"].Value));
            ssn.MatchType = StringFieldMatchType.Exact;

            #endregion

            #region Co-Borrower fields
            QueryCriterion borCoBor = null;
            //borCoBor = ssn;
            var cbSSN = Convert.ToString(loan.Fields["97"].Value);
            if (!string.IsNullOrEmpty(cbSSN))
            {
                //SSN
                StringFieldCriterion ssnCb = new StringFieldCriterion();
                ssnCb.FieldName = "Fields.97";
                ssnCb.Value = String.Format("{0:000-00-0000}", Convert.ToUInt64(cbSSN));
                ssnCb.MatchType = StringFieldMatchType.Exact;
                borCoBor = ssn.And(ssnCb);
            }
            else
                borCoBor = ssn;

            #endregion

            #region Property Address

            //SSN
            QueryCriterion propAdd = null;
            string bCurrAdd = string.Empty;
            string strAdd = Convert.ToString(loan.Fields["URLA.X73"].Value);
            if (!string.IsNullOrEmpty(strAdd))
            {
                string newAddr = CorrectAddress(strAdd);

                StringFieldCriterion propStrCrt = new StringFieldCriterion();
                propStrCrt.FieldName = "Fields.URLA.X73";
                int index = strAdd.IndexOf(' ', 0) + 1;
                propStrCrt.Value = index > strAdd.Length ? strAdd.Substring(0, 5) : strAdd.Substring(0, index);
                propStrCrt.MatchType = StringFieldMatchType.StartsWith;

                StringFieldCriterion propStrCrt1 = new StringFieldCriterion();
                propStrCrt1.FieldName = "Fields.URLA.X73";
                index = newAddr.IndexOf(' ', 0) + 1;
                propStrCrt1.Value = index > newAddr.Length ? newAddr.Substring(0, 5) : newAddr.Substring(0, index);
                propStrCrt1.MatchType = StringFieldMatchType.StartsWith;

                propAdd = propStrCrt.Or(propStrCrt1);
                borCoBor = borCoBor.And(propAdd);

                Address address = new Address();
                address.street_address = strAdd;
                address.city = Convert.ToString(loan.Fields["12"].Value);
                address.postal_code = Convert.ToString(loan.Fields["15"].Value);
                address.region = Convert.ToString(loan.Fields["14"].Value);
                address.iso_country_code = "US";
                bCurrAdd = address.street_address + " " + address.city + ", " + address.region + " " + address.postal_code;

                //string orginialKey = GetPlaceKeyString(address);

                address.street_address = newAddr;
                //string newKey = GetPlaceKeyString(address);

                //if (!string.Equals(orginialKey, newKey, StringComparison.InvariantCultureIgnoreCase))
                //{
                //    _inputForm.mtbOutputTest.Text = "Invalid property address.";
                //    return;
                //}
            }

            #endregion

            //Sort order by funding date
            SortCriterionList sortCriterion = new SortCriterionList();
            sortCriterion.Add(new SortCriterion("Fields.MS.FUN", SortOrder.Descending, DataConversion.DateTime));

            //<Kristine Sanchez - 05/23/2023 - ADO178033
            //Look for loans with Funded milestone date>
            DateFieldCriterion fundingDate = new DateFieldCriterion("Fields." + "MS.FUN", DateFieldCriterion.NonEmptyDate, OrdinalFieldMatchType.Equals, DateFieldMatchPrecision.Day);
            QueryCriterion query = borCoBor.And(fundingDate);
            PipelineCursor cursor = loan.Session.Loans.QueryPipelineEx(query, sortCriterion);
            if (cursor?.Count == 0)
            {
                _inputForm.mtbOutputTest.Text = "No loan found for search criteria.";
                return;
            }

            PipelineData data = cursor?.GetItem(0);
            if (data != null)
            {
                if (string.Equals(data["LoanNumber"].ToString(), loan.LoanNumber) && cursor?.Count == 1)
                {
                    _inputForm.mtbOutputTest.Text = $"cursor count: {cursor?.Count}\r" +
                        $"LoanNumber: {loan.LoanNumber}";
                    return;
                }

                if (string.Equals(data["LoanNumber"].ToString(), loan.LoanNumber) && cursor?.Count > 0)
                {
                    data = cursor?.GetItem(1);
                }

                if (data == null)
                {
                    return;
                }

                Loan dbLoan = loan.Session.Loans.Open(data.LoanIdentity.Guid);
                cursor?.Close();
                CheckEPO(loan, dbLoan, bCurrAdd);
                dbLoan?.Close();
            }
        }

        private void CheckEPO(Loan loanRequestingLockOn, Loan dbLoan, string currentAddress)
        {
            try
            {
                if (dbLoan != null)
                {
                    string prevloanNumber = Convert.ToString(dbLoan.Fields["364"]);
                    string prevFundingDate = Convert.ToString(dbLoan.Fields["MS.FUN"]);

                    string prevInvestor = String.Empty;
                    DateTime dateForEPO;
                    bool usePurchaseDate = false;
                    string productCode = string.Empty;
                    if (dbLoan.Fields["2370"].IsEmpty())
                    {
                        if (dbLoan.Fields["MS.FUN"].IsEmpty())
                        {
                            //ErrorMessage = "Loan does not have Purchase and Funded Date.";
                            return;
                        }

                        dateForEPO = Convert.ToDateTime(dbLoan.Fields["MS.FUN"].ToString());
                    }
                    else
                    {
                        productCode = Convert.ToString(dbLoan.Fields["1401"]);
                        if (String.IsNullOrEmpty(productCode))
                        {
                            //ErrorMessage = "Loan does not have Loan Program.";
                            return;
                        }

                        prevInvestor = Convert.ToString(dbLoan.Fields["VEND.X263"]);
                        usePurchaseDate = true;
                        dateForEPO = Convert.ToDateTime(dbLoan.Fields["2370"].ToString());
                    }

                    // Get Mapped Previous investor
                    string investor = String.Empty;
                    if (!string.IsNullOrEmpty(prevInvestor))
                    {
                        //investors.TryGetValue(prevInvestor, out investor);
                    }

                    loanRequestingLockOn.Fields["CX.SD.PREVIOUSLOANNUM"].Value = prevloanNumber;
                    loanRequestingLockOn.Fields["CX.SD.PREVIOUSLOANDATE"].Value = dateForEPO;
                    try
                    {
                        loanRequestingLockOn.Fields["CX.SD.PREVIOUSLOANINVEST"].Value = investor;
                    }
                    catch (Exception)
                    {
                        loanRequestingLockOn.Fields["CX.SD.PREVIOUSLOANINVEST"].Value = "";
                    }

                    int epo = 180;
                    if (usePurchaseDate)
                    {
                        //epo = GetEPOPeriod(productCode);
                    }

                    //196852
                    EncompassApplication.CurrentLoan.Fields["CX.SD.PREVIOUSEPODAYS"].Value = epo;

                    DateTime newPurchaseDate = dateForEPO.AddDays(epo);
                    if (DateTime.Now < newPurchaseDate) //within EPO period
                    {
                        loanRequestingLockOn.Fields["CX.EPO.PERIOD"].Value = "Loan is within EPO period";
                    }
                    else if (DateTime.Now > dateForEPO) // outside purchase date(No EPO)
                    {
                        loanRequestingLockOn.Fields["CX.EPO.OUTSIDE"].Value = "True";
                    }
                }
            }
            finally
            {
                dbLoan?.Close();
            }
        }

        public static string CorrectAddress(string strAdd)
        {
            string result;

            result = strAdd.CaseInsenstiveReplace("W\\.", "West");
            result = result.CaseInsenstiveReplace(" W ", " West ");
            result = result.CaseInsenstiveReplace("E\\.", "East");
            result = result.CaseInsenstiveReplace(" E ", " East ");
            result = result.CaseInsenstiveReplace("S\\.", "South");
            result = result.CaseInsenstiveReplace(" S ", " South ");
            result = result.CaseInsenstiveReplace("N\\.", "North");
            result = result.CaseInsenstiveReplace(" N ", " North ");

            result = result.CaseInsenstiveReplace("Blvd\\.", "Boulevard");
            result = result.CaseInsenstiveReplace("Blvd", "Boulevard");
            result = result.CaseInsenstiveReplace("St\\.", "Street");
            result = result.CaseInsenstiveReplace(" St ", " Street ");
            result = result.CaseInsenstiveReplace("AVE\\.", "Avenue");
            result = result.CaseInsenstiveReplace(" AVE ", " Avenue ");
            result = result.CaseInsenstiveReplace("Rd\\.", "Road");
            result = result.CaseInsenstiveReplace(" Rd ", " Road ");

            return result;
        }
        public class Address
        {
            public string street_address { get; set; }
            public string city { get; set; }
            public string region { get; set; }
            public string postal_code { get; set; }
            public string iso_country_code { get; set; }
        }
    }
}
