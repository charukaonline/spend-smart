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
    public partial class analytics : UserControl
    {
        public analytics()
        {
            InitializeComponent();

            ThemeManage.AddControlToColor(guna2Panel3);
            ThemeManage.AddControlToColor(guna2Panel4);
            ThemeManage.AddControlToColor(label1);
            ThemeManage.AddControlToColor(label3);

            this.Load += analytics_Load;
        }

        private void analytics_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();
        }
    }
}
