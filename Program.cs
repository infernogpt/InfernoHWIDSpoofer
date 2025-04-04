using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace HwidSpoofer
{
    static class Program
    {
        private static ILogger<Program> logger;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Debug);
            });

            logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Application starting...");

            try
            {
                Application.Run(new MainForm(logger));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unexpected error occurred.");
                MessageBox.Show("An unexpected error occurred. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            logger.LogInformation("Application exiting...");
        }
    }
}
