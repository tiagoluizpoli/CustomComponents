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
    public class ListBoxCustom_tpoli : ListBox
    {
        //Fields
        #region Fields
        private Color lineBackColor = ColorTranslator.FromHtml("#999999");
        private Color lineHighlightColorMain = ColorTranslator.FromHtml("#aaaaaa");
        private Color lineHighlightColorSecondary = ColorTranslator.FromHtml("#aaaaaa");
        private Color textColor = ColorTranslator.FromHtml("#000000");
        private bool isGradient = true;
        private int borderRadius = 20;
        private int borderSize = 1;
        #endregion

        //Attributes
        #region Custom Attributes
        [Category("Custom Attributes")]
        public String LineBackColor
        {
            get
            {
                return "#" + lineBackColor.R.ToString("X2") + lineBackColor.G.ToString("X2") + lineBackColor.B.ToString("X2");
            }
            set => lineBackColor = ColorTranslator.FromHtml(value);
        }

        [Category("Custom Attributes")]
        public String LineHighlightColorMain
        {
            get
            {
                return "#" + lineHighlightColorMain.R.ToString("X2") + lineHighlightColorMain.G.ToString("X2") + lineHighlightColorMain.B.ToString("X2");
            }
            set => lineHighlightColorMain = ColorTranslator.FromHtml(value);
        }

        [Category("Custom Attributes")]
        public bool IsGradient { get => isGradient; set => isGradient = value; }

        [Category("Custom Attributes")]
        public String LineHighlightColorSecondary
        {
            get
            {
                return "#" + lineHighlightColorSecondary.R.ToString("X2") + lineHighlightColorSecondary.G.ToString("X2") + lineHighlightColorSecondary.B.ToString("X2");
            }
            set => lineHighlightColorSecondary = ColorTranslator.FromHtml(value);
        }

        [Category("Custom Attributes")]
        public String TextColor
        {
            get
            {
                return "#" + textColor.R.ToString("X2") + textColor.G.ToString("X2") + textColor.B.ToString("X2");
            }
            set => textColor = ColorTranslator.FromHtml(value);
        }
        #endregion


        //Constructor
        public ListBoxCustom_tpoli()
        {
            this.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            this.ForeColor = textColor;
            //this.ItemHeight = 18;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            assignListningMethods();

        }

        

        //Private Methods
        private void assignListningMethods()
        {
            this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Custom_DrawItem);
        }

        //Listnening Methods
        private void Custom_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            Color clr = Color.FromArgb(0, lineHighlightColorSecondary);

            if (this.Items.Count > 0)
            {
                if (e.Index >= 0)
                {
                    Brush gb = new LinearGradientBrush(e.Bounds,
                                                       ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? lineHighlightColorMain : lineBackColor,
                                                       ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? lineHighlightColorSecondary : lineBackColor, 120);

                    SolidBrush sb = new SolidBrush(((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? lineHighlightColorMain : lineBackColor);
                    
                    e.Graphics.FillRectangle(IsGradient == true ? gb : sb, e.Bounds);
                    //e.Graphics.FillRectangle(gb, e.Bounds);

                    string txt = this.Items[e.Index].ToString();
                    SolidBrush tb = new SolidBrush(e.ForeColor);
                    e.Graphics.DrawString(txt, this.Font, tb, this.GetItemRectangle(e.Index).Location);
                }
            }
        }

    }
}
