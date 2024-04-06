using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace spend_smart
{
    public partial class registerForm : Form
    {
        public Point mouseLocation;

        public registerForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(BorderRadius.CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
        }

        private void registerForm_Load(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = false;
            conNumValidationLbl.Visible = false;
            pinValidationLbl.Visible = false;
            conPinValidationLbl.Visible = false;
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

        private void loginLbl_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide();
        }

        private void regUserNameTxt_Enter(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = true;
        }

        private void regUserNameTxt_TextChanged(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = false;
        }

        private void contactNumber_Enter(object sender, EventArgs e)
        {
            conNumValidationLbl.Visible = true;
        }

        private void contactNumber_TextChanged(object sender, EventArgs e)
        {
            conNumValidationLbl.Visible = false;
        }

        private void regPasswordTxt_Enter(object sender, EventArgs e)
        {
            pinValidationLbl.Visible = true;
        }

        private void regPasswordTxt_TextChanged(object sender, EventArgs e)
        {
            pinValidationLbl.Visible = false;
        }

        private void regConPassTxt_Enter(object sender, EventArgs e)
        {
            conPinValidationLbl.Visible = true;
        }

        private void regConPassTxt_TextChanged(object sender, EventArgs e)
        {
            conPinValidationLbl.Visible = false;
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

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string connString = dbConn.Instance.connString;
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                try
                {
                    conn.Open();

                    String username = regUserNameTxt.Text;
                    String contactNum = contactNumber.Text;
                    String pin = regPasswordTxt.Text;
                    String conPin = regConPassTxt.Text;

                    string hashedPin = hashPassword(pin);

                    //check if any field is empty
                    if (regUserNameTxt.Text == "" || contactNumber.Text == "" || regPasswordTxt.Text == "" || regConPassTxt.Text == "")
                    {
                        MessageBox.Show("Please fill all credentials", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conn.Close();
                    }
                    //Check if password and confirm password match
                    else if (regConPassTxt.Text != regPasswordTxt.Text)
                    {
                        MessageBox.Show("PIN does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                    }
                    //Check if password length is at least 8 characters
                    else if (regPasswordTxt.Text.Length < 8)
                    {
                        MessageBox.Show("PIN must be at least 8 characters long", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conn.Close();
                    }
                    //Check if password contains only numbers
                    else if (!Regex.IsMatch(regPasswordTxt.Text, @"^\d+$"))
                    {
                        MessageBox.Show("PIN must contain only numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                    }
                    //Check if contact number is 11 digits long
                    else if (contactNumber.Text.Length != 11)
                    {
                        MessageBox.Show("Contact number must be 11 digits long", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conn.Close();
                    }
                    //Check if contact number contains only numbers
                    else if (!Regex.IsMatch(contactNumber.Text, @"^\d+$"))
                    {
                        MessageBox.Show("Contact number must contain only numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                    }
                    else
                    {
                        // Check if username already exists
                        string queryCheckUsername = "SELECT COUNT(*) FROM users WHERE username = @username";
                        using (OleDbCommand cmdCheckUsername = new OleDbCommand(queryCheckUsername, conn))
                        {
                            cmdCheckUsername.Parameters.AddWithValue("@username", username);
                            int count = (int)cmdCheckUsername.ExecuteScalar();
                            if (count > 0)
                            {
                                MessageBox.Show("Username already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                regUserNameTxt.Text = "";
                                contactNumber.Text = "";
                                regPasswordTxt.Text = "";
                                regConPassTxt.Text = "";
                                regUserNameTxt.Focus();
                                conn.Close();
                                
                                return; // Exit registration process
                            }
                        }
                        //If username doesn't exist, proceed with registration
                        string query = "INSERT INTO users (username, phone, pin) VALUES (@username, @contactNum, @pin)";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@contactNum", contactNum);
                        cmd.Parameters.AddWithValue("@pin", hashedPin);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Successfully registered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        conn.Close();

                        loginForm loginForm = new loginForm();
                        loginForm.Show();
                        this.Hide();
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Something went wrong: " + ex.Message);
                    conn.Close();
                }
                
            }
        }
    }
}
