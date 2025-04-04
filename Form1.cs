using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace HwidSpoofer
{
    public partial class MainForm : Form
    {
        private readonly ILogger<MainForm> logger;
        private string originalHWID;
        private string backupHWID;
        private NotifyIcon notifyIcon;

        public MainForm(ILogger<MainForm> logger)
        {
            InitializeComponent();
            this.logger = logger;

            originalHWID = RetrieveHWID();
            InitializeNotifyIcon();

            lblStatus.Text = "HWID NOT SPOOFED";
            lblStatus.ForeColor = System.Drawing.Color.Red;

            logger.LogInformation("MainForm initialized.");
        }

        private void BtnSpoof_Click(object sender, EventArgs e)
        {
            try
            {
                string randomHWID = GenerateRandomHWID();
                UpdateHWID(randomHWID);
                ShowMessage($"Original HWID: {originalHWID}\nSpoofed HWID: {randomHWID}", "HWID Spoofed", MessageBoxIcon.Information);
                ShowNotification("HWID Spoofed", $"Original HWID: {originalHWID}\nSpoofed HWID: {randomHWID}");
                UpdateStatus("HWID SPOOFED", System.Drawing.Color.Green);
                logger.LogInformation("HWID spoofed from {OriginalHWID} to {RandomHWID}", originalHWID, randomHWID);
            }
            catch (Exception ex)
            {
                HandleException(ex, "spoofing the HWID");
            }
        }

        private void BtnRevert_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateHWID(originalHWID);
                ShowMessage($"HWID reverted to original value: {originalHWID}", "HWID Reverted", MessageBoxIcon.Information);
                ShowNotification("HWID Reverted", $"HWID reverted to original value: {originalHWID}");
                UpdateStatus("HWID NOT SPOOFED", System.Drawing.Color.Red);
                logger.LogInformation("HWID reverted to original value: {OriginalHWID}", originalHWID);
            }
            catch (Exception ex)
            {
                HandleException(ex, "reverting the HWID");
            }
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                backupHWID = RetrieveHWID();
                ShowMessage($"HWID backed up: {backupHWID}", "HWID Backup", MessageBoxIcon.Information);
                ShowNotification("HWID Backup", $"HWID backed up: {backupHWID}");
                logger.LogInformation("HWID backed up: {BackupHWID}", backupHWID);
            }
            catch (Exception ex)
            {
                HandleException(ex, "backing up the HWID");
            }
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(backupHWID))
                {
                    ShowMessage("No HWID backup found.", "Error", MessageBoxIcon.Error);
                    return;
                }

                UpdateHWID(backupHWID);
                ShowMessage($"HWID restored to backup value: {backupHWID}", "HWID Restored", MessageBoxIcon.Information);
                ShowNotification("HWID Restored", $"HWID restored to backup value: {backupHWID}");
                UpdateStatus("HWID NOT SPOOFED", System.Drawing.Color.Red);
                logger.LogInformation("HWID restored to backup value: {BackupHWID}", backupHWID);
            }
            catch (Exception ex)
            {
                HandleException(ex, "restoring the HWID");
            }
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/infernogpt/ShitHWIDSpoofer") { UseShellExecute = true });
        }

        private void LinkAzureMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://dsc.gg/azuremodding") { UseShellExecute = true });
        }

        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
        }

        private void ShowNotification(string title, string text)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = text;
            notifyIcon.ShowBalloonTip(3000);
        }

        private void ShowMessage(string message, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }

        private void UpdateStatus(string status, System.Drawing.Color color)
        {
            lblStatus.Text = status;
            lblStatus.ForeColor = color;
        }

        private void HandleException(Exception ex, string action)
        {
            logger.LogError(ex, $"An error occurred while {action}.");
            ShowMessage($"An error occurred while {action}: {ex.Message}", "Error", MessageBoxIcon.Error);
            ShowNotification("Error", $"An error occurred while {action}: {ex.Message}");
        }

        private static string RetrieveHWID()
        {
            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\disk\Enum");
                return key?.GetValue("0")?.ToString() ?? "Unknown";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Unknown";
            }
        }

        private static void UpdateHWID(string newSerial)
        {
            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\disk\Enum", writable: true);
                key?.SetValue("0", newSerial);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to update HWID", ex);
            }
        }

        private static string GenerateRandomHWID()
        {
            using var rng = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[4];
            rng.GetBytes(randomBytes);
            return BitConverter.ToUInt32(randomBytes, 0).ToString("X8");
        }
    }
}
