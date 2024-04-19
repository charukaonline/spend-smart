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
    }
}
