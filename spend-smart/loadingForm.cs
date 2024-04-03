using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spend_smart
{
    public partial class loadingForm : Form
    {
        public loadingForm()
        {
            InitializeComponent();
        }

        private async void loadingForm_Load(object sender, EventArgs e)
        {
            await StartLoadingAsync();

            loginForm login = new loginForm();
            login.Show();
            this.Hide();
        }

        private async Task StartLoadingAsync()
        {
   
            bool isDatabaseConnected = await CheckDatabaseConnectionAsync();

            for (int i = 0; i <= 100; i += 10)
            {
                await Task.Delay(200);

                progressBar1.Value = i;
            }

            progressBar1.Visible = false;

            if (isDatabaseConnected)
            {
                Console.WriteLine("Database connection successful.");
            }
            else
            {
                Console.WriteLine("Database connection failed.");
            }
        }

        private async Task<bool> CheckDatabaseConnectionAsync()
        {
            
            string connectionString = "YourConnectionStringHere";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    return true; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection error: " + ex.Message);
                return false;
            }
        }
    }
}
