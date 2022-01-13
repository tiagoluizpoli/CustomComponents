namespace TPoliCustomControls.Controls
{
    partial class TextBoxCustom_tpoli
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.baseTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // baseTextBox
            // 
            this.baseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.baseTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTextBox.Location = new System.Drawing.Point(7, 7);
            this.baseTextBox.Name = "baseTextBox";
            this.baseTextBox.Size = new System.Drawing.Size(236, 15);
            this.baseTextBox.TabIndex = 0;
            this.baseTextBox.Click += new System.EventHandler(this.baseTextBox_Click);
            this.baseTextBox.TextChanged += new System.EventHandler(this.baseTextBox_TextChanged);
            this.baseTextBox.Enter += new System.EventHandler(this.baseTextBox_Enter);
            this.baseTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.baseTextBox_KeyDown);
            this.baseTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.baseTextBox_KeyPress);
            this.baseTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.baseTextBox_KeyUp);
            this.baseTextBox.Leave += new System.EventHandler(this.baseTextBox_Leave);
            this.baseTextBox.MouseEnter += new System.EventHandler(this.baseTextBox_MouseEnter);
            this.baseTextBox.MouseLeave += new System.EventHandler(this.baseTextBox_MouseLeave);
            this.baseTextBox.MouseHover += new System.EventHandler(this.baseTextBox_MouseHover);
            // 
            // TextBoxCustom_tpoli
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.baseTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TextBoxCustom_tpoli";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(250, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox baseTextBox;
    }
}
