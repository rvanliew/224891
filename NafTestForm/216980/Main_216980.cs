using EllieMae.Encompass.Automation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NafTestForm._216980
{
    public class Main_216980
    {
        private InputForm _inputForm { get; set; }

        private List<DateTime> _bankHolidays = new List<DateTime>()
        {
            //holiday ref : https://www.frbservices.org/about/holiday-schedules

            // new years day
            new DateTime(2023, 1, 1),
            new DateTime(2024, 1, 1),
            new DateTime(2025, 1, 1),
            new DateTime(2026, 1, 1),
            new DateTime(2027, 1, 1),
            // end new years

            // MLK Day
            new DateTime(2023, 1, 16),
            new DateTime(2024, 1, 15),
            new DateTime(2025, 1, 20),
            new DateTime(2026, 1, 19),
            new DateTime(2027, 1, 18),
            // end MLK day

            // presidents day
            new DateTime(2023, 2, 20),
            new DateTime(2024, 2, 19),
            new DateTime(2025, 2, 17),
            new DateTime(2026, 2, 16),
            new DateTime(2027, 2, 15),
            // end presidents day

            // memorial day
            new DateTime(2023, 5, 29),
            new DateTime(2024, 5, 27),
            new DateTime(2025, 5, 26),
            new DateTime(2026, 5, 25),
            new DateTime(2027, 5, 31),
            // end memorial day

            // juneteenth independence day
            new DateTime(2023, 6, 19),
            new DateTime(2024, 6, 19),
            new DateTime(2025, 6, 19),
            new DateTime(2026, 6, 19),
            new DateTime(2027, 6, 19),
            // end juneteenth independence day
            
            // independence day
            new DateTime(2023, 7, 4),
            new DateTime(2024, 7, 4),
            new DateTime(2025, 7, 4),
            new DateTime(2026, 7, 4),
            new DateTime(2027, 7, 4),
            // end independence day

            // labor day
            new DateTime(2023, 9, 4),
            new DateTime(2024, 9, 2),
            new DateTime(2025, 9, 1),
            new DateTime(2026, 9, 7),
            new DateTime(2027, 9, 6),
            // end labor day

            // columbus day
            new DateTime(2023, 10, 9),
            new DateTime(2024, 10, 14),
            new DateTime(2025, 10, 13),
            new DateTime(2026, 10, 12),
            new DateTime(2027, 10, 11),
            // end columbus day

            // veterans day
            new DateTime(2023, 11, 11),
            new DateTime(2024, 11, 11),
            new DateTime(2025, 11, 11),
            new DateTime(2026, 11, 11),
            new DateTime(2027, 11, 11),
            //end veterans day

            // thanksgiving
            new DateTime(2023, 11, 23),
            new DateTime(2024, 11, 28),
            new DateTime(2025, 11, 27),
            new DateTime(2026, 11, 26),
            new DateTime(2027, 11, 25),
            // end thanksgiving

            // christmas
            new DateTime(2023, 12, 25),
            new DateTime(2024, 12, 25),
            new DateTime(2025, 12, 25),
            new DateTime(2026, 12, 25),
            new DateTime(2027, 12, 25)
            // end christmas
        };

        private string jrProcAssignedDateString = null;
        private string jrProcReturnDateString = null;

        public Main_216980(InputForm inputForm) 
        { 
            _inputForm = inputForm;
        }

        public void CalculateTotalHours()
        {
            GetCurrentValues();
            ConvertEncompassValuesToDateTime();
        }

        private void GetCurrentValues()
        {
            jrProcAssignedDateString = EncompassApplication.CurrentLoan.Fields["CX.JR.PROC.ASSIGNED.DATE"].UnformattedValue;
            jrProcReturnDateString = EncompassApplication.CurrentLoan.Fields["CX.JR.RETURNTOPROC.DATE"].UnformattedValue;
        }

        private void ConvertEncompassValuesToDateTime()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(jrProcAssignedDateString) && !string.IsNullOrWhiteSpace(jrProcReturnDateString))
                {
                    DateTime jrProcAssignedDate = DateTime.Parse($"{EncompassApplication.CurrentLoan.Fields["CX.JR.PROC.ASSIGNED.DATE"].UnformattedValue}");
                    DateTime jrProcReturnDate = DateTime.Parse($"{EncompassApplication.CurrentLoan.Fields["CX.JR.RETURNTOPROC.DATE"].UnformattedValue}");

                    _inputForm.mtbOutputTest.Text = $"jr proc assigned date: {jrProcAssignedDate}\r" +
                        $"return date: {jrProcReturnDate}";
                }
                else
                {
                    _inputForm.mtbOutputTest.Text = "One of the following encompass custom fields is empty.\r" +
                        $"CX.JR.PROC.ASSIGNED.DATE\r" +
                        $"CX.JR.RETURNTOPROC.DATE";
                }
            }
            catch (Exception ex)
            {
                _inputForm.mtbOutputTest.Text = ex.Message;
            }
        }
    }
}
