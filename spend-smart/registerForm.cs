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
    public partial class registerForm : Form
    {
        public Point mouseLocation;

        public registerForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(BorderRadius.CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
        }

        private void registerForm_Load(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = false;
            conNumValidationLbl.Visible = false;
            pinValidationLbl.Visible = false;
            conPinValidationLbl.Visible = false;
        }

        // Dragging part
        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        // Dragging part
        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void loginLbl_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide();
        }

        private void regUserNameTxt_Enter(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = true;
        }

        private void regUserNameTxt_TextChanged(object sender, EventArgs e)
        {
            usernameValidationLbl.Visible = false;
        }

        private void contactNumber_Enter(object sender, EventArgs e)
        {
            conNumValidationLbl.Visible = true;
        }

        private void contactNumber_TextChanged(object sender, EventArgs e)
        {
            conNumValidationLbl.Visible = false;
        }

        private void regPasswordTxt_Enter(object sender, EventArgs e)
        {
            pinValidationLbl.Visible = true;
        }

        private void regPasswordTxt_TextChanged(object sender, EventArgs e)
        {
            pinValidationLbl.Visible = false;
        }

        private void regConPassTxt_Enter(object sender, EventArgs e)
        {
            conPinValidationLbl.Visible = true;
        }

        private void regConPassTxt_TextChanged(object sender, EventArgs e)
        {
            conPinValidationLbl.Visible = false;
        }
    }
}
