using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace spend_smart
{
    public partial class analytics : UserControl
    {
        private OleDbConnection dbConnection;
        private int currentID;
        private string currentName;
        private bool isChartPopulated = false;

        private LiveCharts.WinForms.PieChart pieChart;

        public analytics()
        {
            InitializeComponent();
            InitializeChart();
            InitializeDBConnection();

            this.Load += analytics_Load;
        }

        private void analytics_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();

            // Access UserID and Username from UserSession
            currentID = UserSession.CurrentUserID;
            currentName = UserSession.CurrentUsername;

            if (!isChartPopulated)
            {
                PopulateChart();
                PopulatePieChart();
                isChartPopulated = true;
            }
        }

        private void InitializeChart()
        {
            // Initialize the cartesian chart
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            });
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Incomes",
                LabelFormatter = value => value.ToString("C")
            });
            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;

            // Initialize the pie chart
            pieChart = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill
            };
            guna2Panel7.Controls.Add(pieChart);
        }

        private void InitializeDBConnection()
        {
            try
            {
                dbConnection = new OleDbConnection(dbConn.Instance.connString);
                dbConnection.Open(); // Open the database connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }

        private void PopulateChart()
        {
            cartesianChart1.Series.Clear();
            LineSeries series = new LineSeries()
            {
                Title = "Flow Line",
                Values = new ChartValues<double>()
            };

            try
            {
                if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                {
                    MessageBox.Show("Database connection is not open.");
                    return;
                }

                // Modify the query to include the current user's ID
                string query = $"SELECT added_year, added_month, amount FROM income WHERE user_id = {currentID} ORDER BY added_year, added_month";
                OleDbCommand command = new OleDbCommand(query, dbConnection);
                OleDbDataReader reader = command.ExecuteReader();

                List<string> monthLabels = new List<string>(); // List to store month labels

                while (reader.Read())
                {
                    double value = Convert.ToDouble(reader["amount"]);
                    series.Values.Add(value);

                    // Get the month and year from the database
                    int month = Convert.ToInt32(reader["added_month"]);
                    int year = Convert.ToInt32(reader["added_year"]);

                    // Create a formatted label for the x-axis
                    string label = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}";
                    monthLabels.Add(label); // Add the label to the list
                }

                cartesianChart1.Series.Add(series);

                // Set the x-axis labels based on the list of month labels
                cartesianChart1.AxisX[0].Labels = monthLabels.ToArray();

                // Debug output for checking series data
                Debug.WriteLine("Series Values: " + string.Join(", ", series.Values));
                Debug.WriteLine("X-Axis Labels: " + string.Join(", ", cartesianChart1.AxisX[0].Labels));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data from the database: " + ex.Message);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            PopulateChart();
            PopulatePieChart(); // Call PopulatePieChart when the update button is clicked
        }

        private void PopulatePieChart()
        {
            try
            {
                if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                {
                    MessageBox.Show("Database connection is not open.");
                    return;
                }

                pieChart.Series = new SeriesCollection(); // Initialize the series collection

                // Modify the query to retrieve expenses grouped by category and sum the amounts, joining with expenseCategory table to get category IDs
                string query = $"SELECT category_id, SUM(amount) AS total_amount " +
                               $"FROM expense " +
                               $"WHERE user_id = {currentID} " +
                               $"GROUP BY category_id";

                OleDbCommand command = new OleDbCommand(query, dbConnection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    double totalAmount = Convert.ToDouble(reader["total_amount"]);

                    // Use switch case to map category IDs to category names
                    string categoryName = GetCategoryName(categoryId);

                    pieChart.Series.Add(new PieSeries
                    {
                        Title = categoryName,
                        Values = new ChartValues<double> { totalAmount },
                        DataLabels = true // Show data labels on the pie chart
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving expense data: " + ex.Message);
                Debug.WriteLine("Error in PopulatePieChart: " + ex.ToString());
            }
        }

        private string GetCategoryName(int categoryId)
        {
            switch (categoryId)
            {
                case 1:
                    return "Foods";
                case 2:
                    return "Healthcare";
                case 3:
                    return "Entertainment";
                case 4:
                    return "Others";
                default:
                    return "Unknown";
            }
        }
    }
}
