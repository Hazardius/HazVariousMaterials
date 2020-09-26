namespace Makao
{
    partial class AsOkno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsOkno));
            this.IWantIt = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Wizerunek = new System.Windows.Forms.PictureBox();
            this.Info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Wizerunek)).BeginInit();
            this.SuspendLayout();
            // 
            // IWantIt
            // 
            this.IWantIt.Location = new System.Drawing.Point(69, 231);
            this.IWantIt.Name = "IWantIt";
            this.IWantIt.Size = new System.Drawing.Size(151, 25);
            this.IWantIt.TabIndex = 17;
            this.IWantIt.Text = "Zadam!";
            this.IWantIt.UseVisualStyleBackColor = true;
            this.IWantIt.Click += new System.EventHandler(this.IWantIt_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Pik",
            "Karo",
            "Trefl",
            "Kier"});
            this.listBox1.Location = new System.Drawing.Point(36, 143);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.Size = new System.Drawing.Size(213, 82);
            this.listBox1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(55, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Jakiego koloru zadasz?";
            // 
            // Wizerunek
            // 
            this.Wizerunek.Image = ((System.Drawing.Image)(resources.GetObject("Wizerunek.Image")));
            this.Wizerunek.Location = new System.Drawing.Point(115, 42);
            this.Wizerunek.Name = "Wizerunek";
            this.Wizerunek.Size = new System.Drawing.Size(55, 75);
            this.Wizerunek.TabIndex = 14;
            this.Wizerunek.TabStop = false;
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Info.Location = new System.Drawing.Point(51, 8);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(182, 31);
            this.Info.TabIndex = 13;
            this.Info.Text = "Zagrales Asa!";
            // 
            // AsOkno
            // 
            this.AcceptButton = this.IWantIt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.IWantIt);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Wizerunek);
            this.Controls.Add(this.Info);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "AsOkno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zagrales Asa!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AsOkno_FormClosing);
            this.Load += new System.EventHandler(this.AsOkno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Wizerunek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button IWantIt;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Wizerunek;
        private System.Windows.Forms.Label Info;
    }
}