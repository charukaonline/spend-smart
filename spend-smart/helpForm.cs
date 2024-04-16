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
    public partial class helpForm : Form
    {
        int i;

        public helpForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(BorderRadius.CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
        }

        private void helpEffect_Timer_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                helpEffect_Timer.Stop();
            }
            else
            {
                Opacity += 1;
            }

            int y = menuControls.parentY += 140;
            this.Location = new Point(menuControls.parentX + 250, y);
            if (y >= i)
            {
                helpEffect_Timer.Stop();
            }
        }

        private void helpForm_Load(object sender, EventArgs e)
        {
            i = menuControls.parentY + 140;

            // Calculate the center of the screen
            int centerX = Screen.PrimaryScreen.WorkingArea.Width / 2;
            int centerY = Screen.PrimaryScreen.WorkingArea.Height / 2;

            // Calculate the location to position the form in the center
            int formX = centerX - (this.Width / 2);
            int formY = centerY - (this.Height / 2);

            // Set the form's location to the calculated position
            this.Location = new Point(formX, formY);
        }
    }
}
