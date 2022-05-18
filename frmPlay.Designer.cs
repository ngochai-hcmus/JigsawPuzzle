namespace JigsawPuzzle
{
    partial class frmPlay
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlPuzzel = new System.Windows.Forms.Panel();
            this.pnlPlay = new System.Windows.Forms.Panel();
            this.pnlPicture = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlPuzzel);
            this.pnlMain.Controls.Add(this.pnlPlay);
            this.pnlMain.Controls.Add(this.pnlPicture);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Controls.Add(this.btnStart);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(925, 708);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlPuzzel
            // 
            this.pnlPuzzel.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlPuzzel.Location = new System.Drawing.Point(493, 12);
            this.pnlPuzzel.Name = "pnlPuzzel";
            this.pnlPuzzel.Size = new System.Drawing.Size(420, 420);
            this.pnlPuzzel.TabIndex = 7;
            // 
            // pnlPlay
            // 
            this.pnlPlay.BackColor = System.Drawing.Color.Bisque;
            this.pnlPlay.Location = new System.Drawing.Point(12, 12);
            this.pnlPlay.Name = "pnlPlay";
            this.pnlPlay.Size = new System.Drawing.Size(420, 420);
            this.pnlPlay.TabIndex = 6;
            // 
            // pnlPicture
            // 
            this.pnlPicture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPicture.Location = new System.Drawing.Point(12, 446);
            this.pnlPicture.Name = "pnlPicture";
            this.pnlPicture.Size = new System.Drawing.Size(250, 250);
            this.pnlPicture.TabIndex = 5;
            this.pnlPicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlPicture_MouseClick);
            this.pnlPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPicture_MouseMove);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(741, 620);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 56);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(741, 541);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 59);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // frmPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 708);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmPlay";
            this.Text = "frmPlay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlay_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlPuzzel;
        private System.Windows.Forms.Panel pnlPlay;
        private System.Windows.Forms.Panel pnlPicture;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStart;
    }
}

