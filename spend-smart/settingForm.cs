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
using System.IO;

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
            ThemeManage.AddControlToColor(label5);

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

        private void btnDelData_Click(object sender, EventArgs e)
        {
            string enteredPin = hashPassword(txtPin.Text);

            if (txtPin.Text == "")
            {
                MessageBox.Show("Please enter your PIN.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verify PIN
            if (!VerifyPin(enteredPin))
            {
                MessageBox.Show("Incorrect PIN. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPin.Text = "";
                txtPin.Focus();
                return;
            }

            // Confirmation message
            DialogResult result = MessageBox.Show("Are you sure you want to delete all your data? This action cannot be undone.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(dbConn.Instance.connString))
                    {
                        conn.Open();

                        // Delete income data
                        string deleteIncomeQuery = "DELETE FROM income WHERE user_id = @currentID";
                        using (OleDbCommand cmd = new OleDbCommand(deleteIncomeQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@currentID", UserSession.CurrentUserID);
                            cmd.ExecuteNonQuery();
                        }

                        // Delete expense data
                        string deleteExpenseQuery = "DELETE FROM expense WHERE user_id = @currentID";
                        using (OleDbCommand cmd = new OleDbCommand(deleteExpenseQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@currentID", UserSession.CurrentUserID);
                            cmd.ExecuteNonQuery();
                        }

                        // Delete notes data
                        string deleteNotesQuery = "DELETE FROM notes WHERE user_id = @currentID";
                        using (OleDbCommand cmd = new OleDbCommand(deleteNotesQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@currentID", UserSession.CurrentUserID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("All your data has been deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPin.Text = "";
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Error deleting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool VerifyPin(string enteredPin)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(dbConn.Instance.connString))
                {
                    conn.Open();

                    string query = "SELECT pin FROM users WHERE user_id = @currentID";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@currentID", UserSession.CurrentUserID);
                        string storedPin = cmd.ExecuteScalar()?.ToString();

                        if (storedPin == enteredPin)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error verifying PIN: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private void ExportIncomeData(DataTable incomeTable, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write CSV header (column names)
                    writer.WriteLine(string.Join(",", incomeTable.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));

                    // Write CSV data rows
                    foreach (DataRow row in incomeTable.Rows)
                    {
                        writer.WriteLine(string.Join(",", row.ItemArray.Select(field => field.ToString())));
                    }
                }

                MessageBox.Show("Income data exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting income data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportExpenseData(DataTable expenseTable, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write CSV header (column names)
                    writer.WriteLine(string.Join(",", expenseTable.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));

                    // Write CSV data rows
                    foreach (DataRow row in expenseTable.Rows)
                    {
                        writer.WriteLine(string.Join(",", row.ItemArray.Select(field => field.ToString())));
                    }
                }

                MessageBox.Show("Expense data exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting expense data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetIncomeData()
        {
            DataTable dataTable = new DataTable();

            // Adjust the query to filter by user_id
            string query = "SELECT * FROM income WHERE user_id = @currentID";

            using (OleDbConnection connection = new OleDbConnection(dbConn.Instance.connString))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    try
                    {
                        // Add parameter for user_id
                        adapter.SelectCommand.Parameters.AddWithValue("@currentID", UserSession.CurrentUserID);

                        connection.Open();
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving income data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dataTable;
        }

        private DataTable GetExpenseData()
        {
            DataTable dataTable = new DataTable();

            // Adjust the query to filter by user_id
            string query = "SELECT * FROM expense WHERE user_id = @currentID";

            using (OleDbConnection connection = new OleDbConnection(dbConn.Instance.connString))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    try
                    {
                        // Add parameter for user_id
                        adapter.SelectCommand.Parameters.AddWithValue("@currentID", UserSession.CurrentUserID);

                        connection.Open();
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving expense data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dataTable;
        }

        private void exportFile_Click(object sender, EventArgs e)
        {
            DataTable incomeTable = GetIncomeData();
            DataTable expenseTable = GetExpenseData();

            if (incomeTable.Rows.Count > 0 && expenseTable.Rows.Count > 0)
            {
                SaveFileDialog saveIncomeFileDialog = new SaveFileDialog();
                saveIncomeFileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
                saveIncomeFileDialog.Title = "Save Exported Income Data";

                if (saveIncomeFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string incomeFilePath = saveIncomeFileDialog.FileName;
                    ExportIncomeData(incomeTable, incomeFilePath);
                }

                SaveFileDialog saveExpenseFileDialog = new SaveFileDialog();
                saveExpenseFileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
                saveExpenseFileDialog.Title = "Save Exported Expense Data";

                if (saveExpenseFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string expenseFilePath = saveExpenseFileDialog.FileName;
                    ExportExpenseData(expenseTable, expenseFilePath);
                }
            }
            else
            {
                MessageBox.Show("No data available to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
