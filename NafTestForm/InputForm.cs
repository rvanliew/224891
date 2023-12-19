using EllieMae.Encompass.Forms;
using EllieMae.Encompass.BusinessObjects.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EllieMae.Encompass.Automation;
using EllieMae.Encompass.Collections;
using System.ComponentModel;
using System.Globalization;
using EllieMae.Encompass.Cursors;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Xml.Linq;
using LicenseContext = OfficeOpenXml.LicenseContext;
using NafTestForm.Services;
using System.Net.Http;
using NafTestForm.Interfaces;
using Microsoft.Extensions.Configuration;
using NafTestForm.VT_API_Integration;
using WF = System.Windows.Forms;
using System.Threading;
using NafTestForm._210323;
using NafTestForm._216980;
using NafTestForm._201372;
using EllieMae.Encompass.Configuration;
using EllieMae.Encompass.Client;
using NafTestForm.Extensions;
using System.Runtime.InteropServices;

namespace NafTestForm
{
    public class InputForm : Form
    {
        internal MultilineTextBox mtbOutput = null;
        internal MultilineTextBox mtbServiceOutput = null;
        internal MultilineTextBox mtbUserData = null;
        internal TextBox txtPool = null;
        internal Button btnTestPolly = null;
        internal Button btnAuditLog = null;
        internal Button btnGenerate = null;
        internal Button btnOrderService = null;
        internal Button btnUserInfo = null;

        // Test Lab Controls
        internal TextBox tbLoanReqsMet = null;
        internal Button btnExecuteTest = null;
        internal MultilineTextBox mtbOutputTest = null;
        // End Test Lab Controls

        // 201372
        internal DropdownBox ddEligiblePersonasFilter = null;
        internal DropdownBox ddRoleFilter = null;
        internal Button btnSearch = null;
        internal TextBox tbSearch = null;
        // end

        private HttpClient HttpClient;
        private TokenHandler TokenHandler { get; set; }
        private EncompassClient EncompassClient { get; set; }
        private OrderService OrderService { get; set; }
        private IConfiguration _configuration { get; set; }
        private IEncompassCredentials _encompassCreds { get; set; }
        private EncAccountData EncAccountData { get; set; }
        private Main_210323 Main_210323 { get; set; }
        private Main_216980 Main_216980 { get; set; }
        private Main_201372 Main_201372 { get; set; }


        public override void CreateControls()
        {
            mtbOutput = FindControl(FC.FieldControls.Controls.Textboxes.mtbOutput) as MultilineTextBox;
            mtbServiceOutput = FindControl(FC.FieldControls.Controls.Textboxes.mtbServiceOutput) as MultilineTextBox;
            mtbUserData = FindControl(FC.FieldControls.Controls.Textboxes.mtbUserData) as MultilineTextBox;
            txtPool = FindControl(FC.FieldControls.Controls.Textboxes.txtPool) as TextBox;

            btnTestPolly = FindControl(FC.FieldControls.Controls.Buttons.btnTestPolly) as Button;
            btnTestPolly.Click += new EventHandler(btnTestPolly_Click);

            btnAuditLog = FindControl(FC.FieldControls.Controls.Buttons.btnAuditLog) as Button;
            btnAuditLog.Click += new EventHandler(btnAuditLog_Click);

            btnGenerate = FindControl(FC.FieldControls.Controls.Buttons.btnGenerate) as Button;
            btnGenerate.Click += new EventHandler(btnGenerate_Click);

            btnOrderService = FindControl(FC.FieldControls.Controls.Buttons.btnOrderService) as Button;
            btnOrderService.Click += new EventHandler(btnOrderService_Click);

            btnUserInfo = FindControl(FC.FieldControls.Controls.Buttons.btnUserInfo) as Button;
            btnUserInfo.Click += new EventHandler(btnUserInfo_Click);

            #region Test Lab
            tbLoanReqsMet = FindControl(FC.FieldControls.TestSection.tbLoanReqsMet) as TextBox;
            btnExecuteTest = FindControl(FC.FieldControls.TestSection.btnExecuteTest) as Button;
            btnExecuteTest.Click += new EventHandler(btnExecuteTest_Click);
            mtbOutputTest = FindControl(FC.FieldControls.TestSection.mtbOutputTest) as MultilineTextBox;
            #endregion

            #region 201372
            ddEligiblePersonasFilter = FindControl(FC.FieldControls.Main201372.ddEligiblePersonasFilter) as DropdownBox;
            ddRoleFilter = FindControl(FC.FieldControls.Main201372.ddRoleFilter) as DropdownBox;
            ddRoleFilter.Change += new EventHandler(ddRoleFilter_Change);
            btnSearch = FindControl(FC.FieldControls.Main201372.btnSearch) as Button;
            btnSearch.Click += new EventHandler(btnSearch_Click);
            tbSearch = FindControl(FC.FieldControls.Main201372.tbSearch) as TextBox;
            #endregion

            HttpClient = new HttpClient();
            EncompassClient = new EncompassClient(HttpClient);
            TokenHandler = new TokenHandler(EncompassClient);
            OrderService = new OrderService(TokenHandler, EncompassClient, this);
            EncAccountData = new EncAccountData(this, TokenHandler, EncompassClient);
            Main_210323 = new Main_210323(this);
            Main_216980 = new Main_216980(this);
            Main_201372 = new Main_201372();
        }

