namespace ElTengyApp
{
    partial class frmGetData
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.txtEncryptData = new System.Windows.Forms.TextBox();
            this.lblEncryptData = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.dtBirth = new System.Windows.Forms.DateTimePicker();
            this.lblBirth = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(562, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(214, 43);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(426, 16);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(214, 43);
            this.btnGet.TabIndex = 24;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtEncryptData
            // 
            this.txtEncryptData.Location = new System.Drawing.Point(19, 152);
            this.txtEncryptData.Multiline = true;
            this.txtEncryptData.Name = "txtEncryptData";
            this.txtEncryptData.Size = new System.Drawing.Size(750, 131);
            this.txtEncryptData.TabIndex = 23;
            // 
            // lblEncryptData
            // 
            this.lblEncryptData.AutoSize = true;
            this.lblEncryptData.Location = new System.Drawing.Point(12, 112);
            this.lblEncryptData.Name = "lblEncryptData";
            this.lblEncryptData.Size = new System.Drawing.Size(237, 37);
            this.lblEncryptData.TabIndex = 22;
            this.lblEncryptData.Text = "Encrypted Data";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(555, 308);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(214, 43);
            this.btnDecrypt.TabIndex = 21;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // cbSex
            // 
            this.cbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Location = new System.Drawing.Point(655, 418);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(121, 45);
            this.cbSex.TabIndex = 20;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(579, 428);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(70, 37);
            this.lblSex.TabIndex = 19;
            this.lblSex.Text = "Sex";
            // 
            // dtBirth
            // 
            this.dtBirth.Location = new System.Drawing.Point(128, 419);
            this.dtBirth.Name = "dtBirth";
            this.dtBirth.Size = new System.Drawing.Size(421, 44);
            this.dtBirth.TabIndex = 18;
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(19, 425);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(83, 37);
            this.lblBirth.TabIndex = 17;
            this.lblBirth.Text = "Birth";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(128, 357);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(421, 44);
            this.txtName.TabIndex = 16;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(19, 360);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 37);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Name";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(61, 13);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(339, 44);
            this.txtId.TabIndex = 14;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 16);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(43, 37);
            this.lblId.TabIndex = 13;
            this.lblId.Text = "Id";
            // 
            // frmGetData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 558);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtEncryptData);
            this.Controls.Add(this.lblEncryptData);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.dtBirth);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "frmGetData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGetData";
            this.Load += new System.EventHandler(this.frmGetData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TextBox txtEncryptData;
        private System.Windows.Forms.Label lblEncryptData;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.DateTimePicker dtBirth;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
    }
}