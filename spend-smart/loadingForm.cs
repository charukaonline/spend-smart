using Guna.UI2.WinForms;
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

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(BorderRadius.CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
        }

        private async void loadingForm_Load(object sender, EventArgs e)
        {
            await StartLoadingAsync();
        }

        private async Task StartLoadingAsync()
        {

            bool isDatabaseConnected = await Task.Run(() => dbConn.Instance.TestConnection());

            for (int i = 0; i <= 100; i += 10)
            {
                await Task.Delay(200);
                progressBar1.Value = i;
            }

            progressBar1.Visible = false;

            //loginForm login = new loginForm();
            //login.Show();

            menuControls dash = new menuControls();
            dash.Show();
            this.Hide();
        }
    }
}
