using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO.Ports;
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

        private OleDbConnection dbConnection;

        private int currentID;
        private string currentName;

        private System.Windows.Forms.Timer refreshTimer;

        public menuControls()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(BorderRadius.CreateRoundRectRgn(0, 0, Width, Height, 18, 18));

            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 2000;
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void menuControls_Load(object sender, EventArgs e)
        {
            // access UserID and Username from UserSession
            currentID = UserSession.CurrentUserID;
            currentName = UserSession.CurrentUsername;

            dashboard1.Show();
            analytics1.Hide();
            addTransactions1.Hide();
            notificationsForm1.Hide();
            showExpenses1.Hide();
            noteForm1.Hide();
            settingForm1.Hide();
            showIncomes1.Hide();

            InitializeToolTips();
            InitializeDBConnection();

            welcomeUser.Text = "Welcome, " + currentName;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Refresh the data
            dashboard1.RefreshData();
            showExpenses1.RefreshData();
            showIncomes1.RefreshData();
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
            addTransactions1.Hide();
            notificationsForm1.Hide();
            showExpenses1.Hide();
            noteForm1.Hide();
            settingForm1.Hide();
            dashboard1.Show();
            showIncomes1.Hide();
        }

        private void addExpBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            analytics1.Hide();
            notificationsForm1.Hide();
            showExpenses1.Hide();
            noteForm1.Hide();
            settingForm1.Hide();
            addTransactions1.Show();
            showIncomes1.Hide();
        }

        private void analyticsBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            addTransactions1.Hide();
            notificationsForm1.Hide();
            showExpenses1.Hide();
            noteForm1.Hide();
            settingForm1.Hide();
            analytics1.Show();
            showIncomes1.Hide();
        }

        private void notificationBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            addTransactions1.Hide();
            analytics1.Hide();
            showExpenses1.Hide();
            noteForm1.Hide();
            settingForm1.Hide();
            notificationsForm1.Show();
            showIncomes1.Hide();
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            addTransactions1.Hide();
            analytics1.Hide();
            notificationsForm1.Hide();
            showExpenses1.Hide();
            noteForm1.Hide();
            settingForm1.Show();
            showIncomes1.Hide();
        }

        private void ExpensesBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            addTransactions1.Hide();
            analytics1.Hide();
            notificationsForm1.Hide();
            showExpenses1.Show();
            noteForm1.Hide();
            settingForm1.Hide();
            showIncomes1.Hide();
        }

        private void NotesBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            addTransactions1.Hide();
            analytics1.Hide();
            notificationsForm1.Hide();
            showExpenses1.Hide();
            noteForm1.Show();
            settingForm1.Hide();
            showIncomes1.Hide();
        }

        private void IncomesBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Hide();
            addTransactions1.Hide();
            analytics1.Hide();
            notificationsForm1.Hide();
            showExpenses1.Hide();
            noteForm1.Hide();
            settingForm1.Hide();
            showIncomes1.Show();
        }

        public static int parentX, parentY;

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Form helpBackground = new Form();
            using (helpForm help = new helpForm())
            {
                helpBackground.StartPosition = FormStartPosition.Manual;
                helpBackground.FormBorderStyle = FormBorderStyle.None;
                helpBackground.Opacity = .50d;
                helpBackground.BackColor = Color.Black;
                helpBackground.Size = this.Size;
                helpBackground.Location = this.Location;
                helpBackground.ShowInTaskbar = false;
                helpBackground.Show();
                help.Owner = helpBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                help.ShowDialog();
                helpBackground.Dispose();
            }
        }

        private void InitializeToolTips()
        {
            // Add tooltips to the icons
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(dashboardBtn, "Dashboard");

            ToolTip toolTip2 = new ToolTip();
            toolTip2.SetToolTip(addExpBtn, "Add Income and Expense");

            ToolTip toolTip3 = new ToolTip();
            toolTip3.SetToolTip(analyticsBtn, "Analytics");

            ToolTip toolTip4 = new ToolTip();
            toolTip4.SetToolTip(IncomesBtn, "Show Incomes");

            ToolTip toolTip5 = new ToolTip();
            toolTip5.SetToolTip(ExpensesBtn, "Show Expenses");

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

            ToolTip toolTip13 = new ToolTip();
            toolTip5.SetToolTip(NotesBtn, "Show added notes");

            // Attach MouseMove event handler to sidebarPanel or individual icons
            menu.MouseMove += Sidebar_MouseMove;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            UserSession.EndSession();

            loginForm login = new loginForm();
            login.Show();
            this.Hide();
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

        private void InitializeDBConnection()
        {
            try
            {
                dbConnection = new OleDbConnection(dbConn.Instance.connString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }
    }
}
