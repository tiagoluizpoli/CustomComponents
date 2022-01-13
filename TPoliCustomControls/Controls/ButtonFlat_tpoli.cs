using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace TPoliCustomControls.Controls
{
    public class ButtonFlat_tpoli : Button
    {

        #region Fields
        private int borderSize = 1;
        private int borderRadius = 10;
        private Color borderColor = ColorTranslator.FromHtml("#e33c08");
        #endregion

        #region Properties
        [Category("Button Radius Attributes")]
        public int BorderSize { get => borderSize; set { borderSize = value; Invalidate(); } }
        [Category("Button Radius Attributes")]
        public int BorderRadius
        {
            get => borderRadius; set
            {

                if (value <= Height)
                {
                    borderRadius = value;
                }
                else
                {
                    borderRadius = Height;
                }

                Invalidate();
            }
        }
        [Category("Button Radius Attributes")]
        public Color BorderColor { get => borderColor; set { borderColor = value; Invalidate(); } }
        [Category("Button Radius Attributes")]
        public string BackgroundColor
        {
            get { return "#" + BackColor.R.ToString("X2") + BackColor.G.ToString("X2") + BackColor.B.ToString("X2"); }//ColorTranslator.ToHtml(this.BackColor); }
            set { BackColor = ColorTranslator.FromHtml(value); }
        }
        [Category("Button Radius Attributes")]
        public Color TextColor
        {
            get { return ForeColor; }
            set { ForeColor = value; }
        }
        #endregion

        #region Constructor
        public ButtonFlat_tpoli()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 40);
            BackColor = ColorTranslator.FromHtml("#e33c08");
            ForeColor = Color.White;
            Resize += new EventHandler(Button_Resize);


        }
        #endregion

        #region Methods
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rectSurface = new RectangleF(0, 0, Width, Height);
            RectangleF rectBorder = new RectangleF(1, 1, Width - 0.8F, Height - 1);
            if (borderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    //Button Surface
                    Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                    //Draw border
                    if (borderSize > 1)
                    {
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else //Normal button
            {
                //Button Surface
                Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                Invalidate();
            }
        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > Height)
            {
                borderRadius = Height;
            }
        }
        #endregion
    }
}
