using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spend_smart
{
    public partial class dashboard : UserControl
    {
        private OleDbConnection dbConnection;
        private int currentID;
        private string currentName;
        

        public dashboard()
        {
            InitializeComponent();

            ThemeManage.AddControlToColor(guna2Panel7);
            ThemeManage.AddControlToColor(guna2Panel8);
            ThemeManage.AddControlToColor(guna2Panel9);
            ThemeManage.AddControlToColor(guna2Panel11);
            ThemeManage.AddControlToColor(label1);
            ThemeManage.AddControlToColor(label2);
            ThemeManage.AddControlToColor(label4);
            ThemeManage.AddControlToColor(label6);
            ThemeManage.AddControlToColor(totBalancelbl);
            ThemeManage.AddControlToColor(incomelbl);
            ThemeManage.AddControlToColor(explbl);
            ThemeManage.AddControlToColor(lastIncomelbl);

            ThemeManage.AddControlToColor(guna2Panel14);
            ThemeManage.AddControlToColor(guna2Panel15);
            ThemeManage.AddControlToColor(label3);
            ThemeManage.AddControlToColor(label5);

            ThemeManage.AddControlToColor(guna2Panel18);
            ThemeManage.AddControlToColor(guna2Panel19);
            ThemeManage.AddControlToColor(label7);
            ThemeManage.AddControlToColor(label8);
            ThemeManage.AddControlToColor(healthcareLbl);
            ThemeManage.AddControlToColor(label10);
            ThemeManage.AddControlToColor(label11);
            ThemeManage.AddControlToColor(label12);
            ThemeManage.AddControlToColor(label13);
            ThemeManage.AddControlToColor(foodsLbl);
            ThemeManage.AddControlToColor(entertainmentLbl);
            ThemeManage.AddControlToColor(othersLbl);

            this.Load += dashboard_Load;
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();

            InitializeDBConnection();

            //access UserID and Username from UserSession
            currentID = UserSession.CurrentUserID;
            currentName = UserSession.CurrentUsername;
        }

        public void RefreshData()
        {
            FetchUserIncomes();
            FetchUserExpenses();
            FetchTotalBalance();
            FetchLastIncome();

            FetchHealthExpenses();
            FetchFoodsExpenses();
            FetchEntertainmentExpenses();
            FetchOthersExpenses();
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

        private void FetchUserIncomes()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT SUM(amount) AS TotalIncome FROM income WHERE user_id = @currentID";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        decimal totalIncome = Convert.ToDecimal(result);
                        incomelbl.Text = totalIncome.ToString("C"); // Display as currency
                    }
                    else
                    {
                        incomelbl.Text = "$0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching income data: " + ex.Message);
                }
            }
        }

        private void FetchUserExpenses()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT SUM(amount) AS TotalExpense FROM expense WHERE user_id = @currentID";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        decimal totalExpense = Convert.ToDecimal(result);
                        explbl.Text = totalExpense.ToString("C"); // Display as currency
                    }
                    else
                    {
                        explbl.Text = "$0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching expense data: " + ex.Message);
                }
            }
        }

        private void FetchTotalBalance()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string incomeQuery = "SELECT SUM(amount) FROM income WHERE user_id = @currentID";
            string expenseQuery = "SELECT SUM(amount) FROM expense WHERE user_id = @currentID";

            decimal totalIncome = 0;
            decimal totalExpense = 0;

            // Fetch total income
            using (OleDbCommand incomeCommand = new OleDbCommand(incomeQuery, dbConnection))
            {
                incomeCommand.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    object incomeResult = incomeCommand.ExecuteScalar();
                    if (incomeResult != null && incomeResult != DBNull.Value)
                    {
                        totalIncome = Convert.ToDecimal(incomeResult);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching income data: " + ex.Message);
                }
            }

            // Fetch total expense
            using (OleDbCommand expenseCommand = new OleDbCommand(expenseQuery, dbConnection))
            {
                expenseCommand.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    object expenseResult = expenseCommand.ExecuteScalar();
                    if (expenseResult != null && expenseResult != DBNull.Value)
                    {
                        totalExpense = Convert.ToDecimal(expenseResult);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching expense data: " + ex.Message);
                }
            }

            // Calculate total balance
            decimal totalBalance = totalIncome - totalExpense;
            totBalancelbl.Text = totalBalance.ToString("C");
        }

        private void FetchLastIncome()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT TOP 1 amount FROM income WHERE user_id = @currentID ORDER BY added_date DESC";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        decimal lastIncome = Convert.ToDecimal(result);
                        lastIncomelbl.Text = lastIncome.ToString("C");
                    }
                    else
                    {
                        lastIncomelbl.Text = "$0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching last income data: " + ex.Message);
                }
            }
        }

        private void FetchHealthExpenses()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT SUM(amount) AS TotalHealthExpenses FROM expense WHERE user_id = @currentID AND category_id = 2";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    object healthExpensesResult = command.ExecuteScalar();
                    if (healthExpensesResult != null && healthExpensesResult != DBNull.Value)
                    {
                        decimal healthExpenses = Convert.ToDecimal(healthExpensesResult);
                        healthcareLbl.Text = healthExpenses.ToString("C");
                    }
                    else
                    {
                        healthcareLbl.Text = "$0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
            }
        }

        private void FetchFoodsExpenses()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT SUM(amount) AS TotalFoodExpense FROM expense WHERE user_id = @currentID AND category_id = 1";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    object foodExpenseResult = command.ExecuteScalar();
                    if (foodExpenseResult != null && foodExpenseResult != DBNull.Value)
                    {
                        decimal foodsExpenses = Convert.ToDecimal(foodExpenseResult);
                        foodsLbl.Text = foodsExpenses.ToString("C");
                    }
                    else
                    {
                        foodsLbl.Text = "$0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
            }
        }

        private void FetchEntertainmentExpenses()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT SUM(amount) AS TotalFoodExpense FROM expense WHERE user_id = @currentID AND category_id = 3";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    object entExpensesResult = command.ExecuteScalar();
                    if (entExpensesResult != null && entExpensesResult != DBNull.Value)
                    {
                        decimal entExpenses = Convert.ToDecimal(entExpensesResult);
                        entertainmentLbl.Text = entExpenses.ToString("C");
                    }
                    else
                    {
                        entertainmentLbl.Text = "$0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
            }
        }

        private void FetchOthersExpenses()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT SUM(amount) AS TotalFoodExpense FROM expense WHERE user_id = @currentID AND category_id = 4";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    object otherExpensesResult = command.ExecuteScalar();
                    if (otherExpensesResult != null && otherExpensesResult != DBNull.Value)
                    {
                        decimal otherExpenses = Convert.ToDecimal(otherExpensesResult);
                        othersLbl.Text = otherExpenses.ToString("C");
                    }
                    else
                    {
                        othersLbl.Text = "$0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
            }
        }

        private void addNoteBtn_Click(object sender, EventArgs e)
        {
            if (msgTxtBox.Text == "" || subjectTxtBox.Text == "")
            {
                MessageBox.Show("All Fields are required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string insertNoteQuery = "INSERT INTO notes (user_id, user_subject, user_note, created_on) VALUES (?, ?, ?, ?)";
            using (OleDbCommand insertCommand = new OleDbCommand(insertNoteQuery, dbConnection))
            {
                insertCommand.Parameters.AddWithValue("@currentID", currentID);
                insertCommand.Parameters.Add("@Subject", OleDbType.VarChar).Value = subjectTxtBox.Text;
                insertCommand.Parameters.Add("@Note", OleDbType.VarChar).Value = msgTxtBox.Text;
                insertCommand.Parameters.Add("@CreatedOn", OleDbType.Date).Value = DateTime.Now;

                try
                {
                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Note Added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        msgTxtBox.Text = "";
                        subjectTxtBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Failed to add note. No rows affected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding note: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
