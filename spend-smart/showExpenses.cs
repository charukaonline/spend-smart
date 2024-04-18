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
    public partial class showExpenses : UserControl
    {
        private OleDbConnection dbConnection;
        private int currentID;
        private string currentName;
        public showExpenses()
        {
            InitializeComponent();
            SubscribeToAddExpenseEvent();
        }

        public void SubscribeToAddExpenseEvent()
        {
            addTransactions addTransactions = new addTransactions();
            addTransactions.ExpenseAdded += OnExpenseAdded;
        }

        private void OnExpenseAdded(object sender, EventArgs e)
        {
            // Refresh the DataGridView
            FetchExpenseRecords();
        }

        private void showExpenses_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();
            InitializeDBConnection();
            FetchExpenseRecords();


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
            catch (OleDbException ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }

        public void RefreshData()
        {
            FetchExpenseRecords();
        }

        private void FetchExpenseRecords()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT expense_id AS [Expense ID], title AS [Title], amount AS [Amount ($)], added_date AS [Added Date] FROM expense WHERE user_id = @currentID";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@currentID", UserSession.CurrentUserID);

                try
                {
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    da.Fill(dt);

                    expenseDataGrid.DataSource = dt; // Assign data source to DataGridView
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Error fetching expense data: " + ex.Message);
                }
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

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int expenseId;
            if (!int.TryParse(expenseIdTxt.Text, out expenseId))
            {
                MessageBox.Show("Please enter a valid Expense ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int categoryId = GetCategoryId(expenseCategoriesCombo.Text);
            if (categoryId == -1)
            {
                MessageBox.Show("Please select a valid category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string title = expenseTitleTxt.Text;
            if (title == "")
            {
                MessageBox.Show("Please enter a title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal amount;
            if (!decimal.TryParse(expenseAmountTxt.Text, out amount))
            {
                MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(dbConn.Instance.connString))
                {
                    conn.Open();

                    string query = "UPDATE expense SET category_id = @categoryId, title = @title, amount = @amount WHERE expense_id = @expenseId AND user_id = @currentID";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@categoryId", categoryId);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@expenseId", expenseId);
                        cmd.Parameters.AddWithValue("@currentID", UserSession.CurrentUserID);

                        int rowsUpdated = cmd.ExecuteNonQuery();
                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("Expense updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FetchExpenseRecords();  // Refresh the DataGridView
                            expenseIdTxt.Text = "";
                            expenseCategoriesCombo.SelectedIndex = 0;
                            expenseTitleTxt.Text = "";
                            expenseAmountTxt.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("No records updated.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error updating expense: " + ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            int expenseId;
            if (!int.TryParse(expenseIdTxt.Text, out expenseId))
            {
                MessageBox.Show("Please enter a valid Expense ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(dbConn.Instance.connString))
                {
                    conn.Open();

                    string query = "DELETE FROM expense WHERE expense_id = @expenseId AND user_id = @currentID";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@expenseId", expenseId);
                        cmd.Parameters.AddWithValue("@currentID", UserSession.CurrentUserID);

                        int rowsDeleted = cmd.ExecuteNonQuery();
                        if (rowsDeleted > 0)
                        {
                            MessageBox.Show("Expense deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FetchExpenseRecords();  // Refresh the DataGridView
                            expenseIdTxt.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("No records deleted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error deleting expense: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
