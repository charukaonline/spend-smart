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

        public menuControls()
        {
            InitializeComponent();
        }

        private void menuControls_Load(object sender, EventArgs e)
        {
            dashboard1.Show();
            analytics1.Hide();
            expensesForm1.Hide();
            notificationsForm1.Hide();
            transactionsForm1.Hide();
            noteForm1.Hide();

            // Add tooltips to the icons
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(dashboardBtn, "Dashboard");

            ToolTip toolTip2 = new ToolTip();
            toolTip2.SetToolTip(addExpBtn, "Add Income and Expense");

            ToolTip toolTip3 = new ToolTip();
            toolTip3.SetToolTip(analyticsBtn, "Analytics");

            ToolTip toolTip4 = new ToolTip();
            toolTip4.SetToolTip(transactionBtn, "Transaction");

            ToolTip toolTip5 = new ToolTip();
            toolTip5.SetToolTip(noteBtn, "Add Note");

            ToolTip toolTip6 = new ToolTip();
            toolTip6.SetToolTip(notificationBtn, "Notification");

            ToolTip toolTip7 = new ToolTip();
            toolTip7.SetToolTip(logoutBtn, "Logout");

            ToolTip toolTip8 = new ToolTip();
            toolTip8.SetToolTip(settingBtn, "Setting");

            ToolTip toolTip9 = new ToolTip();
            toolTip9.SetToolTip(helpBtn, "Help");

            ToolTip toolTip10 = new ToolTip();
            toolTip10.SetToolTip(minimizaBtn, "Minimize");

            ToolTip toolTip11 = new ToolTip();
            toolTip11.SetToolTip(maximizeBtn, "Maximize");

            ToolTip toolTip12 = new ToolTip();
            toolTip12.SetToolTip(closingBtn, "Close");

            // Attach MouseMove event handler to sidebarPanel or individual icons
            menu.MouseMove += Sidebar_MouseMove;
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

        private void dashboard_Click(object sender, EventArgs e)
        {
            analytics1.Hide();
            expensesForm1.Hide();
            notificationsForm1.Hide();
            transactionsForm1.Hide();
            noteForm1.Hide();
            dashboard1.Show();
        }

        private void addExpBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            analytics1.Hide();
            notificationsForm1.Hide();
            transactionsForm1.Hide();
            noteForm1.Hide();
            expensesForm1.Show();
        }

        private void analyticsBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            expensesForm1.Hide();
            notificationsForm1.Hide();
            transactionsForm1.Hide();
            noteForm1.Hide();
            analytics1.Show();
        }

        private void notificationBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            expensesForm1.Hide();
            analytics1.Hide();
            transactionsForm1.Hide();
            noteForm1.Hide();
            notificationsForm1.Show();
        }

        private void transactionBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            expensesForm1.Hide();
            analytics1.Hide();
            notificationsForm1.Hide();
            noteForm1.Hide();
            transactionsForm1.Show();
        }

        private void noteBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            expensesForm1.Hide();
            analytics1.Hide();
            notificationsForm1.Hide();
            transactionsForm1.Hide();
            noteForm1.Show();
        }

        private void Sidebar_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = menu.GetChildAtPoint(e.Location); 
            if (control != null && control is PictureBox pictureBox)
            {
                // Display the name of the icon near the mouse pointer
                string iconName = pictureBox.Name;
                Point screenPoint = pictureBox.PointToScreen(Point.Empty);
                Point adjustedPoint = new Point(screenPoint.X + 20, screenPoint.Y - 20);
            }
        }
    }
}
