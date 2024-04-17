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
    public partial class showExpenses : UserControl
    {
        public showExpenses()
        {
            InitializeComponent();

            //ThemeManage.AddControlToColor(guna2Panel2);
            //ThemeManage.AddControlToColor(label1);
            //ThemeManage.AddControlToColor(label2);
            //ThemeManage.AddControlToColor(label3);
            //ThemeManage.AddControlToColor(label4);
            //ThemeManage.AddControlToColor(label6);
            //ThemeManage.AddControlToColor(label8);
            //ThemeManage.AddControlToColor(label9);
            //ThemeManage.AddControlToColor(label10);
            //ThemeManage.AddControlToColor(label12);
            //ThemeManage.AddControlToColor(label13);
            //ThemeManage.AddControlToColor(label14);
            //ThemeManage.AddControlToColor(label16);
            //ThemeManage.AddControlToColor(label17);
            //ThemeManage.AddControlToColor(label18);
            //ThemeManage.AddControlToColor(label20);
            //ThemeManage.AddControlToColor(label21);

            //this.Load += showExpenses_Load;
        }

        private void showExpenses_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();
        }
    }
}
