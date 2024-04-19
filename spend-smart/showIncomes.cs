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

namespace spend_smart
{
    public partial class showIncomes : UserControl
    {
        private OleDbConnection dbConnection;
        private int currentID;

        public showIncomes()
        {
            InitializeComponent();
            SubscribeToAddIncomeEvent();

            ThemeManage.AddControlToColor(guna2Panel2);
            ThemeManage.AddControlToColor(label1);
            ThemeManage.AddControlToColor(label2);
        }

        public void SubscribeToAddIncomeEvent()
        {
            addTransactions addTransactions = new addTransactions();
            addTransactions.IncomeAdded += OnIncomeAdded;
        }

        private void OnIncomeAdded(object sender, EventArgs e)
        {
            // Refresh the DataGridView
            FetchIncomeRecords();
        }

        private void showIncomes_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();
            InitializeDBConnection();
            FetchIncomeRecords();

            currentID = UserSession.CurrentUserID;
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
                MessageBox.Show("Error connecting to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshData()
        {
            FetchIncomeRecords();
        }

        private void FetchIncomeRecords()
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Database connection is not set.");
                return;
            }

            string query = "SELECT income_id AS [Income ID], source AS [Source], amount AS [Amount ($)], added_date AS [Added Date] FROM income WHERE user_id = @currentID";
            using (OleDbCommand command = new OleDbCommand(query, dbConnection))
            {
                command.Parameters.AddWithValue("@currentID", currentID);

                try
                {
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    da.Fill(dt);

                    IncomeDataGrid.DataSource = dt; // Assign data source to DataGridView
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Error fetching expense data: " + ex.Message);
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int incomeId;
            if (!int.TryParse(incomeIdTxt.Text, out incomeId))
            {
                MessageBox.Show("Please enter a valid income ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string incomeSrc = incomeSrcTxt.Text;
            if (incomeSrc == "")
            {
                MessageBox.Show("Please enter a source for the income.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal amount;
            if (!decimal.TryParse(incomeAmountTxt.Text, out amount))
            {
                MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "UPDATE income SET source = @IncomeSource, amount = @IncomeAmount WHERE income_id = @IncomeID AND user_id = @currentID";
                using (OleDbCommand command = new OleDbCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("@IncomeSource", incomeSrc);
                    command.Parameters.AddWithValue("@IncomeAmount", amount);
                    command.Parameters.AddWithValue("@IncomeID", incomeId);
                    command.Parameters.AddWithValue("@currentID", currentID);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Income updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FetchIncomeRecords();
                        incomeIdTxt.Text = "";
                        incomeSrcTxt.Text = "";
                        incomeAmountTxt.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No records updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error updating income: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            int incomeId;
            if (!int.TryParse(incomeIdTxt.Text, out incomeId))
            {
                MessageBox.Show("Please enter a valid Income ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "DELETE FROM income WHERE income_id = @IncomeID AND user_id = @currentID";
                using (OleDbCommand command = new OleDbCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("@IncomeID", incomeId);
                    command.Parameters.AddWithValue("@currentID", currentID);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Income deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FetchIncomeRecords();
                        incomeIdTxt.Text = "";
                        incomeSrcTxt.Text = "";
                        incomeAmountTxt.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No records deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error deleting income: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
