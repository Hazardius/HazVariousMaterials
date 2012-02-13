namespace Makao
{
    partial class Dobranie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dobranie));
            this.Info = new System.Windows.Forms.Label();
            this.Wizerunek = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TakeButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Wizerunek)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Info.Location = new System.Drawing.Point(43, 9);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(199, 31);
            this.Info.TabIndex = 1;
            this.Info.Text = "Dobrales karte!";
            // 
            // Wizerunek
            // 
            this.Wizerunek.Image = ((System.Drawing.Image)(resources.GetObject("Wizerunek.Image")));
            this.Wizerunek.Location = new System.Drawing.Point(115, 43);
            this.Wizerunek.Name = "Wizerunek";
            this.Wizerunek.Size = new System.Drawing.Size(55, 75);
            this.Wizerunek.TabIndex = 5;
            this.Wizerunek.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TakeButton);
            this.panel1.Controls.Add(this.PlayButton);
            this.panel1.Location = new System.Drawing.Point(46, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 36);
            this.panel1.TabIndex = 6;
            // 
            // TakeButton
            // 
            this.TakeButton.Location = new System.Drawing.Point(95, 0);
            this.TakeButton.Name = "TakeButton";
            this.TakeButton.Size = new System.Drawing.Size(98, 36);
            this.TakeButton.TabIndex = 8;
            this.TakeButton.Text = "Zachowaj";
            this.TakeButton.UseVisualStyleBackColor = true;
            this.TakeButton.Click += new System.EventHandler(this.TakeButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(0, 0);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(95, 36);
            this.PlayButton.TabIndex = 7;
            this.PlayButton.Text = "Zagraj";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // Dobranie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Wizerunek);
            this.Controls.Add(this.Info);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "Dobranie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dobrales karte!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dobranie_FormClosing);
            this.Load += new System.EventHandler(this.Dobranie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Wizerunek)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.PictureBox Wizerunek;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button TakeButton;
        private System.Windows.Forms.Button PlayButton;
    }
}