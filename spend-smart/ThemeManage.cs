using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spend_smart
{
    public static class ThemeManage
    {
        private static bool isLightTheme = false;
        private static List<Control> controlsToColor = new List<Control>();

        public static void ToggleTheme()
        {
            isLightTheme = !isLightTheme;
            ApplyTheme();
        }

        public static void AddControlToColor(Control control)
        {
            if (!controlsToColor.Contains(control))
            {
                controlsToColor.Add(control);
            }
        }

        public static void ApplyTheme()
        {
            foreach (Control ctrl in controlsToColor)
            {
                if (ctrl is Guna2Panel)
                {
                    Guna2Panel gunaPanel = (Guna2Panel)ctrl;
                    gunaPanel.FillColor = isLightTheme ? Color.White : Color.FromArgb(0xFF, 0x12, 0x12, 0x12);
                }
                else if (ctrl is Label)
                {
                    Label gunaLabel = (Label)ctrl;
                    gunaLabel.ForeColor = isLightTheme ? Color.FromArgb(0xFF, 0x12, 0x12, 0x12) : Color.White;
                }
            }
        }
    }
}
