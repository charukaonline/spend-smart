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
    public partial class settingForm : UserControl
    {

        private bool isDarkTheme = false;

        public settingForm()
        {
            InitializeComponent();
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            if (txtCurrentPin.Text == "" ||  txtCurrentPin.Text == "" || txtCNewPin.Text == "")
            {
                MessageBox.Show("All fields are required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure, You want to reset your pin", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    // Call method to reset PIN
                    ResetPin();
                }
                else if (result == DialogResult.Cancel)
                {
                    txtCurrentPin.Text = "";
                    txtNewPin.Text = "";
                    txtCNewPin.Text = "";
                }
            }
        }

        private void ResetPin()
        {
            MessageBox.Show("PIN reset successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void changeTheme_Click(object sender, EventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            if (!isDarkTheme)
            {
                // Setting Form Color
                guna2Panel1.FillColor = Color.FromArgb(255, 18, 18, 18);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
            }
            else
            {
                // Setting Form Color
                guna2Panel1.FillColor = Color.White;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
            }
        }
    }
}
