using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spend_smart
{
    public partial class loadingForm : Form
    {
        private Timer eveningNotificationTimer;

        public loadingForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(BorderRadius.CreateRoundRectRgn(0, 0, Width, Height, 18, 18));

            eveningNotificationTimer = new Timer();
            eveningNotificationTimer.Interval = EveningCalculateTimerInterval();
            eveningNotificationTimer.Tick += EveningNotificationTimer_Tick;
            eveningNotificationTimer.Start();
        }

        private async void loadingForm_Load(object sender, EventArgs e)
        {
            await StartLoadingAsync();
        }

        private async Task StartLoadingAsync()
        {

            bool isDatabaseConnected = await Task.Run(() => dbConn.Instance.TestConnection());

            for (int i = 0; i <= 100; i += 10)
            {
                await Task.Delay(200);
                progressBar1.Value = i;
            }

            progressBar1.Visible = false;

            loginForm login = new loginForm();
            login.Show();
            this.Hide();
        }

        // Notification timer interval calculation
        private int EveningCalculateTimerInterval()
        {
            DateTime now = DateTime.Now;
            DateTime eveningNotificationTime = new DateTime(now.Year, now.Month, now.Day, 22, 35, 0);
            if (now > eveningNotificationTime)
            {
                eveningNotificationTime = eveningNotificationTime.AddDays(1);
            }
            return (int)(eveningNotificationTime - now).TotalMilliseconds;
        }

        // Event handler for the evening notification timer tick
        private void EveningNotificationTimer_Tick(object sender, EventArgs e)
        {
            ShowNotification("Good Evening!, It is time to add your expenses");
            // Reset timer for the next day
            eveningNotificationTimer.Interval = EveningCalculateTimerInterval();
        }

        // Method to show the notification
        private void ShowNotification(string message)
        {
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipTitle = "Notification";
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(2000);
        }

        // Event handler for the menu item to show the application window
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the loading form
            this.Show();
            this.Activate();

            // Start loading tasks if they haven't been started yet
            if (!progressBar1.Visible)
            {
                progressBar1.Visible = true;
                _ = StartLoadingAsync();
            }
        }

        // Event handler for the menu item to exit the application
        private void exitToolStripMenuItem_Clic(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Event handler for double-clicking the system tray icon
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.Activate(); // Activate the form and bring it to the front

            // Start loading tasks if they haven't been started yet
            if (!progressBar1.Visible)
            {
                progressBar1.Visible = true;
                _ = StartLoadingAsync();
            }
        }

        private void loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the form is closing due to application exit
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                // Show the notification
                ShowNotification("Application is closing. Goodbye!");
            }
        }
    }
}
