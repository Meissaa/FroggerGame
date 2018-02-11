namespace FroggerGame
{
    partial class Form3Ranking
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
            this.listBoxRanking = new System.Windows.Forms.ListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBoxRanking = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRanking)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxRanking
            // 
            this.listBoxRanking.BackColor = System.Drawing.SystemColors.MenuText;
            this.listBoxRanking.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.listBoxRanking.FormattingEnabled = true;
            this.listBoxRanking.ItemHeight = 16;
            this.listBoxRanking.Location = new System.Drawing.Point(25, 326);
            this.listBoxRanking.Name = "listBoxRanking";
            this.listBoxRanking.Size = new System.Drawing.Size(597, 372);
            this.listBoxRanking.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(496, 721);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(96, 39);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // pictureBoxRanking
            // 
            this.pictureBoxRanking.Location = new System.Drawing.Point(95, 12);
            this.pictureBoxRanking.Name = "pictureBoxRanking";
            this.pictureBoxRanking.Size = new System.Drawing.Size(481, 308);
            this.pictureBoxRanking.TabIndex = 2;
            this.pictureBoxRanking.TabStop = false;
            // 
            // Form3Ranking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(648, 772);
            this.Controls.Add(this.pictureBoxRanking);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listBoxRanking);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form3Ranking";
            this.Text = "Form3Ranking";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRanking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRanking;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox pictureBoxRanking;
    }
}