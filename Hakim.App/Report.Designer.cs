namespace Hakim.App
{
    partial class Report
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgReport = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbReport = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.lblFilter1 = new System.Windows.Forms.Label();
            this.cbFilter1 = new System.Windows.Forms.ComboBox();
            this.lblFilter2 = new System.Windows.Forms.Label();
            this.cbFilter2 = new System.Windows.Forms.ComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(32, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(79, 36);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgReport
            // 
            this.dgReport.AllowUserToAddRows = false;
            this.dgReport.AllowUserToDeleteRows = false;
            this.dgReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReport.Location = new System.Drawing.Point(0, 113);
            this.dgReport.Name = "dgReport";
            this.dgReport.ReadOnly = true;
            this.dgReport.RowHeadersVisible = false;
            this.dgReport.Size = new System.Drawing.Size(432, 355);
            this.dgReport.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 9);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "نوع گزارش:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbReport
            // 
            this.cbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport.FormattingEnabled = true;
            this.cbReport.Location = new System.Drawing.Point(232, 6);
            this.cbReport.Name = "cbReport";
            this.cbReport.Size = new System.Drawing.Size(121, 21);
            this.cbReport.TabIndex = 6;
            this.cbReport.TextChanged += new System.EventHandler(this.cbReport_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(32, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 36);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "بازگشت";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 35);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "تاریخ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(232, 32);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(121, 21);
            this.txtDate.TabIndex = 11;
            this.txtDate.ValidatingType = typeof(System.DateTime);
            // 
            // lblFilter1
            // 
            this.lblFilter1.AutoSize = true;
            this.lblFilter1.Location = new System.Drawing.Point(359, 61);
            this.lblFilter1.Name = "lblFilter1";
            this.lblFilter1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFilter1.Size = new System.Drawing.Size(51, 13);
            this.lblFilter1.TabIndex = 13;
            this.lblFilter1.Text = "فیلتر اول:";
            this.lblFilter1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbFilter1
            // 
            this.cbFilter1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter1.FormattingEnabled = true;
            this.cbFilter1.Location = new System.Drawing.Point(232, 58);
            this.cbFilter1.Name = "cbFilter1";
            this.cbFilter1.Size = new System.Drawing.Size(121, 21);
            this.cbFilter1.TabIndex = 12;
            // 
            // lblFilter2
            // 
            this.lblFilter2.AutoSize = true;
            this.lblFilter2.Location = new System.Drawing.Point(359, 88);
            this.lblFilter2.Name = "lblFilter2";
            this.lblFilter2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFilter2.Size = new System.Drawing.Size(53, 13);
            this.lblFilter2.TabIndex = 15;
            this.lblFilter2.Text = "فیلتر دوم:";
            this.lblFilter2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbFilter2
            // 
            this.cbFilter2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter2.FormattingEnabled = true;
            this.cbFilter2.Location = new System.Drawing.Point(232, 85);
            this.cbFilter2.Name = "cbFilter2";
            this.cbFilter2.Size = new System.Drawing.Size(121, 21);
            this.cbFilter2.TabIndex = 14;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(117, 19);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(79, 36);
            this.btnReport.TabIndex = 16;
            this.btnReport.Text = "نمایش";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(117, 61);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 36);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "پاک کردن";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(8, 473);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(79, 13);
            this.lblCurrentUser.TabIndex = 18;
            this.lblCurrentUser.Text = "کاربر سیستم:  ";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(229, 473);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(49, 13);
            this.lblTotalPrice.TabIndex = 19;
            this.lblTotalPrice.Text = "مجموع:  ";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 493);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblFilter2);
            this.Controls.Add(this.cbFilter2);
            this.Controls.Add(this.lblFilter1);
            this.Controls.Add(this.cbFilter1);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbReport);
            this.Controls.Add(this.dgReport);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbReport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.Label lblFilter1;
        private System.Windows.Forms.ComboBox cbFilter1;
        private System.Windows.Forms.Label lblFilter2;
        private System.Windows.Forms.ComboBox cbFilter2;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblTotalPrice;
    }
}