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
using System.Data.Common;
using System.Text.RegularExpressions;

namespace spend_smart
{
    public partial class addTransactions : UserControl
    {
        private OleDbConnection dbConnection;
        private int currentID;
        private string currentName;

        public addTransactions()
        {
            InitializeComponent();

            ThemeManage.AddControlToColor(guna2Panel3);
            ThemeManage.AddControlToColor(guna2Panel4);
            ThemeManage.AddControlToColor(label1);
            ThemeManage.AddControlToColor(label4);
            ThemeManage.AddControlToColor(btnIncomeSubmit);
            ThemeManage.AddControlToColor(btnExpenseSubmit);

            this.Load += addTransactions_Load;
        }

        private void addTransactions_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();
            InitializeDBConnection();

            //access UserID and Username from UserSession
            currentID = UserSession.CurrentUserID;
            currentName = UserSession.CurrentUsername;
        }

        private void InitializeDBConnection()
        {
            try
            {
                if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                {
                    dbConnection = new OleDbConnection(dbConn.Instance.connString);
                    dbConnection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }

        private void btnIncomeSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string IncomeSrc = txtIncomeSrc.Text;
                string IncomeAmt = txtIncomeAmount.Text;

                if (IncomeSrc == "" || IncomeAmt == "")
                {
                    MessageBox.Show("Please fill in all fields.");
                }

                else if (!Regex.IsMatch(IncomeAmt, @"^\d+(\.\d+)?$"))
                {
                    MessageBox.Show("Please enter a valid amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    // Ensure the database connection is open
                    if (dbConnection.State != ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }

                    // Use parameterized query to prevent SQL injection
                    string query = "INSERT INTO income (user_id, source, amount, added_date) VALUES (@currentID, @IncomeSource, @IncomeAmount, @AddedDate)";
                    OleDbCommand cmd = new OleDbCommand(query, dbConnection);

                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@currentID", currentID);
                    cmd.Parameters.Add("@IncomeSource", OleDbType.VarChar).Value = IncomeSrc;
                    cmd.Parameters.AddWithValue("@IncomeAmount", decimal.Parse(IncomeAmt)); // Convert string to decimal
                    cmd.Parameters.Add("@AddedDate", OleDbType.Date).Value = DateTime.Now; // Add current date

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the query was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Income added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIncomeSrc.Text = "";
                        txtIncomeAmount.Text = "";
                        dbConnection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add income", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dbConnection.Close();
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error adding income: " + ex.Message);
                dbConnection.Close();
            }
        }

        private void btnExpenseSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId = GetCategoryId(expenseCategories.SelectedItem.ToString()); // Get category ID based on selected category name
                string expenseTitle = txtExpenseTitle.Text;
                string expenseAmount = txtExpenseAmount.Text;

                // Validate fields
                if (string.IsNullOrEmpty(expenseTitle) || string.IsNullOrEmpty(expenseAmount))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                else if (!Regex.IsMatch(expenseAmount, @"^\d+(\.\d+)?$"))
                {
                    MessageBox.Show("Please enter a valid amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {
                    if (dbConnection.State != ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }

                    // Insert expense into database
                    string query = "INSERT INTO expense (user_id, category_id, title, amount, added_date) VALUES (@currentID, @CategoryId, @ExpenseTitle, @ExpenseAmount, @AddedDate)";
                    OleDbCommand cmd = new OleDbCommand(query, dbConnection);
                    cmd.Parameters.AddWithValue("@currentID", currentID);
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.Add("@ExpenseTitle", OleDbType.VarChar).Value = expenseTitle;
                    cmd.Parameters.AddWithValue("@ExpenseAmount", decimal.Parse(expenseAmount)); // Convert string to decimal
                    cmd.Parameters.Add("@AddedDate", OleDbType.Date).Value = DateTime.Now;

                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the query was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Expense added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtExpenseTitle.Text = "";
                        txtExpenseAmount.Text = "";
                        expenseCategories.SelectedIndex = 0; // Reset category selection
                        dbConnection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the expense", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dbConnection.Close();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding expense: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetCategoryId(string categoryName)
        {
            int categoryId = -1; // Default to -1 if not found

            // Mapping category name to category ID
            switch (categoryName)
            {
                case "Foods":
                    categoryId = 1;
                    break;
                case "Healthcare":
                    categoryId = 2;
                    break;
                case "Entertainment":
                    categoryId = 3;
                    break;
                case "Others":
                    categoryId = 4;
                    break;
            }

            return categoryId;
        }
    }
}
