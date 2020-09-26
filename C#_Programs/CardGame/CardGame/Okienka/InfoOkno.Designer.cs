namespace Makao
{
    partial class InfoOkno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ok = new System.Windows.Forms.Button();
            this.Informacja = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(12, 12);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(30, 30);
            this.ok.TabIndex = 1;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // Informacja
            // 
            this.Informacja.Location = new System.Drawing.Point(48, 12);
            this.Informacja.Name = "Informacja";
            this.Informacja.Size = new System.Drawing.Size(224, 90);
            this.Informacja.TabIndex = 2;
            this.Informacja.Text = "Tekst informacji!";
            // 
            // InfoOkno
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 114);
            this.Controls.Add(this.Informacja);
            this.Controls.Add(this.ok);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "InfoOkno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InfoOkno";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoOkno_FormClosing);
            this.Load += new System.EventHandler(this.InfoOkno_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.RichTextBox Informacja;
    }
}