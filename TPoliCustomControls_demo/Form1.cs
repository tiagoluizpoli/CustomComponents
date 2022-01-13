using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPoliCustomControls_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fillListBox();
        }

        private void fillListBox()
        {
            listBoxCustom_tpoli1.Items.AddRange(new String[] { "Tiago", "Graziele", "Marcelly", "Luna" });
        }

        private void buttonFlat_tpoli1_Click(object sender, EventArgs e)
        {
            listBoxCustom_tpoli1.IsGradient = !listBoxCustom_tpoli1.IsGradient;
        }
    }
}
