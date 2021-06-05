namespace PeripheralTech.WinUI.User
{
    partial class frmStaffMemberDetail
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
            this.components = new System.ComponentModel.Container();
            this.label15 = new System.Windows.Forms.Label();
            this.txtImageInput = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbUserRole = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(50, 189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 17);
            this.label15.TabIndex = 64;
            this.label15.Text = "New image:";
            // 
            // txtImageInput
            // 
            this.txtImageInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageInput.Location = new System.Drawing.Point(49, 207);
            this.txtImageInput.Name = "txtImageInput";
            this.txtImageInput.Size = new System.Drawing.Size(194, 23);
            this.txtImageInput.TabIndex = 63;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(50, 396);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 17);
            this.label14.TabIndex = 62;
            this.label14.Text = "City of residence:";
            // 
            // cmbCity
            // 
            this.cmbCity.BackColor = System.Drawing.SystemColors.Window;
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(-1, -2);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(289, 24);
            this.cmbCity.TabIndex = 61;
            this.cmbCity.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCity_Validating);
            // 
            // cmbUserRole
            // 
            this.cmbUserRole.BackColor = System.Drawing.SystemColors.Window;
            this.cmbUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUserRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserRole.FormattingEnabled = true;
            this.cmbUserRole.Location = new System.Drawing.Point(-1, -1);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(289, 24);
            this.cmbUserRole.TabIndex = 60;
            this.cmbUserRole.Validating += new System.ComponentModel.CancelEventHandler(this.cmbUserRole_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(50, 495);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 58;
            this.label13.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(49, 514);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(289, 23);
            this.txtUsername.TabIndex = 57;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(198, 546);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 17);
            this.label12.TabIndex = 56;
            this.label12.Text = "Password Confirmation:";
            // 
            // txtPasswordConfirmation
            // 
            this.txtPasswordConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordConfirmation.Location = new System.Drawing.Point(197, 565);
            this.txtPasswordConfirmation.Name = "txtPasswordConfirmation";
            this.txtPasswordConfirmation.Size = new System.Drawing.Size(141, 23);
            this.txtPasswordConfirmation.TabIndex = 55;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 546);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 17);
            this.label11.TabIndex = 54;
            this.label11.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(49, 565);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(141, 23);
            this.txtPassword.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 443);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 52;
            this.label9.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(49, 462);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(289, 23);
            this.txtAddress.TabIndex = 51;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "Phone number:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(49, 363);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(289, 23);
            this.txtPhoneNumber.TabIndex = 45;
            this.txtPhoneNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhoneNumber_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(49, 313);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(289, 23);
            this.txtEmail.TabIndex = 43;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "Role:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Last name:";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(163, 153);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(175, 23);
            this.txtLastName.TabIndex = 38;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "First name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(163, 87);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(175, 23);
            this.txtFirstName.TabIndex = 35;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.DarkRed;
            this.btnAddImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddImage.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddImage.FlatAppearance.BorderSize = 0;
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImage.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.ForeColor = System.Drawing.Color.White;
            this.btnAddImage.Location = new System.Drawing.Point(249, 204);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(89, 28);
            this.btnAddImage.TabIndex = 65;
            this.btnAddImage.Text = "Add image";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkRed;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(249, 598);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 31);
            this.panel1.TabIndex = 67;
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
            this.btnClose.Location = new System.Drawing.Point(352, 5);
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
            this.panel2.Location = new System.Drawing.Point(0, 652);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 31);
            this.panel2.TabIndex = 68;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbUserRole);
            this.panel3.Location = new System.Drawing.Point(49, 262);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(289, 23);
            this.panel3.TabIndex = 69;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cmbCity);
            this.panel4.Location = new System.Drawing.Point(49, 417);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(289, 23);
            this.panel4.TabIndex = 70;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(49, 69);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(107, 107);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 36;
            this.pictureBox.TabStop = false;
            // 
            // frmStaffMemberDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(393, 683);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtImageInput);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPasswordConfirmation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.txtFirstName);
            this.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStaffMemberDetail";
            this.Text = "frmStaffMemberDetail";
            this.Load += new System.EventHandler(this.frmStaffMemberDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtImageInput;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbUserRole;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPasswordConfirmation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}