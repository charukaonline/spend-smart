using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spend_smart
{
    public partial class loginForm : Form
    {
        public Point mouseLocation;
        private int attempts = 0;
        private DateTime lockoutEndTime;

        public loginForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(BorderRadius.CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
        }

        // Dragging part
        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        // Dragging part
        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = false;
            pinValidationLbl.Visible = false;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (DateTime.Now < lockoutEndTime)
            {
                TimeSpan remainingTime = lockoutEndTime - DateTime.Now;
                string remainingTimeString = $"{(int)remainingTime.TotalMinutes}:{remainingTime.Seconds:00}";
                MessageBox.Show($"You are locked out. Please try again after {remainingTimeString}.");
                return;
            }

            if (userNameTxt.Text == "Admin" && passwordTxtBox.Text == "123")
            {
                menuControls dashboard = new menuControls();
                dashboard.Show();
                this.Hide();
                ResetAttempts(); // Reset attempts on successful login
            }
            else
            {
                attempts++;

                if (attempts >= 3)
                {
                    lockoutEndTime = DateTime.Now.AddMinutes(1); // Lockout for 1 minute
                    MessageBox.Show($"You have reached maximum number of attempts.\n Login will be disabled for 1 minute.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Invalid credentials. Attempts done: {attempts} out of 3", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (attempts >= 3)
            {
                loginBtn.Enabled = false; // Disable login button during lockout period
                labelLockoutTimer.Visible = true; // Show lockout timer label
                Timer timer = new Timer();
                timer.Interval = 1000; // 1 second
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= lockoutEndTime)
            {
                ((Timer)sender).Stop();
                loginBtn.Enabled = true; // Re-enable login button after lockout period
                labelLockoutTimer.Visible = false; // Hide lockout timer label
                ResetAttempts(); // Reset attempts after lockout period ends
            }
            else
            {
                TimeSpan remainingTime = lockoutEndTime - DateTime.Now;
                string remainingTimeString = $"{(int)remainingTime.TotalMinutes}:{remainingTime.Seconds:00}";
                labelLockoutTimer.Text = $"Lockout remaining: {remainingTimeString}";
            }
        }

        private void ResetAttempts()
        {
            attempts = 0;
        }

        private void userNameTxt_Enter(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = true;
        }

        private void userNameTxt_TextChange(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = false;
        }

        private void passwordTxtBox_Enter(object sender, EventArgs e)
        {
            pinValidationLbl.Visible = true;
        }

        private void passwordTxtBox_TextChanged(object sender, EventArgs e)
        {
            pinValidationLbl.Visible = false;
        }

        private void registerLbl_Click(object sender, EventArgs e)
        {
            registerForm registerForm = new registerForm();
            registerForm.Show();
            this.Hide();
        }
    }
}