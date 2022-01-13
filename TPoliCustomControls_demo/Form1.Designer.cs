namespace TPoliCustomControls_demo
{
    partial class Form1
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxCustom_tpoli1 = new TPoliCustomControls.Controls.ListBoxCustom_tpoli();
            this.buttonFlat_tpoli1 = new TPoliCustomControls.Controls.ButtonFlat_tpoli();
            this.textBoxCustom_tpoli1 = new TPoliCustomControls.Controls.TextBoxCustom_tpoli();
            this.SuspendLayout();
            // 
            // listBoxCustom_tpoli1
            // 
            this.listBoxCustom_tpoli1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxCustom_tpoli1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.listBoxCustom_tpoli1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listBoxCustom_tpoli1.FormattingEnabled = true;
            this.listBoxCustom_tpoli1.IsGradient = false;
            this.listBoxCustom_tpoli1.ItemHeight = 18;
            this.listBoxCustom_tpoli1.LineBackColor = "#FFFFFF";
            this.listBoxCustom_tpoli1.LineHighlightColorMain = "#C02C20";
            this.listBoxCustom_tpoli1.LineHighlightColorSecondary = "#FFB752";
            this.listBoxCustom_tpoli1.Location = new System.Drawing.Point(12, 12);
            this.listBoxCustom_tpoli1.Name = "listBoxCustom_tpoli1";
            this.listBoxCustom_tpoli1.Size = new System.Drawing.Size(230, 238);
            this.listBoxCustom_tpoli1.TabIndex = 1;
            this.listBoxCustom_tpoli1.TextColor = "#000000";
            // 
            // buttonFlat_tpoli1
            // 
            this.buttonFlat_tpoli1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(60)))), ((int)(((byte)(8)))));
            this.buttonFlat_tpoli1.BackgroundColor = "#E33C08";
            this.buttonFlat_tpoli1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(60)))), ((int)(((byte)(8)))));
            this.buttonFlat_tpoli1.BorderRadius = 10;
            this.buttonFlat_tpoli1.BorderSize = 1;
            this.buttonFlat_tpoli1.FlatAppearance.BorderSize = 0;
            this.buttonFlat_tpoli1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFlat_tpoli1.ForeColor = System.Drawing.Color.White;
            this.buttonFlat_tpoli1.Location = new System.Drawing.Point(12, 398);
            this.buttonFlat_tpoli1.Name = "buttonFlat_tpoli1";
            this.buttonFlat_tpoli1.Size = new System.Drawing.Size(150, 40);
            this.buttonFlat_tpoli1.TabIndex = 0;
            this.buttonFlat_tpoli1.Text = "buttonFlat_tpoli1";
            this.buttonFlat_tpoli1.TextColor = System.Drawing.Color.White;
            this.buttonFlat_tpoli1.UseVisualStyleBackColor = false;
            this.buttonFlat_tpoli1.Click += new System.EventHandler(this.buttonFlat_tpoli1_Click);
            // 
            // textBoxCustom_tpoli1
            // 
            this.textBoxCustom_tpoli1.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCustom_tpoli1.BorderColor = "#433D3D";
            this.textBoxCustom_tpoli1.BorderFocusColor = "#E33C08";
            this.textBoxCustom_tpoli1.BorderSize = 2;
            this.textBoxCustom_tpoli1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustom_tpoli1.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxCustom_tpoli1.Location = new System.Drawing.Point(12, 257);
            this.textBoxCustom_tpoli1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCustom_tpoli1.Multiline = false;
            this.textBoxCustom_tpoli1.Name = "textBoxCustom_tpoli1";
            this.textBoxCustom_tpoli1.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxCustom_tpoli1.PasswordChar = false;
            this.textBoxCustom_tpoli1.Size = new System.Drawing.Size(230, 31);
            this.textBoxCustom_tpoli1.TabIndex = 2;
            this.textBoxCustom_tpoli1.Texts = "";
            this.textBoxCustom_tpoli1.UnderlinedStyle = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxCustom_tpoli1);
            this.Controls.Add(this.listBoxCustom_tpoli1);
            this.Controls.Add(this.buttonFlat_tpoli1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TPoliCustomControls.Controls.ButtonFlat_tpoli buttonFlat_tpoli1;
        private TPoliCustomControls.Controls.ListBoxCustom_tpoli listBoxCustom_tpoli1;
        private TPoliCustomControls.Controls.TextBoxCustom_tpoli textBoxCustom_tpoli1;
    }
}

