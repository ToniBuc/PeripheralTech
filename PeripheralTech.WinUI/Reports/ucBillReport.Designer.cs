namespace PeripheralTech.WinUI.Reports
{
    partial class ucBillReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.OrderProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.btnBack.TabIndex = 130;
            this.btnBack.Text = "<- Back";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblHeader);
            this.panel6.Location = new System.Drawing.Point(98, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(804, 65);
            this.panel6.TabIndex = 129;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Calibri Light", 22F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHeader.Size = new System.Drawing.Size(804, 65);
            this.lblHeader.TabIndex = 46;
            this.lblHeader.Text = "Bill";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrderProductBindingSource
            // 
            this.OrderProductBindingSource.DataSource = typeof(PeripheralTech.Model.OrderProduct);
            // 
            // BillBindingSource
            // 
            this.BillBindingSource.DataSource = typeof(PeripheralTech.Model.Bill);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "dsOrderProducts";
            reportDataSource1.Value = this.OrderProductBindingSource;
            reportDataSource2.Name = "dsBill";
            reportDataSource2.Value = this.BillBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "PeripheralTech.WinUI.Reports.BillReport.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(181, 89);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(638, 614);
            this.reportViewer.TabIndex = 131;
            // 
            // ucBillReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel6);
            this.Font = new System.Drawing.Font("Calibri Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucBillReport";
            this.Size = new System.Drawing.Size(1000, 719);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrderProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.BindingSource OrderProductBindingSource;
        private System.Windows.Forms.BindingSource BillBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}
