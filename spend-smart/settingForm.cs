using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace spend_smart
{
    public partial class settingForm : UserControl
    {
        private OleDbConnection dbconnection;
        private int currentID;
        private string currentName;

        public settingForm()
        {
            InitializeComponent();

            ThemeManage.AddControlToColor(guna2Panel1);
            ThemeManage.AddControlToColor(label1);
            ThemeManage.AddControlToColor(label2);
            ThemeManage.AddControlToColor(label3);
            ThemeManage.AddControlToColor(label4);

            this.Load += settingForm_load;
        }

        private void settingForm_load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();
            InitializeDBConnection();

            currentID = UserSession.CurrentUserID;
            currentName = UserSession.CurrentUsername;
        }

        private void InitializeDBConnection()
        {
            try
            {
                if (dbconnection == null || dbconnection.State != ConnectionState.Open)
                {
                    dbconnection = new OleDbConnection(dbConn.Instance.connString);
                    dbconnection.Open();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            string currentPin = txtCurrentPin.Text;
            string newPin = txtNewPin.Text;
            string confirmNewPin = txtCNewPin.Text;

            if (string.IsNullOrWhiteSpace(currentPin) || string.IsNullOrWhiteSpace(newPin) || string.IsNullOrWhiteSpace(confirmNewPin))
            {
                MessageBox.Show("Please fill in all fields","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (newPin.Length<8 || !Regex.IsMatch(newPin, @"^\d+$"))
            {
                MessageBox.Show("New PIN must be at least 8 characters long and should contain only numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (newPin != confirmNewPin)
            {
                MessageBox.Show("New PIN and Confirm New PIN do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure, You want to update your PIN?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result==DialogResult.OK)
                {
                    string query = "SELECT pin FROM users WHERE user_id = @currentID";
                    using (OleDbCommand cmd = new OleDbCommand(query,dbconnection))
                    {
                        cmd.Parameters.AddWithValue("@currentID",currentID);
                        try
                        {
                            string storedPin = cmd.ExecuteScalar()?.ToString();

                            if (storedPin != null && storedPin ==hashPassword(currentPin))
                            {
                                string updateQuery = "UPDATE users SET pin = @newPin WHERE user_id = @currentID";
                                using (OleDbCommand updateCmd = new OleDbCommand(updateQuery,dbconnection))
                                {
                                    updateCmd.Parameters.AddWithValue("@newPin", hashPassword(newPin));
                                    updateCmd.Parameters.AddWithValue("@currentID", currentID);

                                    int rowsAffected = updateCmd.ExecuteNonQuery();

                                    if (rowsAffected>0)
                                    {
                                        MessageBox.Show("PIN updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtCurrentPin.Text = "";
                                        txtNewPin.Text = "";
                                        txtCNewPin.Text = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update PIN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Current PIN is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Error updating PIN: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    txtCurrentPin.Text = "";
                    txtNewPin.Text = "";
                    txtCNewPin.Text = "";
                }
            }
        }

        private string hashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-","").ToLower();
            }
        }

        private void changeTheme_Click(object sender, EventArgs e)
        {
            ThemeManage.ToggleTheme();
            ThemeManage.ApplyTheme();
        }
    }
}
