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
    public partial class expensesForm : UserControl
    {
        public expensesForm()
        {
            InitializeComponent();

            ThemeManage.AddControlToColor(guna2Panel3);
            ThemeManage.AddControlToColor(guna2Panel4);
            ThemeManage.AddControlToColor(label1);
            ThemeManage.AddControlToColor(label2);
            ThemeManage.AddControlToColor(label4);
            ThemeManage.AddControlToColor(btnIncomeSubmit);
            ThemeManage.AddControlToColor(btnExpenseSubmit);

            this.Load += expensesForm_Load;
        }

        private void expensesForm_Load(object sender, EventArgs e)
        {
            ThemeManage.ApplyTheme();
        }
    }
}