        public InputForm()
        {
            Load += new EventHandler(FormLoadEvent);
        }

        private void FormLoadEvent(object sender, EventArgs e)
        {
            //
        }

        private void ddRoleFilter_Change(object sender, EventArgs e)
        {
            //
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Main_201372.OpenSearchForm();
        }

        /// <summary>
        /// Used for testing certain code classes and methods
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecuteTest_Click(object sender, EventArgs e)
        {
            //Main_210323.Execute();
            //Main_216980.CalculateTotalHours();
            CalculateTotalHours();
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            EncAccountData.DisplayUserData();
        }

        private async void btnOrderService_Click(object sender, EventArgs e)
        {
            await OrderService.OrderDU();
            //SaveLoanAndRemoveUser();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void btnAuditLog_Click(object sender, EventArgs e)
        {      
            //if (!EncompassApplication.CurrentLoan.Fields["1401"].IsEmpty() &&
            //    EncompassApplication.CurrentLoan.Fields["Log.MS.Status.Clear to Close"].FormattedValue.Equals("Expected"))
            //{
            //    if (IsLoanProgramChangedByPolly())
            //    {
            //        //This method will check 1401 against ALL loan programs inside NAF database
            //        //ApplyLoanProgramTemplateByName(EncompassApplication.CurrentLoan.Fields["1401"].FormattedValue);
            //    }
            //}

            //Testing
            if (IsLoanProgramChangedByPolly())
            {
                //This method will check 1401 against ALL loan programs inside NAF database
                //ApplyLoanProgramTemplateByName(EncompassApplication.CurrentLoan.Fields["1401"].FormattedValue);
            }
        }

        private void btnTestPolly_Click(object sender, EventArgs e)
        {
            //
        }

        private bool IsLoanProgramChangedByPolly()
        {
            //test loan T1000128543
            //user admin_polly
            AuditTrailEntryList entries = new AuditTrailEntryList();
            foreach (string fieldId in Loan.AuditTrail.GetAuditFieldList())
            {
                if (fieldId.Equals(FC.FieldControls.EMFields.loanProgram))
                {
                    entries = EncompassApplication.CurrentLoan.AuditTrail.GetHistory(fieldId);
                }
            }

            //Convert List into Array so I can order by Timestamp (Descending)
            AuditTrailEntry[] orderedArray = entries.ToArray();
            orderedArray = orderedArray
                .OrderByDescending(x => x.Timestamp)
                .ToArray();

            mtbOutput.Text = string.Empty;

            //Could possibly just check the first index as that should be the most recent entry
            if (orderedArray[0].UserID.Equals("ron.vanliew"))
            {
                mtbOutput.Text += "Returned True";
                mtbOutput.Text += $"Timestamp: {orderedArray[0].Timestamp} | User: {orderedArray[0].UserID} | Field: {orderedArray[0].Field}\r\r";
                return true;
            }

            //foreach (AuditTrailEntry value in orderedArray)
            //{
            //    //Check if user is admin_polly
            //    if(value.UserID.Equals("admin_polly"))
            //    {
            //        return true;
            //    }

            //    //if(value.UserID.Equals("ron.vanliew"))
            //    //{
            //    //    mtbOutput.Text += $"Timestamp: {value.Timestamp} | User: {value.UserID} | Field: {value.Field}\r\r";
            //    //}

            //    mtbOutput.Text += $"Timestamp: {value.Timestamp} | User: {value.UserID} | Field: {value.Field}\r\r";
            //}

            return false;
        }

        private void SaveFile()
        {
            bool result = false;
            FileInfo file = new FileInfo(@"E:\NAF\Tests\gnma test 3.xlsx");

            //C:\Users\SSKMa\Desktop\GNMA August 22.xlsx
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    ExcelWorksheet worksheet = CreateNewWorksheet(excelPackage, txtPool.Text);

                    //worksheet = BuildWorksheet(worksheet, cursor);

                    excelPackage.Save();                

                    result = true;
                }
            }
            catch (IOException ex)
            {
                //
            }
        }

