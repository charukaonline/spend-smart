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
                else
                {
                    // Ensure the database connection is open
                    if (dbConnection.State != ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }

                    // Use parameterized query to prevent SQL injection
                    string query = "INSERT INTO income (user_id, source, amount) VALUES (@currentID, @IncomeSource, @IncomeAmount)";
                    OleDbCommand cmd = new OleDbCommand(query, dbConnection);

                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@currentID", currentID);
                    cmd.Parameters.AddWithValue("@IncomeSource", IncomeSrc);
                    cmd.Parameters.AddWithValue("@IncomeAmount", decimal.Parse(IncomeAmt)); // Convert string to decimal

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
    }
}
