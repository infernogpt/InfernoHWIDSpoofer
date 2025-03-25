using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace HwidSpoofer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public partial class MainForm : Form
    {
        private Button btnSpoof;
        private LinkLabel linkLabel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnSpoof = new Button();
            this.linkLabel = new LinkLabel();

            this.SuspendLayout();

            // 
            // btnSpoof
            // 
            this.btnSpoof.BackColor = System.Drawing.Color.Blue;
            this.btnSpoof.ForeColor = System.Drawing.Color.White;
            this.btnSpoof.Location = new System.Drawing.Point(100, 50);
            this.btnSpoof.Name = "btnSpoof";
            this.btnSpoof.Size = new System.Drawing.Size(200, 50);
            this.btnSpoof.TabIndex = 0;
            this.btnSpoof.Text = "Spoof HWID";
            this.btnSpoof.UseVisualStyleBackColor = false;
            this.btnSpoof.Click += new EventHandler(this.btnSpoof_Click);

            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel.Location = new System.Drawing.Point(150, 120);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(100, 20);
            this.linkLabel.TabIndex = 1;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "GitHub Repo";
            this.linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.btnSpoof);
            this.Name = "MainForm";
            this.Text = "HWID Spoofer";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnSpoof_Click(object sender, EventArgs e)
        {
            string originalHWID = GetHWID();
            string randomHWID = GenerateRandomHWID();
            SpoofHWID(randomHWID);
            MessageBox.Show($"Original HWID: {originalHWID}\nSpoofed HWID: {randomHWID}", "HWID Spoofed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/infernogpt/ShitHWIDSpoofer") { UseShellExecute = true });
        }

        static string GetHWID()
        {
            string hwid = "Unknown";
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\disk\Enum");
                if (key != null)
                {
                    hwid = key.GetValue("0").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hwid;
        }

        static void SpoofHWID(string newSerial)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\disk\Enum", true);
                if (key != null)
                {
                    key.SetValue("0", newSerial);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static string GenerateRandomHWID()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[4];
                rng.GetBytes(randomBytes);
                uint randomUint = BitConverter.ToUInt32(randomBytes, 0);
                return randomUint.ToString("X8");
            }
        }
    }
}
