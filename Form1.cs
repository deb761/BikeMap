using GPX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Utilities;

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
        /// <summary>
        /// Waypoints for the destination combobox
        /// </summary>
        private List<Vertex> waypoints;
        /// <summary>
        /// Load the graph from the mapfile and kickoff the background worker to calculate the
        /// shortest paths, then draw the tracks on the map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            graph = new Graph(settings.MapFile);
            bgWorker.RunWorkerAsync();

            cbxStart.DataSource = graph.Vertices;
            cbxStart.DisplayMember = "Name";

            // create another list of waypoints for the destination box, since they need to be bound
            // to different lists
            waypoints = new List<Vertex>(graph.Vertices);
            cbxEnd.DataSource = waypoints;
            cbxEnd.DisplayMember = "Name";

            settingsBindingSource.DataSource = settings;

            trackControl.UseEqualScale = true;
            trackControl.Zoom = _Zoom;

            //how to show waypoints
            trackControl.DrawWaypoints = false;
            trackControl.StyleForWaypoints = WaypointsStyle.SmallCircle;
            trackControl.WayPointsColor = Color.Aqua;
            trackControl.WayPointsHighlight = Color.Gold;

            trackControl.DrawPointsOfInterest = true;
            trackControl.StyleForPoI = WaypointsStyle.BigX;
            trackControl.PoIColor = Color.DarkRed;

            trackControl.DrawTrackLine = true;
            trackControl.TrackThickness = 2.0f;
            trackControl.TrackColor = Color.Green;
            trackControl.TrackColorHighlight = Color.Goldenrod;

            trackControl.ShowMap = true;
            //with Maps, it is always latitude/longitude to be used for further calculation!
            trackControl.XCategory = DrawCategory.Longitude;
            trackControl.YCategory = DrawCategory.Latitude;
            //show a map?
            trackControl.MapType = GMap.NET.MapType.GoogleMap;

            Redraw();
        }
        /// <summary>
        /// Update the progress bar so the user knows how far along the calculations are.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        /// <summary>
        /// Let the user know the algorithm is complete by updating the progress label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProgress.Text = "Done calculating Shortest Paths";
        }
        /// <summary>
        /// The graph object that contains the tracks and calculates the shortest paths
        /// </summary>
        private Graph graph;
        /// <summary>
        /// Run the Floyd-Warshall algorithm in the background.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            graph.FloydWarshall(bgWorker);
        }
        /* This section is for drawing the tracks */
        private Single _Zoom = 1.0f;
        private void Redraw()
        {
            try
            {
                if (trackControl.Tracks == null)
                    trackControl.Tracks = graph.Tracks;
                trackControl.SetPointsOfInterest(graph.Waypoints);
                trackControl.CacheDate = new DateTime(2000, 1, 1);


                //which points to show
                trackControl.ShowAllPointsOfSegment = true;
                trackControl.IndexOfFirstPointShown = 1;
                trackControl.IndexOfLastPointShown = int.MaxValue;

                trackControl.Draw();
            }
            catch (Exception ex)
            {
                Utils.HandleException(ex);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Redraw();
        }

        private void cbxEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bgWorker.IsBusy) // make sure the Floyd-Warshall algorithm has finished running
                bxShortest.Text = string.Format("{0:F2} km", graph.Distance((Vertex)cbxStart.SelectedValue, (Vertex)cbxEnd.SelectedValue) / 1000.0);
        }
    }
}
