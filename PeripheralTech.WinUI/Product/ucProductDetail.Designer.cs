namespace PeripheralTech.WinUI.Product
{
    partial class ucProductDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGallery = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numInStock = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtImageInput = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnReview = new System.Windows.Forms.Button();
            this.btnUserReviews = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnAddNewDiscount = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDiscounts = new System.Windows.Forms.DataGridView();
            this.DiscountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountPercentageString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromShortDateString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToShortDateString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInStock)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGallery
            // 
            this.btnGallery.BackColor = System.Drawing.Color.DarkRed;
            this.btnGallery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGallery.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGallery.FlatAppearance.BorderSize = 0;
            this.btnGallery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGallery.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGallery.ForeColor = System.Drawing.Color.White;
            this.btnGallery.Location = new System.Drawing.Point(87, 353);
            this.btnGallery.Name = "btnGallery";
            this.btnGallery.Size = new System.Drawing.Size(214, 32);
            this.btnGallery.TabIndex = 119;
            this.btnGallery.Text = "Product media gallery";
            this.btnGallery.UseVisualStyleBackColor = false;
            this.btnGallery.Click += new System.EventHandler(this.btnGallery_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblProduct);
            this.panel5.Location = new System.Drawing.Point(98, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(804, 61);
            this.panel5.TabIndex = 118;
            // 
            // lblProduct
            // 
            this.lblProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProduct.Font = new System.Drawing.Font("Calibri Light", 30F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(0, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(804, 61);
            this.lblProduct.TabIndex = 98;
            this.lblProduct.Text = "New product";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(620, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 23);
            this.label2.TabIndex = 117;
            this.label2.Text = "In stock:";
            // 
            // numInStock
            // 
            this.numInStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numInStock.Location = new System.Drawing.Point(624, 317);
            this.numInStock.Name = "numInStock";
            this.numInStock.Size = new System.Drawing.Size(69, 30);
            this.numInStock.TabIndex = 116;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cmbManufacturer);
            this.panel4.Location = new System.Drawing.Point(308, 255);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(289, 27);
            this.panel4.TabIndex = 115;
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.BackColor = System.Drawing.SystemColors.Window;
            this.cmbManufacturer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbManufacturer.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbManufacturer.FormattingEnabled = true;
            this.cmbManufacturer.Location = new System.Drawing.Point(0, 0);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(287, 27);
            this.cmbManufacturer.TabIndex = 61;
            this.cmbManufacturer.Validating += new System.ComponentModel.CancelEventHandler(this.cmbManufacturer_Validating);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbProductType);
            this.panel3.Location = new System.Drawing.Point(307, 189);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(289, 28);
            this.panel3.TabIndex = 114;
            // 
            // cmbProductType
            // 
            this.cmbProductType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbProductType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProductType.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Location = new System.Drawing.Point(0, 0);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(287, 27);
            this.cmbProductType.TabIndex = 60;
            this.cmbProductType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbProductType_Validating);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkRed;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(825, 353);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 32);
            this.btnSave.TabIndex = 113;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.DarkRed;
            this.btnAddImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddImage.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddImage.FlatAppearance.BorderSize = 0;
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImage.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.ForeColor = System.Drawing.Color.White;
            this.btnAddImage.Location = new System.Drawing.Point(469, 320);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(127, 27);
            this.btnAddImage.TabIndex = 112;
            this.btnAddImage.Text = "Add thumbnail";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(303, 294);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 23);
            this.label15.TabIndex = 111;
            this.label15.Text = "Thumbnail:";
            // 
            // txtImageInput
            // 
            this.txtImageInput.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageInput.Location = new System.Drawing.Point(307, 320);
            this.txtImageInput.Name = "txtImageInput";
            this.txtImageInput.Size = new System.Drawing.Size(156, 27);
            this.txtImageInput.TabIndex = 110;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(303, 230);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 23);
            this.label14.TabIndex = 109;
            this.label14.Text = "Manufacturer:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(700, 294);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(53, 23);
            this.lblPrice.TabIndex = 108;
            this.lblPrice.Text = "Price:";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(704, 319);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(209, 27);
            this.txtPrice.TabIndex = 107;
            this.txtPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrice_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(625, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 23);
            this.label5.TabIndex = 106;
            this.label5.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(624, 120);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(289, 162);
            this.txtDescription.TabIndex = 105;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 23);
            this.label4.TabIndex = 104;
            this.label4.Text = "Product type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 23);
            this.label1.TabIndex = 103;
            this.label1.Text = "Product name:";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(87, 100);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(214, 247);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 102;
            this.pictureBox.TabStop = false;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(307, 120);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(289, 27);
            this.txtProductName.TabIndex = 101;
            this.txtProductName.Validating += new System.ComponentModel.CancelEventHandler(this.txtProductName_Validating);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnReview
            // 
            this.btnReview.BackColor = System.Drawing.Color.DarkRed;
            this.btnReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReview.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnReview.FlatAppearance.BorderSize = 0;
            this.btnReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReview.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReview.ForeColor = System.Drawing.Color.White;
            this.btnReview.Location = new System.Drawing.Point(431, 353);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(118, 32);
            this.btnReview.TabIndex = 120;
            this.btnReview.Text = "Staff Review";
            this.btnReview.UseVisualStyleBackColor = false;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // btnUserReviews
            // 
            this.btnUserReviews.BackColor = System.Drawing.Color.DarkRed;
            this.btnUserReviews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserReviews.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUserReviews.FlatAppearance.BorderSize = 0;
            this.btnUserReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserReviews.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserReviews.ForeColor = System.Drawing.Color.White;
            this.btnUserReviews.Location = new System.Drawing.Point(307, 353);
            this.btnUserReviews.Name = "btnUserReviews";
            this.btnUserReviews.Size = new System.Drawing.Size(118, 32);
            this.btnUserReviews.TabIndex = 121;
            this.btnUserReviews.Text = "User Review";
            this.btnUserReviews.UseVisualStyleBackColor = false;
            this.btnUserReviews.Click += new System.EventHandler(this.btnUserReviews_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkRed;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(89, 32);
            this.btnBack.TabIndex = 122;
            this.btnBack.Text = "<- Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.BackColor = System.Drawing.Color.DarkRed;
            this.btnDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiscount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDiscount.FlatAppearance.BorderSize = 0;
            this.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscount.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDiscount.Location = new System.Drawing.Point(679, 353);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(140, 32);
            this.btnDiscount.TabIndex = 123;
            this.btnDiscount.Text = "Active Discount";
            this.btnDiscount.UseVisualStyleBackColor = false;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnAddNewDiscount
            // 
            this.btnAddNewDiscount.BackColor = System.Drawing.Color.DarkRed;
            this.btnAddNewDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewDiscount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddNewDiscount.FlatAppearance.BorderSize = 0;
            this.btnAddNewDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewDiscount.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewDiscount.ForeColor = System.Drawing.Color.White;
            this.btnAddNewDiscount.Location = new System.Drawing.Point(555, 353);
            this.btnAddNewDiscount.Name = "btnAddNewDiscount";
            this.btnAddNewDiscount.Size = new System.Drawing.Size(118, 32);
            this.btnAddNewDiscount.TabIndex = 124;
            this.btnAddNewDiscount.Text = "New Discount";
            this.btnAddNewDiscount.UseVisualStyleBackColor = false;
            this.btnAddNewDiscount.Click += new System.EventHandler(this.btnAddNewDiscount_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDiscounts);
            this.panel1.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(87, 391);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 309);
            this.panel1.TabIndex = 126;
            // 
            // dgvDiscounts
            // 
            this.dgvDiscounts.AllowUserToAddRows = false;
            this.dgvDiscounts.AllowUserToDeleteRows = false;
            this.dgvDiscounts.AllowUserToResizeColumns = false;
            this.dgvDiscounts.AllowUserToResizeRows = false;
            this.dgvDiscounts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiscounts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDiscounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDiscounts.ColumnHeadersHeight = 24;
            this.dgvDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDiscounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DiscountID,
            this.DiscountPercentageString,
            this.FromShortDateString,
            this.ToShortDateString,
            this.Active});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDiscounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiscounts.EnableHeadersVisualStyles = false;
            this.dgvDiscounts.GridColor = System.Drawing.SystemColors.Control;
            this.dgvDiscounts.Location = new System.Drawing.Point(0, 0);
            this.dgvDiscounts.Name = "dgvDiscounts";
            this.dgvDiscounts.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiscounts.RowHeadersVisible = false;
            this.dgvDiscounts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDiscounts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDiscounts.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDiscounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscounts.Size = new System.Drawing.Size(826, 309);
            this.dgvDiscounts.TabIndex = 1;
            this.dgvDiscounts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDiscounts_MouseDoubleClick);
            // 
            // DiscountID
            // 
            this.DiscountID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DiscountID.DataPropertyName = "DiscountID";
            this.DiscountID.HeaderText = "DiscountID";
            this.DiscountID.Name = "DiscountID";
            this.DiscountID.ReadOnly = true;
            this.DiscountID.Visible = false;
            this.DiscountID.Width = 114;
            // 
            // DiscountPercentageString
            // 
            this.DiscountPercentageString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DiscountPercentageString.DataPropertyName = "DiscountPercentageString";
            this.DiscountPercentageString.HeaderText = "Discount percentage";
            this.DiscountPercentageString.Name = "DiscountPercentageString";
            this.DiscountPercentageString.ReadOnly = true;
            // 
            // FromShortDateString
            // 
            this.FromShortDateString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FromShortDateString.DataPropertyName = "FromShortDateString";
            this.FromShortDateString.HeaderText = "From";
            this.FromShortDateString.Name = "FromShortDateString";
            this.FromShortDateString.ReadOnly = true;
            // 
            // ToShortDateString
            // 
            this.ToShortDateString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ToShortDateString.DataPropertyName = "ToShortDateString";
            this.ToShortDateString.HeaderText = "To";
            this.ToShortDateString.Name = "ToShortDateString";
            this.ToShortDateString.ReadOnly = true;
            this.ToShortDateString.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ucProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddNewDiscount);
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUserReviews);
            this.Controls.Add(this.btnReview);
            this.Controls.Add(this.btnGallery);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numInStock);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtImageInput);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.txtProductName);
            this.Font = new System.Drawing.Font("Calibri Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucProductDetail";
            this.Size = new System.Drawing.Size(1000, 719);
            this.Load += new System.EventHandler(this.ucProductDetail_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numInStock)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGallery;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numInStock;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtImageInput;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Button btnUserReviews;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Button btnAddNewDiscount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDiscounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercentageString;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromShortDateString;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToShortDateString;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
    }
}
