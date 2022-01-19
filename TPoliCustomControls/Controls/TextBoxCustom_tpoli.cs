using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPoliCustomControls.Methods;


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
        
        private int borderRadius = 0;

        private Color placeholderColor = ColorTranslator.FromHtml("#433d3d");
        private string placeholderText = string.Empty;
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;


        GraphicsMethods graphicsMethods = new GraphicsMethods();
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
                return isPasswordChar;
            }
            set
            {
                isPasswordChar = value;
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
                if (isPlaceholder)
                {
                    return string.Empty;

                }
                else
                {
                    return baseTextBox.Text;
                }
               
            }
            set
            {
                baseTextBox.Text = value;
                SetPlaceholder();
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
        [Category("Custom Properties")]
        public int BorderRadius
        {
            get 
            { 
                return borderRadius; 
            }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate(); //Redraw Control

                }
            }
        }
        [Category("Custom Properties")]
        public Color PlaceholderColor
        {
            get 
            { 
                return placeholderColor; 
            }
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                {
                    baseTextBox.ForeColor = value;
                }
            }
        }
        [Category("Custom Properties")]
        public string PlaceholderText
        {
            get
            {
                return placeholderText;
            }
            set
            {
                placeholderText = value;
                baseTextBox.Text = "";
                SetPlaceholder();
            }
        }
   
       

        #endregion



        //Overridden Methods
        #region Overridden Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            


            if (borderRadius > 1) //Rounded TextBox
            {
                //-Fields
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;
                
                using(GraphicsPath pathBorderSmooth = graphicsMethods.GetFigurePath(rectBorderSmooth, borderRadius))
                using(GraphicsPath pathBorder=graphicsMethods.GetFigurePath(rectBorder, borderRadius-borderSize))
                using(Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using(Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //-Drawing
                    this.Region = new Region(pathBorderSmooth);//Set the rounded region of UserControl
                    if (borderRadius > 15) SetTextBoxRoundedRegion();//Set the rounded region of TextBox component
                    graph.SmoothingMode = SmoothingMode.AntiAlias;

                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (isFocused)  penBorder.Color = borderFocusColor;

                    if (underlinedStyle) //Line Style
                    {                       
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw the border 
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    
                    {
                        //Normal Style
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw the border 
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }
               
            }
            else // Squere/Normal TextBox
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (isFocused)
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

            //Draw Border
            
        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = graphicsMethods.GetFigurePath(baseTextBox.ClientRectangle, borderRadius - borderSize);
                baseTextBox.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = graphicsMethods.GetFigurePath(baseTextBox.ClientRectangle, borderSize * 2);
                baseTextBox.Region = new Region(pathTxt);
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

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(baseTextBox.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                baseTextBox.Text = placeholderText;
                baseTextBox.ForeColor = placeholderColor;
                if (isPasswordChar)
                {
                    baseTextBox.UseSystemPasswordChar = false;
                }
            }
        }

        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                baseTextBox.Text = String.Empty;
                baseTextBox.ForeColor = this.ForeColor;
                if (isPasswordChar)
                {
                    baseTextBox.UseSystemPasswordChar = true;
                }
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
            RemovePlaceholder();
        }

        private void baseTextBox_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }
    }
}
