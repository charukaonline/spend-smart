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
    }
}
