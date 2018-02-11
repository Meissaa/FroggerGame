namespace FroggerGame
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelEndGame = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTimeGame = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelEndGame);
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1328, 775);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelEndGame
            // 
            this.labelEndGame.AutoSize = true;
            this.labelEndGame.BackColor = System.Drawing.Color.Transparent;
            this.labelEndGame.Enabled = false;
            this.labelEndGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEndGame.ForeColor = System.Drawing.Color.Red;
            this.labelEndGame.Location = new System.Drawing.Point(376, 254);
            this.labelEndGame.Name = "labelEndGame";
            this.labelEndGame.Size = new System.Drawing.Size(0, 91);
            this.labelEndGame.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelTimeGame
            // 
            this.labelTimeGame.AutoSize = true;
            this.labelTimeGame.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelTimeGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTimeGame.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTimeGame.Location = new System.Drawing.Point(27, 803);
            this.labelTimeGame.Name = "labelTimeGame";
            this.labelTimeGame.Size = new System.Drawing.Size(0, 25);
            this.labelTimeGame.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1329, 842);
            this.Controls.Add(this.labelTimeGame);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Frogger";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelTimeGame;
        private System.Windows.Forms.Label labelEndGame;
    }
}

