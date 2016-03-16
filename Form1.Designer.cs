namespace BikeMap
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bxShortest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cbxStart = new System.Windows.Forms.ComboBox();
            this.cbxEnd = new System.Windows.Forms.ComboBox();
            this.trackControl = new GPX.TrackControl();
            this.settingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map File";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "MapFile", true));
            this.textBox1.Location = new System.Drawing.Point(65, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(314, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(386, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Pt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Destination";
            // 
            // bxShortest
            // 
            this.bxShortest.Location = new System.Drawing.Point(458, 52);
            this.bxShortest.Name = "bxShortest";
            this.bxShortest.Size = new System.Drawing.Size(79, 20);
            this.bxShortest.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Shortest Path";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(499, 13);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(343, 23);
            this.progressBar.TabIndex = 9;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(849, 19);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(75, 13);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "Loading Paths";
            // 
            // cbxStart
            // 
            this.cbxStart.FormattingEnabled = true;
            this.cbxStart.Location = new System.Drawing.Point(65, 36);
            this.cbxStart.Name = "cbxStart";
            this.cbxStart.Size = new System.Drawing.Size(314, 21);
            this.cbxStart.TabIndex = 12;
            this.cbxStart.SelectedIndexChanged += new System.EventHandler(this.cbxEnd_SelectedIndexChanged);
            // 
            // cbxEnd
            // 
            this.cbxEnd.FormattingEnabled = true;
            this.cbxEnd.Location = new System.Drawing.Point(65, 64);
            this.cbxEnd.Name = "cbxEnd";
            this.cbxEnd.Size = new System.Drawing.Size(314, 21);
            this.cbxEnd.TabIndex = 13;
            this.cbxEnd.SelectedIndexChanged += new System.EventHandler(this.cbxEnd_SelectedIndexChanged);
            // 
            // trackControl
            // 
            this.trackControl.AllowDrop = true;
            this.trackControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackControl.AutoScroll = true;
            this.trackControl.CacheDate = new System.DateTime(((long)(0)));
            this.trackControl.DrawPointsOfInterest = false;
            this.trackControl.DrawTrackLine = false;
            this.trackControl.DrawWaypoints = false;
            this.trackControl.IndexOfFirstPointShown = 0;
            this.trackControl.IndexOfLastPointShown = 0;
            this.trackControl.Location = new System.Drawing.Point(0, 92);
            this.trackControl.Name = "trackControl";
            this.trackControl.PoIColor = System.Drawing.Color.DarkGreen;
            this.trackControl.ShowAllPointsOfSegment = false;
            this.trackControl.ShowMap = false;
            this.trackControl.Size = new System.Drawing.Size(984, 405);
            this.trackControl.StyleForPoI = GPX.WaypointsStyle.SmallCircle;
            this.trackControl.StyleForWaypoints = GPX.WaypointsStyle.SmallCircle;
            this.trackControl.TabIndex = 11;
            this.trackControl.TrackColor = System.Drawing.Color.Red;
            this.trackControl.TrackColorHighlight = System.Drawing.Color.Goldenrod;
            this.trackControl.Tracks = null;
            this.trackControl.TrackThickness = 3F;
            this.trackControl.UseEqualScale = false;
            this.trackControl.WayPointsColor = System.Drawing.Color.BlanchedAlmond;
            this.trackControl.WayPointsHighlight = System.Drawing.Color.Gold;
            this.trackControl.XCategory = GPX.DrawCategory.Time;
            this.trackControl.YCategory = GPX.DrawCategory.Time;
            this.trackControl.Zoom = 0F;
            // 
            // settingsBindingSource
            // 
            this.settingsBindingSource.DataSource = typeof(BikeMap.Settings);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 497);
            this.Controls.Add(this.cbxEnd);
            this.Controls.Add(this.cbxStart);
            this.Controls.Add(this.trackControl);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bxShortest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Bike Map";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bxShortest;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private GPX.TrackControl trackControl;
        private System.Windows.Forms.BindingSource settingsBindingSource;
        private System.Windows.Forms.ComboBox cbxStart;
        private System.Windows.Forms.ComboBox cbxEnd;
    }
}

