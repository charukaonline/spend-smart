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

            //ThemeManage.AddControlToColor(guna2Panel2);
            //ThemeManage.AddControlToColor(label1);
            //ThemeManage.AddControlToColor(label2);
            //ThemeManage.AddControlToColor(label3);
            //ThemeManage.AddControlToColor(label4);
            //ThemeManage.AddControlToColor(label6);
            //ThemeManage.AddControlToColor(label8);
            //ThemeManage.AddControlToColor(label9);
            //ThemeManage.AddControlToColor(label10);
            //ThemeManage.AddControlToColor(label12);
            //ThemeManage.AddControlToColor(label13);
            //ThemeManage.AddControlToColor(label14);
            //ThemeManage.AddControlToColor(label16);
            //ThemeManage.AddControlToColor(label17);
            //ThemeManage.AddControlToColor(label18);
            //ThemeManage.AddControlToColor(label20);
            //ThemeManage.AddControlToColor(label21);

            //this.Load += showExpenses_Load;
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
            catch (Exception ex)
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching expense data: " + ex.Message);
                }
            }
        }

    }
}
