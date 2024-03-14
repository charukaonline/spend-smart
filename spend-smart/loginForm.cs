using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spend_smart
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = false;
            pinValidationLbl.Visible = false;
        }

        

        private void loginBtn_Click(object sender, EventArgs e)
        {
            menuControls dashboard = new menuControls();
            dashboard.Show();
            this.Hide();
        }

        private void userNameTxt_Enter(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = true;
        }

        private void userNameTxt_TextChange(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = false;
        }

        private void passwordTxtBox_Enter(object sender, EventArgs e)
        {
            pinValidationLbl.Visible = true;
        }

        private void passwordTxtBox_TextChanged(object sender, EventArgs e)
        {
            pinValidationLbl.Visible = false;
        }
    }
}
