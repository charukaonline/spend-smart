using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace spend_smart.Custom_Tools
{
    public class CustomButton : Button
    {
        private int borderSize = 0;
        private int borderRadius = 0;
        private Color borderColor = Color.PaleVioletRed;
        private Color originalBackColor; // Store the original background color

        private Color hoverColor = Color.PaleVioletRed;
        private Color clickColor = Color.Black;

        private bool isMouseDown = false;
        private Point clickLocation;
        private int rippleSize = 0;
        private Timer rippleTimer;

        //Properties
        [Category("Custom Properties")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Custom Properties")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate();
            }
        }

        [Category("Custom Properties")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Custom Properties")]
        public Color BackgroundColor
        {
            get { return originalBackColor; } // Return the original background color
            set
            {
                originalBackColor = value;
                this.BackColor = value; // Set the background color
            }
        }

        [Category("Custom Properties")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        [Category("Custom Properties")]
        [Description("Specifies the hover color of the button.")]
        [Browsable(true)]
        public Color HoverColor
        {
            get { return hoverColor; }
            set
            {
                hoverColor = value;
                this.Invalidate();
            }
        }

        //Constructor
        public CustomButton()
        {
            originalBackColor = Color.MediumSlateBlue; // Set the original background color
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = originalBackColor; // Use the original background color
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);

            this.MouseDown += Btn_MouseDown;
            this.MouseUp += Btn_MouseUp;
            this.MouseEnter += Btn_MouseEnter;
            this.MouseLeave += Btn_MouseLeave;
            this.Paint += Btn_Paint;

            // Initialize timer for ripple animation
            rippleTimer = new Timer();
            rippleTimer.Interval = 40;
            rippleTimer.Tick += RippleTimer_Tick;
        }

        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);


            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            if (borderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button border                    
                    if (borderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                //Button surface
                this.Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }

        // Ripple Animation
        private void RippleTimer_Tick(object sender, EventArgs e)
        {
            rippleSize += 8; // Adjust the speed of the ripple animation here
            if (rippleSize > Math.Max(Width, Height))
            {
                rippleTimer.Stop();
                rippleSize = 0;
                Invalidate();
            }
            else
            {
                Invalidate();
            }
        }

        private void Btn_Paint(object sender, PaintEventArgs e)
        {
            if (isMouseDown && rippleSize > 0)
            {
                int alpha = 255 - (255 * rippleSize) / Math.Max(Width, Height);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, Color.Gray)))
                {
                    e.Graphics.FillEllipse(brush, clickLocation.X - rippleSize / 2, clickLocation.Y - rippleSize / 2, rippleSize, rippleSize);
                }
            }
        }

        // Add click animation
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            clickLocation = e.Location;
            rippleSize = 0;
            rippleTimer.Start(); // Start the ripple animation
            Invalidate();
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            Invalidate();
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = hoverColor;
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            isMouseDown = false;
            this.BackColor = originalBackColor; // Restore the original background color
            Invalidate();
        }
    }
}
