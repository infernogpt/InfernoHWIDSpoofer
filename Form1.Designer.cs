namespace HwidSpoofer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSpoof = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSpoof
            // 
            this.btnSpoof.BackColor = System.Drawing.Color.Blue;
            this.btnSpoof.ForeColor = System.Drawing.Color.White;
            this.btnSpoof.Location = new System.Drawing.Point(50, 80);
            this.btnSpoof.Name = "btnSpoof";
            this.btnSpoof.Size = new System.Drawing.Size(150, 50);
            this.btnSpoof.TabIndex = 0;
            this.btnSpoof.Text = "Spoof HWID";
            this.btnSpoof.UseVisualStyleBackColor = false;
            this.btnSpoof.Click += new System.EventHandler(this.BtnSpoof_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.BackColor = System.Drawing.Color.Red;
            this.btnRevert.ForeColor = System.Drawing.Color.White;
            this.btnRevert.Location = new System.Drawing.Point(220, 80);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(150, 50);
            this.btnRevert.TabIndex = 1;
            this.btnRevert.Text = "Revert to Original";
            this.btnRevert.UseVisualStyleBackColor = false;
            this.btnRevert.Click += new System.EventHandler(this.BtnRevert_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.Green;
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(50, 150);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(150, 50);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "Backup HWID";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.Orange;
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(220, 150);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(150, 50);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restore HWID";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel.Location = new System.Drawing.Point(150, 220);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(100, 20);
            this.linkLabel.TabIndex = 4;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "GitHub Repo";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(85, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(230, 25);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "HWID Spoofer by Inferno";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(150, 250);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(160, 20);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "HWID NOT SPOOFED";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.btnSpoof);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnRestore);
            this.Name = "MainForm";
            this.Text = "HWID Spoofer by Inferno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnSpoof;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Label lblTitle;
    }
}
