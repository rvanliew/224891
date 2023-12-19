using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.Collections;
using NafTestForm.Extensions;
using NafTestForm.Global;
using NafTestForm.Models;

namespace NafTestForm._201372.Forms
{
    public partial class SearchForm : Form
    {
        private Roles _roleList = null;
        private UserList _allEncompassUsers = null;
        private UserList _filteredAllEncompassUsers = new UserList();
        private string _ddCurrentRoleName;
        private int _searchCount = 0;
        private List<User> _filteredList = new List<User>();
        private ListViewColumnSorter lvwColumnSorter;
        private ListViewItem _currentlySelectedUser;
        private Role _currentlySelectedRole;

        public SearchForm()
        {
            InitializeComponent();
            CreateListViewColumns();
            CreateColumnSorter();
            GetListDataFromEncompass();

            if (_allEncompassUsers == null || _roleList == null)
            {
                // display error to user that one of the following lists could not be populated
                return;
            }
            else
            {
                if(cbShowAllRoles.Checked)
                {
                    PopulateAllRoles();
                }
                else
                {
                    PopulateCoreRoles();
                }              
                
                _filteredList = FilterEncompassUserList();
                InitialListViewPopulation(_filteredList);
            }
        }

        private void CreateColumnSorter()
        {
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstViewUsers.ListViewItemSorter = lvwColumnSorter;
        }

        private void GetListDataFromEncompass()
        {
            try
            {
                // list of all encompass roles
                _roleList = EncompassApplication.Session.Loans.Roles;

                // get list of all encompass users
                _allEncompassUsers = EncompassApplication.Session.Users.GetAllUsers();
            }
            catch (Exception ex)
            {
                // log exception
            }
        }

        #region FormControlEvents
        private void ddRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // "<-- Select -->" as the first option
            if(ddRoleFilter.SelectedIndex < 0)
            {
                return;
            }
            else
            {
                lbAssignUserInfoMessage.Visible = false;
                ddPersonaFilter.Items.Clear();
                ddUserGroups.Items.Clear();

                DisplayUsersWithEilibilePersonas(ddRoleFilter.Text);
                DisplayUserGroupsForSelectedRole(ddRoleFilter.Text);

                ddUserGroups.Enabled = true;
                ddPersonaFilter.Enabled = true;
            }
        }

