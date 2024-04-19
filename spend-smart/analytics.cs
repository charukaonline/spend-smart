using LiveCharts.Wpf;
using LiveCharts;
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
using System.Diagnostics;
using System.Globalization;

namespace spend_smart
{
    public partial class analytics : UserControl
    {
        private OleDbConnection dbConnection;
        private int currentID;
        private string currentName;
        private bool isChartPopulated = false; // Flag to track if the chart has been populated

        public analytics()
        {
            InitializeComponent();
            InitializeDBConnection();

            ThemeManage.AddControlToColor(guna2Panel3);
            ThemeManage.AddControlToColor(guna2Panel4);
            ThemeManage.AddControlToColor(label1);
            ThemeManage.AddControlToColor(label3);

            InitializeChart(); // Call InitializeChart in the constructor
            this.Load += analytics_Load;
        }

        private void analytics_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();

            // Access UserID and Username from UserSession
            currentID = UserSession.CurrentUserID;
            currentName = UserSession.CurrentUsername;

            if (!isChartPopulated) // Check if the chart has not been populated yet
            {
                PopulateChart();
                isChartPopulated = true; // Set the flag to true after populating the chart
            }
        }

        public void RefreshData()
        {
            PopulateChart();
        }

        private void InitializeChart()
        {
            if (dbConnection == null || dbConnection.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Database connection is not open.");
                return;
            }

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


    }
}