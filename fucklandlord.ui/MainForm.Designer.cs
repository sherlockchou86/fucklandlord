namespace fucklandlord.ui
{
    partial class MainForm
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
            this.ucDesk1 = new fucklandlord.ui.ucDesk();
            this.ucLastCards1 = new fucklandlord.ui.ucLastCards();
            this.ucOtherBoard2 = new fucklandlord.ui.ucOtherBoard();
            this.ucOtherBoard1 = new fucklandlord.ui.ucOtherBoard();
            this.ucMyBoard1 = new fucklandlord.ui.ucMyBoard();
            this.SuspendLayout();
            // 
            // ucDesk1
            // 
            this.ucDesk1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDesk1.Location = new System.Drawing.Point(209, 139);
            this.ucDesk1.Name = "ucDesk1";
            this.ucDesk1.Size = new System.Drawing.Size(430, 241);
            this.ucDesk1.TabIndex = 4;
            // 
            // ucLastCards1
            // 
            this.ucLastCards1.Location = new System.Drawing.Point(333, 2);
            this.ucLastCards1.Name = "ucLastCards1";
            this.ucLastCards1.Size = new System.Drawing.Size(182, 84);
            this.ucLastCards1.TabIndex = 3;
            // 
            // ucOtherBoard2
            // 
            this.ucOtherBoard2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOtherBoard2.Location = new System.Drawing.Point(690, 2);
            this.ucOtherBoard2.Name = "ucOtherBoard2";
            this.ucOtherBoard2.Size = new System.Drawing.Size(178, 378);
            this.ucOtherBoard2.TabIndex = 2;
            // 
            // ucOtherBoard1
            // 
            this.ucOtherBoard1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ucOtherBoard1.Location = new System.Drawing.Point(2, 2);
            this.ucOtherBoard1.Name = "ucOtherBoard1";
            this.ucOtherBoard1.Size = new System.Drawing.Size(178, 378);
            this.ucOtherBoard1.TabIndex = 1;
            // 
            // ucMyBoard1
            // 
            this.ucMyBoard1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucMyBoard1.Location = new System.Drawing.Point(2, 388);
            this.ucMyBoard1.Name = "ucMyBoard1";
            this.ucMyBoard1.Size = new System.Drawing.Size(866, 211);
            this.ucMyBoard1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 600);
            this.Controls.Add(this.ucDesk1);
            this.Controls.Add(this.ucLastCards1);
            this.Controls.Add(this.ucOtherBoard2);
            this.Controls.Add(this.ucOtherBoard1);
            this.Controls.Add(this.ucMyBoard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ucMyBoard ucMyBoard1;
        private ucOtherBoard ucOtherBoard1;
        private ucOtherBoard ucOtherBoard2;
        private ucLastCards ucLastCards1;
        private ucDesk ucDesk1;
    }
}