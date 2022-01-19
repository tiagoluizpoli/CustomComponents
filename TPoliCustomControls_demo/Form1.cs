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
            listBoxCustom_tpoli1.Items.Add(textBoxCustom_tpoli1.Texts);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBoxCustom_tpoli1.BorderRadius = Int32.Parse(textBox1.Text.Length > 0 ? textBox1.Text : "0");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCustom_tpoli1.Multiline = checkBox1.Checked;
        }
    }
}
