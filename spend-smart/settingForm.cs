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

        public settingForm()
        {
            InitializeComponent();

            ThemeManage.AddControlToColor(guna2Panel1);
            ThemeManage.AddControlToColor(label1);
            ThemeManage.AddControlToColor(label2);
            ThemeManage.AddControlToColor(label3);
            ThemeManage.AddControlToColor(label4);
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            if (txtCurrentPin.Text == "" ||  txtNewPin.Text == "" || txtCNewPin.Text == "")
            {
                MessageBox.Show("All fields are required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtNewPin.Text != txtCNewPin.Text)
            {
                MessageBox.Show("Password does not match, Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ThemeManage.ToggleTheme();
            ThemeManage.ApplyTheme();
        }
    }
}
