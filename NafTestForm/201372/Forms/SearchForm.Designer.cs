namespace NafTestForm._201372.Forms
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbShowAllRoles = new System.Windows.Forms.CheckBox();
            this.ddUserGroups = new System.Windows.Forms.ComboBox();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ddPersonaFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ddRoleFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchCriteria = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstViewUsers = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbResultCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAssignUser = new System.Windows.Forms.Button();
            this.lbAssignUserInfoMessage = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(161)))), ((int)(((byte)(195)))));
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(803, 38);
            this.pnlHeader.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(161)))), ((int)(((byte)(195)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search and Assign Users to Encompass";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.cbShowAllRoles);
            this.panel1.Controls.Add(this.ddUserGroups);
            this.panel1.Controls.Add(this.btnClearFilters);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ddPersonaFilter);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ddRoleFilter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSearchCriteria);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 116);
            this.panel1.TabIndex = 2;
            // 
            // cbShowAllRoles
            // 
            this.cbShowAllRoles.AutoSize = true;
            this.cbShowAllRoles.Location = new System.Drawing.Point(438, 35);
            this.cbShowAllRoles.Name = "cbShowAllRoles";
            this.cbShowAllRoles.Size = new System.Drawing.Size(91, 17);
            this.cbShowAllRoles.TabIndex = 8;
            this.cbShowAllRoles.Text = "Show all roles";
            this.cbShowAllRoles.UseVisualStyleBackColor = true;
            this.cbShowAllRoles.CheckedChanged += new System.EventHandler(this.cbShowAllRoles_CheckedChanged);
            // 
            // ddUserGroups
            // 
            this.ddUserGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddUserGroups.Enabled = false;
            this.ddUserGroups.FormattingEnabled = true;
            this.ddUserGroups.Location = new System.Drawing.Point(170, 85);
            this.ddUserGroups.Name = "ddUserGroups";
            this.ddUserGroups.Size = new System.Drawing.Size(261, 21);
            this.ddUserGroups.Sorted = true;
            this.ddUserGroups.TabIndex = 7;
            this.ddUserGroups.SelectedIndexChanged += new System.EventHandler(this.ddUserGroups_SelectedIndexChanged);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Location = new System.Drawing.Point(437, 5);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(75, 23);
            this.btnClearFilters.TabIndex = 1;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Filter By User Groups";
            // 
            // ddPersonaFilter
            // 
            this.ddPersonaFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddPersonaFilter.Enabled = false;
            this.ddPersonaFilter.FormattingEnabled = true;
            this.ddPersonaFilter.Location = new System.Drawing.Point(170, 58);
            this.ddPersonaFilter.Name = "ddPersonaFilter";
            this.ddPersonaFilter.Size = new System.Drawing.Size(261, 21);
            this.ddPersonaFilter.Sorted = true;
            this.ddPersonaFilter.TabIndex = 5;
            this.ddPersonaFilter.SelectedIndexChanged += new System.EventHandler(this.ddPersonaFilter_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Filter By Persona(s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Filter By Role";
            // 
            // ddRoleFilter
            // 
            this.ddRoleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddRoleFilter.FormattingEnabled = true;
            this.ddRoleFilter.Location = new System.Drawing.Point(170, 31);
            this.ddRoleFilter.Name = "ddRoleFilter";
            this.ddRoleFilter.Size = new System.Drawing.Size(261, 21);
            this.ddRoleFilter.Sorted = true;
            this.ddRoleFilter.TabIndex = 2;
            this.ddRoleFilter.SelectedIndexChanged += new System.EventHandler(this.ddRoleFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Find User";
            // 
            // txtSearchCriteria
            // 
            this.txtSearchCriteria.Location = new System.Drawing.Point(170, 5);
            this.txtSearchCriteria.Name = "txtSearchCriteria";
            this.txtSearchCriteria.Size = new System.Drawing.Size(261, 20);
            this.txtSearchCriteria.TabIndex = 0;
            this.txtSearchCriteria.TextChanged += new System.EventHandler(this.txtSearchCriteria_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel2.Controls.Add(this.lbAssignUserInfoMessage);
            this.panel2.Controls.Add(this.btnAssignUser);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 36);
            this.panel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Assign User";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lstViewUsers);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(803, 322);
            this.panel3.TabIndex = 4;
            // 
            // lstViewUsers
            // 
            this.lstViewUsers.BackColor = System.Drawing.Color.White;
            this.lstViewUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstViewUsers.ForeColor = System.Drawing.Color.Black;
            this.lstViewUsers.GridLines = true;
            this.lstViewUsers.HideSelection = false;
            this.lstViewUsers.Location = new System.Drawing.Point(12, 35);
            this.lstViewUsers.MultiSelect = false;
            this.lstViewUsers.Name = "lstViewUsers";
            this.lstViewUsers.Size = new System.Drawing.Size(776, 273);
            this.lstViewUsers.TabIndex = 2;
            this.lstViewUsers.UseCompatibleStateImageBehavior = false;
            this.lstViewUsers.View = System.Windows.Forms.View.Details;
            this.lstViewUsers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstViewUsers_ColumnClick);
            this.lstViewUsers.SelectedIndexChanged += new System.EventHandler(this.lstViewUsers_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(161)))), ((int)(((byte)(195)))));
            this.panel4.Controls.Add(this.lbResultCount);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(803, 28);
            this.panel4.TabIndex = 0;
            // 
            // lbResultCount
            // 
            this.lbResultCount.AutoSize = true;
            this.lbResultCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResultCount.ForeColor = System.Drawing.Color.Black;
            this.lbResultCount.Location = new System.Drawing.Point(138, 3);
            this.lbResultCount.Name = "lbResultCount";
            this.lbResultCount.Size = new System.Drawing.Size(18, 20);
            this.lbResultCount.TabIndex = 2;
            this.lbResultCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Search Results :";
            // 
            // btnAssignUser
            // 
            this.btnAssignUser.Location = new System.Drawing.Point(652, 6);
            this.btnAssignUser.Name = "btnAssignUser";
            this.btnAssignUser.Size = new System.Drawing.Size(139, 23);
            this.btnAssignUser.TabIndex = 1;
            this.btnAssignUser.Text = "Assign User";
            this.btnAssignUser.UseVisualStyleBackColor = true;
            this.btnAssignUser.Click += new System.EventHandler(this.btnAssignUser_Click);
            // 
            // lbAssignUserInfoMessage
            // 
            this.lbAssignUserInfoMessage.AutoSize = true;
            this.lbAssignUserInfoMessage.Location = new System.Drawing.Point(109, 11);
            this.lbAssignUserInfoMessage.Name = "lbAssignUserInfoMessage";
            this.lbAssignUserInfoMessage.Size = new System.Drawing.Size(0, 13);
            this.lbAssignUserInfoMessage.TabIndex = 2;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(803, 620);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchCriteria;
        private System.Windows.Forms.ComboBox ddPersonaFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddRoleFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lstViewUsers;
        private System.Windows.Forms.Label lbResultCount;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.ComboBox ddUserGroups;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbShowAllRoles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAssignUser;
        private System.Windows.Forms.Label lbAssignUserInfoMessage;
    }
}