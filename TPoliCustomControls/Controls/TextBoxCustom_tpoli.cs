using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPoliCustomControls.Controls
{
    [DefaultEvent("_TextChanged")]
    public partial class TextBoxCustom_tpoli : UserControl
    {
        //Fields
        private Color borderColor = ColorTranslator.FromHtml("#433d3d");
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = ColorTranslator.FromHtml("#e33c08");
        private bool isFocused = false;

        
        //Constructor
        public TextBoxCustom_tpoli()
        {
            InitializeComponent();
        }

        //Events
        public event EventHandler _TextChanged;

        //Properties
        #region Properties
        [Category("Custom Properties")]
        public String BorderColor
        {
            get
            {
                return "#" + borderColor.R.ToString("X2") + borderColor.G.ToString("X2") + borderColor.B.ToString("X2");
            }
            set
            {
                borderColor = ColorTranslator.FromHtml(value);
                this.Invalidate();
            }
        }
        [Category("Custom Properties")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }
        [Category("Custom Properties")]
        public bool UnderlinedStyle
        {
            get
            {
                return underlinedStyle;
            }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }
        [Category("Custom Properties")]
        public bool PasswordChar
        {
            get
            {
                return baseTextBox.UseSystemPasswordChar;
            }
            set
            {
                baseTextBox.UseSystemPasswordChar = value;
            }
        }
        [Category("Custom Properties")]
        public bool Multiline
        {
            get
            {
                return baseTextBox.Multiline;
            }
            set
            {
                baseTextBox.Multiline = value;
            }
        }
        [Category("Custom Properties")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                baseTextBox.BackColor = value;
            }
        }
        [Category("Custom Properties")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                baseTextBox.ForeColor = value;
            }
        }
        [Category("Custom Properties")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                baseTextBox.Font = Font;
                if (this.DesignMode)
                {
                    UpdateControlHeight();
                }
            }
        }
        [Category("Custom Properties")]
        public string Texts
        {
            get
            {
                return baseTextBox.Text;
            }
            set
            {
                baseTextBox.Text = value;
            }
        }
        [Category("Custom Properties")]
        public String BorderFocusColor
        {
            get 
            {
                return "#" + borderFocusColor.R.ToString("X2") + borderFocusColor.G.ToString("X2") + borderFocusColor.B.ToString("X2");
            }
            set
            {
                borderFocusColor = ColorTranslator.FromHtml(value);
            }
        }

        #endregion



        //Overridden Methods
        #region Overridden Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            //Draw Border
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (!isFocused)
                {
                    if (underlinedStyle)
                    {
                        //Line Style
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        //Normal Style
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                }
                else
                {
                    penBorder.Color = borderFocusColor;
                    if (underlinedStyle)
                    {
                        //Line Style
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        //Normal Style
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                }

               
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }
        #endregion


        //Private Methods
        private void UpdateControlHeight()
        {
            if (baseTextBox.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                baseTextBox.Multiline = true;
                baseTextBox.MinimumSize = new Size(0, txtHeight);
                baseTextBox.Multiline = false;


                this.Height = baseTextBox.Height + this.Padding.Top + this.Padding.Bottom;

            }
        }

        private void baseTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged!= null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }

        private void baseTextBox_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void baseTextBox_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void baseTextBox_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void baseTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void baseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void baseTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        private void baseTextBox_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
        }

        private void baseTextBox_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
        }

        private void baseTextBox_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
        }
    }
}