        private void ddPersonaFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddPersonaFilter.SelectedIndex < 0)
            {
                return;
            }
            else
            {
                DisplayUsersBySelectedPersona();
            }
        }

        private void ddUserGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddUserGroups.SelectedIndex < 0)
            {
                return;
            }
            else
            {
                DisplayUsersForSelectedUserGroup(ddUserGroups.Text);
            }
        }

        private void txtSearchCriteria_TextChanged(object sender, EventArgs e)
        {
            SearchViewList(txtSearchCriteria.Text);
        }

        private void lstViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewUsers.FocusedItem == null)
            {
                return;
            }
            else
            {
                lbAssignUserInfoMessage.Visible = false;
                int selectedIndex = lstViewUsers.FocusedItem.Index;
                _currentlySelectedUser = lstViewUsers.Items[selectedIndex];
            }
        }
        #endregion End FormControlEvents

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //
        }

        private void CreateListViewColumns()
        {
            if(lstViewUsers.Columns.Count == 0)
            {
                lstViewUsers.Columns.Add("User ID", 120);
                lstViewUsers.Columns.Add("First Name", 120);
                lstViewUsers.Columns.Add("Last Name", 120);
            }
        }

        private void PopulateCoreRoles()
        {           
            // loop roleList and populate dropdown with core roles
            foreach (Role role in _roleList)
            {
                if(role.Name.EqualsAnyOf("Loan Officer",
                    "Production Assistant",
                    "Jr. Processor",
                    "Underwriter",
                    "Funder",
                    "Loan Officer Asst",
                    "Sales Assistant",
                    "Sales Assistant 2",
                    "Document Reviewer"))
                {
                    ddRoleFilter.Items.Add(role.Name);
                }
            }
        }

        private void PopulateAllRoles()
        {
            // loop roleList and populate dropdown with core roles
            foreach (Role role in _roleList)
            {
                ddRoleFilter.Items.Add(role.Name);
            }
        }

        private List<User> FilterEncompassUserList()
        {
            IList collection = (IList)_allEncompassUsers;
            // cast UserList to Ilist collection to be used with LINQ
            List<User> castedList = collection.Cast<User>().ToList();

            // filter out certain users
            List<User> filteredList = castedList
                .Where(u => u.Enabled.ToString().ToLower().Equals("true"))
                .Where(u => !u.ID.ToLower().Contains("2ndsign"))
                .Where(u => !u.ID.ToLower().Contains("admin"))
                .Where(u => !u.ID.ToLower().Contains("cpm"))
                .Where(u => !u.ID.ToLower().Contains("funder"))
                .Where(u => !u.ID.ToLower().Contains("user"))
                .Where(u => !u.ID.ToLower().Contains("postcloser"))
                .Where(u => !u.ID.ToLower().Contains("api"))
                .Where(u => !u.ID.ToLower().Contains("training"))
                .Where(u => !u.ID.ToLower().Contains("uat"))
                .Where(u => !u.ID.ToLower().Contains("test"))
                .Where(u => !u.FirstName.ToLower().Contains("training"))
                .Where(u => !u.FirstName.ToLower().Contains("test"))
                .Where(u => !u.FirstName.ToLower().Contains("pccd"))
                .Where(u => !u.LastName.ToLower().Contains("user"))
                .Where(u => !u.LastName.ToLower().Contains("test"))
                .ToList();

            return filteredList;
        }

        private void InitialListViewPopulation(List<User> filteredList)
        {
            foreach (User user in filteredList)
            {
                // add users to listview control box
                AddUserToListViewControl(user);

                // populate new filtered encompass UserList
                _filteredAllEncompassUsers.Add(user);
            }

            // set search result count
            lbResultCount.Text = $"{filteredList.Count}";
        }

        #region Displays
        private void DisplayUserGroupsForSelectedRole(string selectedRole)
        {
            _ddCurrentRoleName = selectedRole;

            if (string.IsNullOrWhiteSpace(selectedRole))
            {
                return;
            }
            else
            {
                foreach(Role eRole in _roleList)
                {
                    if(eRole.Name.ToLower().Equals(selectedRole.ToLower()))
                    {
                        if (eRole.EligibleGroups == null)
                        {
                            return;
                        }
                        else
                        {
                            foreach (UserGroup uGroup in eRole.EligibleGroups)
                            {
                                ddUserGroups.Items.Add(uGroup.Name);
                            }
                        }
                    }
                }
            }
        }

        private void DisplayUsersWithEilibilePersonas(string currentlySelectedRole)
        {
            ClearViewlistAndSearchLabel();
            CreateListViewColumns();

            foreach (Role encRole in _roleList)
            {
                if (encRole.Name.ToLower().Equals(currentlySelectedRole.ToLower()))
                {
                    _currentlySelectedRole = encRole;

                    // loop eligible personas based on currently selected role
                    for (int index = 0; index < encRole.EligiblePersonas.Count; index++)
                    {
                        //populate dropdown with eligible persona names
                        ddPersonaFilter.Items.Add(encRole.EligiblePersonas[index].Name);

                        // display filtered users with eligble personas based on selected role
                        foreach(User user in _filteredAllEncompassUsers)
                        {
                            foreach(Persona persona in user.Personas)
                            {
                                if (persona.Name.ToLower().Equals(encRole.EligiblePersonas[index].Name.ToLower()))
                                {
                                    AddUserToListViewControl(user);
                                }
                            }
                        }
                    }
                }
            }

            UpdateSearchCountLabelText();
        }

        private void DisplayUsersBySelectedPersona()
        {
            // display users with eligble personas related to the selected Role
            ClearViewlistAndSearchLabel();
            CreateListViewColumns();

            foreach (User user in _filteredAllEncompassUsers)
            {
                foreach (Persona persona in user.Personas)
                {
                    if (persona.Name.ToLower().Equals(ddPersonaFilter.Text.ToLower()))
                    {
                        AddUserToListViewControl(user);
                    }
                }
            }

            UpdateSearchCountLabelText();
        }

        private void DisplayUsersForSelectedUserGroup(string selectedUserGroup)
        {
            ClearViewlistAndSearchLabel();
            CreateListViewColumns();

            if (string.IsNullOrWhiteSpace(selectedUserGroup))
            {
                return;
            }
            else
            {
                foreach (Role eRole in _roleList)
                {
                    if (eRole.Name.ToLower().Equals(_ddCurrentRoleName.ToLower()))
                    {
                        if (eRole.EligibleGroups == null)
                        {
                            return;
                        }
                        else
                        {
                            foreach (UserGroup uGroup in eRole.EligibleGroups)
                            {
                                if(uGroup.Name.ToLower().Equals(selectedUserGroup.ToLower()))
                                {
                                    UserList userInGroup = uGroup.GetUsers();

                                    for(int index = 0; index < userInGroup.Count; index++)
                                    {
                                        foreach(User filteredUser in _filteredAllEncompassUsers)
                                        {
                                            if (userInGroup[index].FullName.ToLower().Equals(filteredUser.FullName.ToLower()))
                                            {
                                                AddUserToListViewControl(filteredUser);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                UpdateSearchCountLabelText();
            }
        }
        #endregion End Displays

        private void SearchViewList(string searchCriteria)
        {
            ClearViewlistAndSearchLabel();

            foreach (User user in _filteredAllEncompassUsers)
            {
                if(user.Enabled)
                {
                    if(user.FullName.ToLower().Contains(searchCriteria) || user.ID.ToLower().Contains(searchCriteria))
                    {
                        string[] row = { user.ID, user.FirstName, user.LastName };
                        ListViewItem itemToAdd = new ListViewItem(row);
                        lstViewUsers.Items.Add(itemToAdd);
                        _searchCount++;
                    }
                }
            }

            UpdateSearchCountLabelText();
        }

        private void AddUserToListViewControl(User user)
        {
            string[] row = { user.ID, user.FirstName, user.LastName };
            ListViewItem itemToAdd = new ListViewItem(row);
            lstViewUsers.Items.Add(itemToAdd);
            _searchCount++;
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void ClearFilters()
        {
            txtSearchCriteria.Text = string.Empty;
            lstViewUsers.Clear();
            CreateListViewColumns();

            lbResultCount.Text = $"{0}";

            if (ddRoleFilter.SelectedIndex >= 0)
            {
                ddRoleFilter.SelectedIndex = 0;
            }

            ddPersonaFilter.Items.Clear();
            ddUserGroups.Items.Clear();
            RepopulateListView(_filteredList);
        }

        private void RepopulateListView(List<User> filteredList)
        {
            foreach (User user in filteredList)
            {
                // add users to listview control box
                AddUserToListViewControl(user);
            }

            // set search result count
            lbResultCount.Text = $"{filteredList.Count}";
        }

        private void UpdateSearchCountLabelText()
        {
            lbResultCount.Text = _searchCount.ToString();
        }

        private void ClearViewlistAndSearchLabel()
        {
            _searchCount = 0;
            lstViewUsers.Items.Clear();
        }

        private void lstViewUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstViewUsers.Sort();
        }

        private class ListViewColumnSorter : IComparer
        {
            /// <summary>
            /// Specifies the column to be sorted
            /// </summary>
            private int ColumnToSort;

            /// <summary>
            /// Specifies the order in which to sort (i.e. 'Ascending').
            /// </summary>
            private SortOrder OrderOfSort;

            /// <summary>
            /// Case insensitive comparer object
            /// </summary>
            private CaseInsensitiveComparer ObjectCompare;

            /// <summary>
            /// Class constructor. Initializes various elements
            /// </summary>
            public ListViewColumnSorter()
            {
                // Initialize the column to '0'
                ColumnToSort = 0;

                // Initialize the sort order to 'none'
                OrderOfSort = SortOrder.None;

                // Initialize the CaseInsensitiveComparer object
                ObjectCompare = new CaseInsensitiveComparer();
            }

            /// <summary>
            /// This method is inherited from the IComparer interface. It compares the two objects passed using a case insensitive comparison.
            /// </summary>
            /// <param name="x">First object to be compared</param>
            /// <param name="y">Second object to be compared</param>
            /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX, listviewY;

                // Cast the objects to be compared to ListViewItem objects
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                // Compare the two items
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

                // Calculate correct return value based on object comparison
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                else
                {
                    // Return '0' to indicate they are equal
                    return 0;
                }
            }

            /// <summary>
            /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
            /// </summary>
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }

            /// <summary>
            /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
            /// </summary>
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }

        }

        private void cbShowAllRoles_CheckedChanged(object sender, EventArgs e)
        {
            if(cbShowAllRoles.Checked)
            {
                ddRoleFilter.Items.Clear();
                PopulateAllRoles();
            }   
            else
            {
                ddRoleFilter.Items.Clear();
                PopulateCoreRoles();
            }
        }

        private void AssignUserToRole()
        {
            // Assign the user to the specified role
            //loan.Associates.AssignUser(role, user);

            if(_currentlySelectedUser == null)
            {
                // display error message
                lbAssignUserInfoMessage.Visible = true;
                lbAssignUserInfoMessage.ForeColor = Color.Red;
                lbAssignUserInfoMessage.Text = "Please select a user you'd like to assign to the role.";
            }
            else
            {   User user = EncompassApplication.Session.Users.GetUser(_currentlySelectedUser.Text);
                if(user != null)
                {
                    if (_currentlySelectedRole == null)
                    {
                        // display error message
                        lbAssignUserInfoMessage.Visible = true;
                        lbAssignUserInfoMessage.ForeColor = Color.Red;
                        lbAssignUserInfoMessage.Text = "Please select a Role from the drop down.";
                    }
                    else
                    {
                        try
                        {
                            EncompassApplication.CurrentLoan.Associates.AssignUser(_currentlySelectedRole, user);
                            EncompassApplication.CurrentLoan.Fields["CX.JR.PROC.ASSIGNED.DATE"].Value = 
                                TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "Pacific Standard Time");
                        }
                        catch (Exception ex)
                        {
                            // display error message
                            lbAssignUserInfoMessage.Visible = true;
                            lbAssignUserInfoMessage.ForeColor = Color.Red;
                            lbAssignUserInfoMessage.Text = $"{ex.Message}";
                        }

                        ClearFilters();
                    }
                }
                else
                {
                    // display error message
                    lbAssignUserInfoMessage.Visible = true;
                    lbAssignUserInfoMessage.ForeColor = Color.Red;
                    lbAssignUserInfoMessage.Text = $"There was an issue retrieving user {_currentlySelectedUser.Text}.";
                }
            }
        }

        private void btnAssignUser_Click(object sender, EventArgs e)
        {
            AssignUserToRole();
        }
    }
}
