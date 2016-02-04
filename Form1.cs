using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Object to hold user settings
        /// </summary>
        private Settings settings = new Settings();

        private void Form1_Load(object sender, EventArgs e)
        {
            graph = new Graph(settings.MapFile);
            bgWorker.RunWorkerAsync();
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProgress.Text = "Done calculating Shortest Paths";
        }

        Graph graph;
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
