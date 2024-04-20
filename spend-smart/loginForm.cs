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
using System.Data.OleDb;
using System.Security.Cryptography;

namespace spend_smart
{
    public partial class loginForm : Form
    {
        public Point mouseLocation;
        private int attempts = 0;
        private DateTime lockoutEndTime;

        private dbConn db;

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

        private void UpdateStatus(bool isConnected)
        {
            if (isConnected)
            {
                dbStatusCircle.FillColor = Color.FromArgb(0, 120, 212); ;
                statusLabel.ForeColor = Color.FromArgb(0, 120, 212);
                statusLabel.Text += " All Systems normal";
            }
            else
            {
                dbStatusCircle.FillColor = Color.Red;
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text += " System Error";
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = false;
            pinValidationLbl.Visible = false;

            db = dbConn.Instance; // Initialize the dbConn object
            bool isConnected = db.TestConnection(); 
            UpdateStatus(isConnected);
        }

        private string connString = dbConn.Instance.connString;

        private static string hashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public class User
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Pin { get; set; }
            public string phoneNum { get; set; }
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

            string connString = dbConn.Instance.connString;
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                try
                {
                    conn.Open();

                    string username = userNameTxt.Text;
                    string pin = passwordTxtBox.Text;

                    string hashedPin = hashPassword(pin);

                    string query = "SELECT user_id, username, pin, phone FROM users WHERE username = @username";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@pin", hashedPin);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //string storedUsername = reader["username"].ToString();
                                //string storedHashedPin = reader["pin"].ToString();

                                User user = new User
                                {
                                    UserID = Convert.ToInt32(reader["user_id"]),
                                    Username = reader["username"].ToString(),
                                    Pin = reader["pin"].ToString(),
                                    phoneNum = reader["phone"].ToString()

                                };

                                string storedHashedPin = user.Pin;

                                if (storedHashedPin != null && hashedPin == storedHashedPin)
                                {
                                    MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    UserSession.StartSession(user.UserID, user.Username, user.phoneNum); // Start session
                                    menuControls dashboard = new menuControls(); // Pass UserSession
                                    dashboard.Show();
                                    this.Hide();
                                    ResetAttempts(); // Reset attempts on successful logins
                                }
                                else
                                {
                                    attempts++;

                                    if (attempts >= 3)
                                    {
                                        lockoutEndTime = DateTime.Now.AddMinutes(1); //lockout for 1 minute
                                        MessageBox.Show($"You have reached maximum number of attempts.\n Login will be disabled for 1 minute.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        userNameTxt.Focus();
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Invalid PIN. Attempts done: {attempts} out of 3", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        passwordTxtBox.Text = "";
                                        passwordTxtBox.Focus();
                                    }
                                }
                            }
                            else
                            {
                                attempts++;

                                if (attempts >= 3)
                                {
                                    lockoutEndTime = DateTime.Now.AddMinutes(1); //lockout for 1 minute
                                    MessageBox.Show($"You have reached maximum number of attempts.\n Login will be disabled for 1 minute.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    userNameTxt.Focus();
                                }
                                else
                                {
                                    MessageBox.Show($"Invalid Username. Attempts done: {attempts} out of 3", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    passwordTxtBox.Text = "";
                                    passwordTxtBox.Focus();
                                }
                            }
                        }
                    }
                    if (attempts >= 3)
                    {
                        loginBtn.Enabled = false; //disable login button during lockout period
                        labelLockoutTimer.Visible = true; //show lockout timer label
                        Timer timer = new Timer();
                        timer.Interval = 1000; //1 second
                        timer.Tick += Timer_Tick;
                        timer.Start();
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Something went wrong: " + ex.Message);
                    conn.Close();
                }
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
            labelLockoutTimer.Text = "";
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