        private ExcelWorksheet CreateNewWorksheet(ExcelPackage excelPackage, string name)
        {
            ExcelWorksheets worksheets = excelPackage.Workbook.Worksheets;
            int sheets = worksheets.Count;
            int found = 0;
            bool alreadyFound;

            if (sheets > 0)
            {
                //for (int i = 1; i <= sheets; i++)
                //{
                //    if (worksheets[i].Name == name)
                //    {
                //        found++;
                //        alreadyFound = name.Contains("(");

                //        if (alreadyFound)
                //        {
                //            int startIndex = name.IndexOf("(") - 1;
                //            int count = name.Length - startIndex;
                //            name = name.Remove(startIndex, count);
                //        }

                //        name = $"{name} ({found})";
                //    }
                //}

                foreach(ExcelWorksheet worksheet in worksheets)
                {
                    if(worksheet.Name == name)
                    {
                        found++;
                        alreadyFound = name.Contains("(");

                        if (alreadyFound)
                        {
                            int startIndex = name.IndexOf("(") - 1;
                            int count = name.Length - startIndex;
                            name = name.Remove(startIndex, count);
                        }

                        name = $"{name} ({found})";
                    }
                }
            }

            return worksheets.Add(name);
        }

        private void SaveLoanAndRemoveUser()
        {
            WF.DialogResult result;
            result = WF.MessageBox.Show("When ordering DU/LP services the loan must be saved and close the loan." +
                "During this time you not be able to make any changes to the loan. Do you want to continue?", 
                "DU/LP Service Order", WF.MessageBoxButtons.YesNo, WF.MessageBoxIcon.Question);

            if(result == WF.DialogResult.Yes)
            {
                if(EncompassApplication.CurrentLoan != null)
                {
                    EncompassApplication.CurrentLoan.Commit();
                    EncompassApplication.CurrentLoan.ForceUnlock();
                    if(EncompassApplication.CurrentLoan.Locked == false)
                    {
                        // instead of thread sleep I will set a boolean variable
                        // once all API calls have been completed
                        Thread.Sleep(20000);
                        EncompassApplication.CurrentLoan.Lock();
                        Macro.Alert("Loan updated. Please close this loan WITHOUT saving." +
                            " Your new changes will be avilable to view next time you enter this loan.");
                    }
                    else
                    {
                        Macro.Alert("Could not Force Unlock loan. Cancelling operations.");
                    }                  
                }
            }
            
        }

