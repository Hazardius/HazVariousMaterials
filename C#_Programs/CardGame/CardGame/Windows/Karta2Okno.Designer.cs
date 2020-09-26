namespace CardGame
{
    partial class Card2Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Card2Window));
            this.panel1 = new System.Windows.Forms.Panel();
            this.twoButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.wyb2 = new System.Windows.Forms.PictureBox();
            this.Info = new System.Windows.Forms.Label();
            this.wyb1 = new System.Windows.Forms.PictureBox();
            this.wyb3 = new System.Windows.Forms.PictureBox();
            this.takeIt = new System.Windows.Forms.Button();
            this.innaButton = new System.Windows.Forms.Button();
            this.wyb4 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wyb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wyb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wyb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wyb4)).BeginInit();
            this.SuspendLayout();
            //
            // panel1
            //
            this.panel1.Controls.Add(this.innaButton);
            this.panel1.Controls.Add(this.twoButton);
            this.panel1.Controls.Add(this.threeButton);
            this.panel1.Controls.Add(this.oneButton);
            this.panel1.Location = new System.Drawing.Point(52, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 36);
            this.panel1.TabIndex = 9;
            //
            // twoButton
            //
            this.twoButton.Location = new System.Drawing.Point(69, 0);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(55, 36);
            this.twoButton.TabIndex = 9;
            this.twoButton.Text = "Poloz dwie";
            this.twoButton.UseVisualStyleBackColor = true;
            this.twoButton.Click += new System.EventHandler(this.twoButton_Click);
            //
            // threeButton
            //
            this.threeButton.Location = new System.Drawing.Point(130, 0);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(55, 36);
            this.threeButton.TabIndex = 8;
            this.threeButton.Text = "Poloz trzy";
            this.threeButton.UseVisualStyleBackColor = true;
            this.threeButton.Click += new System.EventHandler(this.threeButton_Click);
            //
            // oneButton
            //
            this.oneButton.Location = new System.Drawing.Point(8, 0);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(55, 36);
            this.oneButton.TabIndex = 7;
            this.oneButton.Text = "Poloz jedna";
            this.oneButton.UseVisualStyleBackColor = true;
            this.oneButton.Click += new System.EventHandler(this.oneButton_Click);
            //
            // wyb2
            //
            this.wyb2.Image = ((System.Drawing.Image)(resources.GetObject("wyb2.Image")));
            this.wyb2.Location = new System.Drawing.Point(121, 41);
            this.wyb2.Name = "wyb2";
            this.wyb2.Size = new System.Drawing.Size(55, 75);
            this.wyb2.TabIndex = 8;
            this.wyb2.TabStop = false;
            //
            // Info
            //
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Info.Location = new System.Drawing.Point(58, 7);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(242, 31);
            this.Info.TabIndex = 7;
            this.Info.Text = "Komputer zagral 2!";
            //
            // wyb1
            //
            this.wyb1.Image = ((System.Drawing.Image)(resources.GetObject("wyb1.Image")));
            this.wyb1.Location = new System.Drawing.Point(60, 41);
            this.wyb1.Name = "wyb1";
            this.wyb1.Size = new System.Drawing.Size(55, 75);
            this.wyb1.TabIndex = 10;
            this.wyb1.TabStop = false;
            //
            // wyb3
            //
            this.wyb3.Image = ((System.Drawing.Image)(resources.GetObject("wyb3.Image")));
            this.wyb3.Location = new System.Drawing.Point(182, 41);
            this.wyb3.Name = "wyb3";
            this.wyb3.Size = new System.Drawing.Size(55, 75);
            this.wyb3.TabIndex = 11;
            this.wyb3.TabStop = false;
            //
            // takeIt
            //
            this.takeIt.Location = new System.Drawing.Point(304, 122);
            this.takeIt.Name = "takeIt";
            this.takeIt.Size = new System.Drawing.Size(50, 36);
            this.takeIt.TabIndex = 12;
            this.takeIt.Text = "Wez x";
            this.takeIt.UseVisualStyleBackColor = true;
            this.takeIt.Click += new System.EventHandler(this.takeIt_Click);
            //
            // innaButton
            //
            this.innaButton.Location = new System.Drawing.Point(191, 0);
            this.innaButton.Name = "innaButton";
            this.innaButton.Size = new System.Drawing.Size(55, 36);
            this.innaButton.TabIndex = 10;
            this.innaButton.Text = "Zagraj 3";
            this.innaButton.UseVisualStyleBackColor = true;
            this.innaButton.Click += new System.EventHandler(this.innaButton_Click);
            //
            // wyb4
            //
            this.wyb4.Image = ((System.Drawing.Image)(resources.GetObject("wyb4.Image")));
            this.wyb4.Location = new System.Drawing.Point(243, 41);
            this.wyb4.Name = "wyb4";
            this.wyb4.Size = new System.Drawing.Size(55, 75);
            this.wyb4.TabIndex = 13;
            this.wyb4.TabStop = false;
            //
            // Card2Window
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 164);
            this.Controls.Add(this.wyb4);
            this.Controls.Add(this.takeIt);
            this.Controls.Add(this.wyb3);
            this.Controls.Add(this.wyb1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.wyb2);
            this.Controls.Add(this.Info);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(375, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(375, 200);
            this.Name = "Card2Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Komputer zagral 2!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Card2Window_FormClosing);
            this.Load += new System.EventHandler(this.Card2Window_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wyb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wyb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wyb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wyb4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.PictureBox wyb2;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.PictureBox wyb1;
        private System.Windows.Forms.PictureBox wyb3;
        private System.Windows.Forms.Button twoButton;
        private System.Windows.Forms.Button takeIt;
        private System.Windows.Forms.Button innaButton;
        private System.Windows.Forms.PictureBox wyb4;
    }
}