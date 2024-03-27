using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace spend_smart
{
    public partial class dashboard : UserControl
    {
        private dbConn dbConnection;

        public dashboard()
        {
            InitializeComponent();
            dbConnection = dbConn.Instance;

            UpdateExpenseLabel();
            UpdateIncomeLabel();
            TotalBalance();
        }

        private void UpdateExpenseLabel()
        {
            try
            {
                if (dbConnection.TestConnection()) // Check database connection
                {
                    using (OleDbConnection connection = new OleDbConnection(dbConnection.connString))
                    {
                        connection.Open();

                        string getExpenseQuery = "SELECT SUM(amount) FROM expense";
                        using (OleDbCommand command = new OleDbCommand(getExpenseQuery, connection))
                        {
                            object expenseResult = command.ExecuteScalar(); // Retrieve the sum of amounts

                            if (expenseResult != null && expenseResult != DBNull.Value)
                            {
                                decimal sum = Convert.ToDecimal(expenseResult);
                                explbl.Text = sum.ToString(); // Set the label's text to the sum of expenses
                            }
                            else
                            {
                                explbl.Text = "0.00"; // Set label text to 0 if no expenses are found
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Database connection failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating expense label: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateIncomeLabel()
        {
            try
            {
                if (dbConnection.TestConnection())
                {
                    using (OleDbConnection connection = new OleDbConnection(dbConnection.connString))
                    {
                        connection.Open();

                        string getIncomQuery = "SELECT SUM(amount) FROM income";
                        using (OleDbCommand command = new OleDbCommand(getIncomQuery, connection))
                        {
                            object incomResult = command.ExecuteScalar();

                            if (incomResult != null && incomResult != DBNull.Value)
                            {
                                decimal sum = Convert.ToDecimal(incomResult);
                                incomelbl.Text = sum.ToString();
                            }
                            else
                            {
                                incomelbl.Text = "0.00";
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error updating income label: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TotalBalance()
        {
            try
            {
                if (dbConnection.TestConnection()) // Check database connection
                {
                    using (OleDbConnection connection = new OleDbConnection(dbConnection.connString))
                    {
                        connection.Open();

                        // Calculate total income
                        string incomeQuery = "SELECT SUM(amount) FROM income";
                        decimal totalIncome = GetTotalAmount(connection, incomeQuery);

                        // Calculate total expenses
                        string expenseQuery = "SELECT SUM(amount) FROM expense";
                        decimal totalExpenses = GetTotalAmount(connection, expenseQuery);

                        // Calculate total balance (income - expenses)
                        decimal totalBalance = totalIncome - totalExpenses;

                        // Update the balance label text
                        totBalancelbl.Text = totalBalance.ToString("C2");
                    }
                }
                else
                {
                    MessageBox.Show("Database connection failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating balance label: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetTotalAmount(OleDbConnection connection, string query)
        {
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                return (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
            }
        }

        public class Note
        {
            public string subject { get; set; }
            public string note { get; set; }
            public DateTime timeStamp { get; set; }

            public Note(string subject, string note, DateTime timeStamp)
            {
                this.subject = subject;
                this.note = note;
                this.timeStamp = timeStamp;
            }
        }

        private void addNoteBtn_Click(object sender, EventArgs e)
        {
            string subject = subjectTxtBox.Text;
            string note = msgTxtBox.Text; // Changed variable name to match class property
            DateTime timeStamp = DateTime.Now;

            // Create a Note object
            Note newNote = new Note(subject, note, timeStamp);

            // Add the note to the database
            AddNoteToDatabase(newNote);
        }

        private void AddNoteToDatabase(Note note)
        {
            try
            {
                if (subjectTxtBox.Text == "" || msgTxtBox.Text == "")
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (dbConnection.TestConnection()) // Check database connection
                    {
                        using (OleDbConnection connection = new OleDbConnection(dbConnection.connString))
                        {
                            connection.Open();

                            string query = "INSERT INTO notes (subject, [note], [timeStamp]) VALUES (@p1, @p2, @p3)";
                            using (OleDbCommand command = new OleDbCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@p1", OleDbType.VarWChar).Value = note.subject;
                                command.Parameters.AddWithValue("@p2", OleDbType.VarWChar).Value = note.note;
                                command.Parameters.AddWithValue("@p3", OleDbType.DBTimeStamp).Value = note.timeStamp;

                                command.ExecuteNonQuery();

                                MessageBox.Show("Note added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Database connection failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding note: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
