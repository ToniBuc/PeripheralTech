namespace PeripheralTech.WinUI.User
{
    partial class frmStaffMembers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaffMembers));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvStaffMembers = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffMembers)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Staff member:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(15, 90);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(202, 24);
            this.txtSearch.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkRed;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(223, 91);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.BackColor = System.Drawing.Color.DarkRed;
            this.btnAddStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddStaff.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddStaff.FlatAppearance.BorderSize = 0;
            this.btnAddStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStaff.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStaff.ForeColor = System.Drawing.Color.White;
            this.btnAddStaff.Location = new System.Drawing.Point(15, 478);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(108, 23);
            this.btnAddStaff.TabIndex = 14;
            this.btnAddStaff.Text = "Add new staff";
            this.btnAddStaff.UseVisualStyleBackColor = false;
            this.btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.DarkRed;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(429, 478);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(108, 23);
            this.btnReport.TabIndex = 15;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 31);
            this.panel1.TabIndex = 16;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(510, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 636);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(551, 31);
            this.panel2.TabIndex = 18;
            // 
            // dgvStaffMembers
            // 
            this.dgvStaffMembers.AllowUserToAddRows = false;
            this.dgvStaffMembers.AllowUserToDeleteRows = false;
            this.dgvStaffMembers.AllowUserToResizeColumns = false;
            this.dgvStaffMembers.AllowUserToResizeRows = false;
            this.dgvStaffMembers.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvStaffMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStaffMembers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvStaffMembers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaffMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStaffMembers.ColumnHeadersHeight = 24;
            this.dgvStaffMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStaffMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.FirstName,
            this.LastName,
            this.StaffRole});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaffMembers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStaffMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaffMembers.EnableHeadersVisualStyles = false;
            this.dgvStaffMembers.GridColor = System.Drawing.SystemColors.Control;
            this.dgvStaffMembers.Location = new System.Drawing.Point(0, 0);
            this.dgvStaffMembers.Name = "dgvStaffMembers";
            this.dgvStaffMembers.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaffMembers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStaffMembers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStaffMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaffMembers.Size = new System.Drawing.Size(522, 352);
            this.dgvStaffMembers.TabIndex = 1;
            this.dgvStaffMembers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvStaffMembers_MouseDoubleClick);
            // 
            // UserID
            // 
            this.UserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            this.UserID.Width = 84;
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // StaffRole
            // 
            this.StaffRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StaffRole.DataPropertyName = "UserRoleName";
            this.StaffRole.HeaderText = "Staff role";
            this.StaffRole.Name = "StaffRole";
            this.StaffRole.ReadOnly = true;
            this.StaffRole.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvStaffMembers);
            this.panel3.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(15, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(522, 352);
            this.panel3.TabIndex = 19;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogo.Image")));
            this.pbxLogo.Location = new System.Drawing.Point(449, 540);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(90, 90);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 17;
            this.pbxLogo.TabStop = false;
            // 
            // frmStaffMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(551, 667);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pbxLogo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnAddStaff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStaffMembers";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "frmStaffMembers";
            this.Load += new System.EventHandler(this.frmStaffMembers_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffMembers)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvStaffMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffRole;
        private System.Windows.Forms.Panel panel3;
    }
}