        private void CalculateTotalHours()
        {
            string assignedDateStr = string.Empty;
            string returnedDateStr = string.Empty;
            int endBusinessDay = 17; // 5 PM
            int startBusinessDay = 8; // 8 AM

            int totalHours = 0;

            DateTime assignedDate;
            DateTime returnedDate;

            if (!string.IsNullOrWhiteSpace(EncompassApplication.CurrentLoan.Fields["CX.JR.PROC.ASSIGNED.DATE"].UnformattedValue) &&
                !string.IsNullOrWhiteSpace(EncompassApplication.CurrentLoan.Fields["CX.JR.RETURNTOPROC.DATE"].UnformattedValue))
            {
                assignedDateStr = EncompassApplication.CurrentLoan.Fields["CX.JR.PROC.ASSIGNED.DATE"].UnformattedValue;
                returnedDateStr = EncompassApplication.CurrentLoan.Fields["CX.JR.RETURNTOPROC.DATE"].UnformattedValue;
            }

            try
            {
                assignedDate = ValidateDate(assignedDateStr);
                returnedDate = ValidateDate(returnedDateStr);

                if(assignedDate.Day == returnedDate.Day)
                {
                    totalHours += returnedDate.Hour - assignedDate.Hour;
                    EncompassApplication.CurrentLoan.Fields["CX.JR.RETURNTOPROC.TIME"].Value = totalHours.ToString();
                }
                else
                {
                    if (assignedDate.Hour >= startBusinessDay && assignedDate.Hour <= endBusinessDay)
                    {
                        totalHours += endBusinessDay - assignedDate.Hour;
                    }

                    if (returnedDate.Hour >= startBusinessDay && returnedDate.Hour <= endBusinessDay)
                    {
                        totalHours += returnedDate.Hour - startBusinessDay;
                    }

                    List<DateTime> inbetweenDaysList = new List<DateTime>();

                    for (DateTime dt = assignedDate.Date; dt.Date <= returnedDate.Date; dt = dt.Date.AddDays(1))
                    {
                        inbetweenDaysList.Add(dt.Date);
                    }

                    // remove assigned and returned date from list
                    inbetweenDaysList.RemoveAt(inbetweenDaysList.Count - 1);
                    inbetweenDaysList.RemoveAt(0);

                    foreach (DateTime date in inbetweenDaysList)
                    {
                        if(IsDateHolidayOrWeekend(date) == false)
                        {
                            totalHours += 9;
                        }
                    }
                  
                    EncompassApplication.CurrentLoan.Fields["CX.JR.RETURNTOPROC.TIME"].Value = totalHours.ToString();
                }
            }
            catch (Exception ex)
            {
                // add exception to debug log
            }
        }

        private bool IsDateHolidayOrWeekend(DateTime date)
        {
            var isHoliday = EncompassApplication.Session.SystemSettings.GetBusinessCalendar(BusinessCalendarType.Postal).IsHoliday(date);

            // skip saturday, sunday and holidays
            if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday || isHoliday)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DateTime ValidateDate(string dateToValidate)
        {
            DateTime validatedDate = DateTime.Now;

            try
            {
                // parse the encompass field value
                var parsedDate = DateTime.Parse(dateToValidate);
                // check if it is a holiday or weekend
                if (IsDateHolidayOrWeekend(parsedDate))
                {
                    List<DateTime> nextBusinessDayList = new List<DateTime>();

                    // add 7 days to the date
                    var datePlusFiveDays = parsedDate.AddDays(7);
                    for (var dt = parsedDate; dt <= datePlusFiveDays; dt = dt.AddDays(1))
                    {
                        // add the whole Date and Time
                        nextBusinessDayList.Add(dt);
                    }

                    // loop new list of dates to find next available business day
                    foreach (DateTime date in nextBusinessDayList)
                    {
                        if (IsDateHolidayOrWeekend(date) == false)
                        {
                            // find a valid date that is not a weekend or holiday and break
                            validatedDate = date;
                            break;
                        }
                    }
                }
                else
                {
                    // date input is NOT a holiday or weekend
                    validatedDate = parsedDate;
                }
            }
            catch(Exception ex)
            {
                // log exception
            }

            return validatedDate;
        }
    }
}
