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
    public partial class notificationsForm : UserControl
    {
        public notificationsForm()
        {
            InitializeComponent();

            ThemeManage.AddControlToColor(guna2Panel2);
            ThemeManage.AddControlToColor(label1);

            this.Load += notificationForm_Load;
        }

        private void notificationForm_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();
        }
    }
}
