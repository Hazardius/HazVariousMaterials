namespace Makao
{
    partial class WinLose
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
            this.Info = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Info.Location = new System.Drawing.Point(39, 9);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(207, 42);
            this.Info.TabIndex = 0;
            this.Info.Text = "Przegrales!";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(42, 54);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(200, 35);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK!";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // WinLose
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 109);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Info);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 145);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 145);
            this.Name = "WinLose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Default";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinLose_FormClosing);
            this.Load += new System.EventHandler(this.WinLose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Button OK;
    }
}