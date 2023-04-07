namespace side
{
    partial class Requirement5
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
            this.LblMonth = new System.Windows.Forms.Label();
            this.BtnGetNewCaseId = new System.Windows.Forms.Button();
            this.TxtNewCaseId = new System.Windows.Forms.TextBox();
            this.BtnCopyCaseId = new System.Windows.Forms.Button();
            this.BtnQuery = new System.Windows.Forms.Button();
            this.TxtResult = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.TxtMonth = new System.Windows.Forms.MaskedTextBox();
            this.BtnETL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblMonth
            // 
            this.LblMonth.AutoSize = true;
            this.LblMonth.Location = new System.Drawing.Point(39, 34);
            this.LblMonth.Name = "LblMonth";
            this.LblMonth.Size = new System.Drawing.Size(29, 12);
            this.LblMonth.TabIndex = 1;
            this.LblMonth.Text = "月份";
            // 
            // BtnGetNewCaseId
            // 
            this.BtnGetNewCaseId.Location = new System.Drawing.Point(361, 30);
            this.BtnGetNewCaseId.Name = "BtnGetNewCaseId";
            this.BtnGetNewCaseId.Size = new System.Drawing.Size(75, 23);
            this.BtnGetNewCaseId.TabIndex = 2;
            this.BtnGetNewCaseId.Text = "取號";
            this.BtnGetNewCaseId.UseVisualStyleBackColor = true;
            this.BtnGetNewCaseId.Click += new System.EventHandler(this.BtnGetNewCaseId_Click);
            // 
            // TxtNewCaseId
            // 
            this.TxtNewCaseId.Location = new System.Drawing.Point(361, 59);
            this.TxtNewCaseId.Name = "TxtNewCaseId";
            this.TxtNewCaseId.ReadOnly = true;
            this.TxtNewCaseId.Size = new System.Drawing.Size(257, 22);
            this.TxtNewCaseId.TabIndex = 3;
            // 
            // BtnCopyCaseId
            // 
            this.BtnCopyCaseId.Location = new System.Drawing.Point(361, 87);
            this.BtnCopyCaseId.Name = "BtnCopyCaseId";
            this.BtnCopyCaseId.Size = new System.Drawing.Size(75, 23);
            this.BtnCopyCaseId.TabIndex = 4;
            this.BtnCopyCaseId.Text = "複製號碼";
            this.BtnCopyCaseId.UseVisualStyleBackColor = true;
            this.BtnCopyCaseId.Click += new System.EventHandler(this.BtnCopyCaseId_Click);
            // 
            // BtnQuery
            // 
            this.BtnQuery.Location = new System.Drawing.Point(243, 58);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 23);
            this.BtnQuery.TabIndex = 5;
            this.BtnQuery.Text = "查詢";
            this.BtnQuery.UseVisualStyleBackColor = true;
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // TxtResult
            // 
            this.TxtResult.Location = new System.Drawing.Point(41, 89);
            this.TxtResult.Multiline = true;
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.ReadOnly = true;
            this.TxtResult.Size = new System.Drawing.Size(277, 286);
            this.TxtResult.TabIndex = 6;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(39, 64);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(29, 12);
            this.LblAccount.TabIndex = 7;
            this.LblAccount.Text = "帳號";
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(74, 59);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(100, 22);
            this.TxtAccount.TabIndex = 8;
            // 
            // TxtMonth
            // 
            this.TxtMonth.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.TxtMonth.Location = new System.Drawing.Point(74, 31);
            this.TxtMonth.Mask = "0000/00";
            this.TxtMonth.Name = "TxtMonth";
            this.TxtMonth.Size = new System.Drawing.Size(100, 22);
            this.TxtMonth.TabIndex = 9;
            // 
            // BtnETL
            // 
            this.BtnETL.Location = new System.Drawing.Point(361, 145);
            this.BtnETL.Name = "BtnETL";
            this.BtnETL.Size = new System.Drawing.Size(75, 23);
            this.BtnETL.TabIndex = 10;
            this.BtnETL.Text = "ETL";
            this.BtnETL.UseVisualStyleBackColor = true;
            this.BtnETL.Click += new System.EventHandler(this.BtnETL_Click);
            // 
            // Requirement5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.BtnETL);
            this.Controls.Add(this.TxtMonth);
            this.Controls.Add(this.TxtAccount);
            this.Controls.Add(this.LblAccount);
            this.Controls.Add(this.TxtResult);
            this.Controls.Add(this.BtnQuery);
            this.Controls.Add(this.BtnCopyCaseId);
            this.Controls.Add(this.TxtNewCaseId);
            this.Controls.Add(this.BtnGetNewCaseId);
            this.Controls.Add(this.LblMonth);
            this.Name = "Requirement5";
            this.Text = "Requirement5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblMonth;
        private System.Windows.Forms.Button BtnGetNewCaseId;
        private System.Windows.Forms.TextBox TxtNewCaseId;
        private System.Windows.Forms.Button BtnCopyCaseId;
        private System.Windows.Forms.Button BtnQuery;
        private System.Windows.Forms.TextBox TxtResult;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.MaskedTextBox TxtMonth;
        private System.Windows.Forms.Button BtnETL;
    }
}