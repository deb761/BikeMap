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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(65, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(314, 20);
            this.textBox2.TabIndex = 4;
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(65, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(314, 20);
            this.textBox3.TabIndex = 6;
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
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(458, 52);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(79, 20);
            this.textBox4.TabIndex = 7;
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
            this.progressBar.Location = new System.Drawing.Point(13, 462);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(343, 23);
            this.progressBar.TabIndex = 9;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(363, 468);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(75, 13);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "Loading Paths";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(485, 191);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(250, 250);
            this.webBrowser1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 497);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Bike Map";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

