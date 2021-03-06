namespace PeripheralTech.WinUI.Product
{
    partial class ucProductGallery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProductGallery));
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtImageInput = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvImages = new System.Windows.Forms.DataGridView();
            this.ProductImageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddVideo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteVideo = new System.Windows.Forms.Button();
            this.cmbVideos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVideoInput = new System.Windows.Forms.TextBox();
            this.btnPlayVideo = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImages)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.BackColor = System.Drawing.Color.DarkRed;
            this.btnDeleteImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteImage.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleteImage.FlatAppearance.BorderSize = 0;
            this.btnDeleteImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteImage.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteImage.ForeColor = System.Drawing.Color.White;
            this.btnDeleteImage.Location = new System.Drawing.Point(303, 115);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(190, 27);
            this.btnDeleteImage.TabIndex = 102;
            this.btnDeleteImage.Text = "Delete selected image";
            this.btnDeleteImage.UseVisualStyleBackColor = false;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
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
            this.btnAddImage.Location = new System.Drawing.Point(201, 115);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(98, 27);
            this.btnAddImage.TabIndex = 101;
            this.btnAddImage.Text = "Add image";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 23);
            this.label15.TabIndex = 100;
            this.label15.Text = "Image:";
            // 
            // txtImageInput
            // 
            this.txtImageInput.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageInput.Location = new System.Drawing.Point(3, 115);
            this.txtImageInput.Name = "txtImageInput";
            this.txtImageInput.Size = new System.Drawing.Size(192, 27);
            this.txtImageInput.TabIndex = 99;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvImages);
            this.panel4.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 148);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(490, 568);
            this.panel4.TabIndex = 98;
            // 
            // dgvImages
            // 
            this.dgvImages.AllowUserToAddRows = false;
            this.dgvImages.AllowUserToDeleteRows = false;
            this.dgvImages.AllowUserToResizeColumns = false;
            this.dgvImages.AllowUserToResizeRows = false;
            this.dgvImages.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvImages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvImages.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvImages.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvImages.ColumnHeadersHeight = 24;
            this.dgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductImageID,
            this.Image});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImages.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImages.EnableHeadersVisualStyles = false;
            this.dgvImages.GridColor = System.Drawing.SystemColors.Control;
            this.dgvImages.Location = new System.Drawing.Point(0, 0);
            this.dgvImages.Name = "dgvImages";
            this.dgvImages.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImages.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvImages.RowHeadersVisible = false;
            this.dgvImages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.dgvImages.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvImages.RowTemplate.Height = 240;
            this.dgvImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImages.Size = new System.Drawing.Size(490, 568);
            this.dgvImages.TabIndex = 1;
            this.dgvImages.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvImages_RowPostPaint);
            // 
            // ProductImageID
            // 
            this.ProductImageID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ProductImageID.DataPropertyName = "ProductImageID";
            this.ProductImageID.HeaderText = "ProductImageID";
            this.ProductImageID.Name = "ProductImageID";
            this.ProductImageID.ReadOnly = true;
            this.ProductImageID.Visible = false;
            this.ProductImageID.Width = 153;
            // 
            // Image
            // 
            this.Image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Image.DataPropertyName = "Image";
            this.Image.FillWeight = 200F;
            this.Image.HeaderText = "Images";
            this.Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblProductName);
            this.panel3.Location = new System.Drawing.Point(98, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(804, 67);
            this.panel3.TabIndex = 97;
            // 
            // lblProductName
            // 
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.Font = new System.Drawing.Font("Calibri Light", 30F, System.Drawing.FontStyle.Underline);
            this.lblProductName.Location = new System.Drawing.Point(0, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(804, 67);
            this.lblProductName.TabIndex = 31;
            this.lblProductName.Text = "Product name";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Location = new System.Drawing.Point(499, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 570);
            this.panel1.TabIndex = 103;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
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
            this.btnBack.TabIndex = 123;
            this.btnBack.Text = "<- Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 24);
            this.label1.TabIndex = 124;
            this.label1.Text = "Videos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(507, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 24);
            this.panel2.TabIndex = 125;
            // 
            // btnAddVideo
            // 
            this.btnAddVideo.BackColor = System.Drawing.Color.DarkRed;
            this.btnAddVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVideo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddVideo.FlatAppearance.BorderSize = 0;
            this.btnAddVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVideo.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVideo.ForeColor = System.Drawing.Color.White;
            this.btnAddVideo.Location = new System.Drawing.Point(705, 115);
            this.btnAddVideo.Name = "btnAddVideo";
            this.btnAddVideo.Size = new System.Drawing.Size(98, 27);
            this.btnAddVideo.TabIndex = 128;
            this.btnAddVideo.Text = "Add video";
            this.btnAddVideo.UseVisualStyleBackColor = false;
            this.btnAddVideo.Click += new System.EventHandler(this.btnAddVideo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(507, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 23);
            this.label2.TabIndex = 127;
            this.label2.Text = "Video:";
            // 
            // btnDeleteVideo
            // 
            this.btnDeleteVideo.BackColor = System.Drawing.Color.DarkRed;
            this.btnDeleteVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteVideo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleteVideo.FlatAppearance.BorderSize = 0;
            this.btnDeleteVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteVideo.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteVideo.ForeColor = System.Drawing.Color.White;
            this.btnDeleteVideo.Location = new System.Drawing.Point(807, 115);
            this.btnDeleteVideo.Name = "btnDeleteVideo";
            this.btnDeleteVideo.Size = new System.Drawing.Size(190, 27);
            this.btnDeleteVideo.TabIndex = 129;
            this.btnDeleteVideo.Text = "Delete selected video";
            this.btnDeleteVideo.UseVisualStyleBackColor = false;
            this.btnDeleteVideo.Click += new System.EventHandler(this.btnDeleteVideo_Click);
            // 
            // cmbVideos
            // 
            this.cmbVideos.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVideos.FormattingEnabled = true;
            this.cmbVideos.Location = new System.Drawing.Point(507, 205);
            this.cmbVideos.Name = "cmbVideos";
            this.cmbVideos.Size = new System.Drawing.Size(188, 27);
            this.cmbVideos.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(507, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 132;
            this.label3.Text = "Select Video:";
            // 
            // txtVideoInput
            // 
            this.txtVideoInput.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVideoInput.Location = new System.Drawing.Point(507, 115);
            this.txtVideoInput.Name = "txtVideoInput";
            this.txtVideoInput.Size = new System.Drawing.Size(192, 27);
            this.txtVideoInput.TabIndex = 133;
            // 
            // btnPlayVideo
            // 
            this.btnPlayVideo.BackColor = System.Drawing.Color.DarkRed;
            this.btnPlayVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayVideo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPlayVideo.FlatAppearance.BorderSize = 0;
            this.btnPlayVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayVideo.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayVideo.ForeColor = System.Drawing.Color.White;
            this.btnPlayVideo.Location = new System.Drawing.Point(705, 204);
            this.btnPlayVideo.Name = "btnPlayVideo";
            this.btnPlayVideo.Size = new System.Drawing.Size(98, 27);
            this.btnPlayVideo.TabIndex = 134;
            this.btnPlayVideo.Text = "Play";
            this.btnPlayVideo.UseVisualStyleBackColor = false;
            this.btnPlayVideo.Click += new System.EventHandler(this.btnPlayVideo_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(507, 238);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(486, 327);
            this.axWindowsMediaPlayer1.TabIndex = 131;
            // 
            // ucProductGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnPlayVideo);
            this.Controls.Add(this.txtVideoInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.cmbVideos);
            this.Controls.Add(this.btnDeleteVideo);
            this.Controls.Add(this.btnAddVideo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtImageInput);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Calibri Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucProductGallery";
            this.Size = new System.Drawing.Size(1000, 719);
            this.Load += new System.EventHandler(this.ucProductGallery_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImages)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtImageInput;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvImages;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductImageID;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddVideo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteVideo;
        private System.Windows.Forms.ComboBox cmbVideos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVideoInput;
        private System.Windows.Forms.Button btnPlayVideo;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}
