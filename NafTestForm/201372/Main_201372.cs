using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.Collections;
using NafTestForm._201372.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm = System.Windows.Forms;


namespace NafTestForm._201372
{
    public class Main_201372
    {
        private SearchForm _searchForm;

        public Main_201372() 
        { 
            _searchForm = new SearchForm();
        }

        public void OpenSearchForm()
        {
            //GetAllEncompassUsers();
            if(_searchForm == null || _searchForm.IsDisposed)
            {
                _searchForm = new SearchForm();
            }
            else
            {
                _searchForm.ShowDialog();
                _searchForm.BringToFront();
            }
        }
    }
}
