namespace GPX
{
    partial class TrackControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlImage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlImage
            // 
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(200, 100);
            this.pnlImage.TabIndex = 0;
            this.pnlImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlImage_Paint);
            this.pnlImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseMove);
            this.pnlImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseDoubleClick);
            this.pnlImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseClick);
            this.pnlImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseDown);
            this.pnlImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseUp);
            // 
            // TrackControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlImage);
            this.Name = "TrackControl";
            this.Size = new System.Drawing.Size(331, 219);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlImage;
    }
}
