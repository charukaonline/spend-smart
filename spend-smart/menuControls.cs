using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spend_smart
{

    public partial class menuControls : Form
    {
        public Point mouseLocation;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public menuControls()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
        }

        private void menuControls_Load(object sender, EventArgs e)
        {
            dashboard1.Show();
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

        // Side menu button
        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Show();
        }

        private void addExpBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
        }

        private void analyticsBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
        }

        private void dashboard1_Load(object sender, EventArgs e)
        {

        }
    }
}
