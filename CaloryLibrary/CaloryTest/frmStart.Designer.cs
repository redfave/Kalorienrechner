namespace CaloryTest
{
    partial class frmStart
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBread = new System.Windows.Forms.Button();
            this.lblBread = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBread
            // 
            this.btnBread.Location = new System.Drawing.Point(104, 35);
            this.btnBread.Name = "btnBread";
            this.btnBread.Size = new System.Drawing.Size(75, 23);
            this.btnBread.TabIndex = 0;
            this.btnBread.Text = "Zeige Brot";
            this.btnBread.UseVisualStyleBackColor = true;
            this.btnBread.Click += new System.EventHandler(this.btnBread_Click);
            // 
            // lblBread
            // 
            this.lblBread.AutoSize = true;
            this.lblBread.Location = new System.Drawing.Point(47, 97);
            this.lblBread.Name = "lblBread";
            this.lblBread.Size = new System.Drawing.Size(136, 13);
            this.lblBread.TabIndex = 1;
            this.lblBread.Text = "Hier erscheint das Ergebnis";
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblBread);
            this.Controls.Add(this.btnBread);
            this.Name = "frmStart";
            this.Text = "Kalorienzähler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBread;
        private System.Windows.Forms.Label lblBread;
    }
}

