using GPX;
using System;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            graph = new Graph(settings.MapFile);

            settingsBindingSource.DataSource = settings;
            bgWorker.RunWorkerAsync();

            trackControl.UseEqualScale = true;
            trackControl.Zoom = _Zoom;

            //how to show waypoints
            trackControl.DrawWaypoints = true;
            trackControl.StyleForWaypoints = WaypointsStyle.SmallCircle;
            trackControl.WayPointsColor = Color.BlanchedAlmond;
            trackControl.WayPointsHighlight = Color.Gold;

            trackControl.DrawPointsOfInterest = true;
            trackControl.StyleForPoI = WaypointsStyle.BigX;
            trackControl.PoIColor = Color.DarkGreen;

            trackControl.DrawTrackLine = true;
            trackControl.TrackThickness = 3.0f;
            trackControl.TrackColor = Color.Red;
            trackControl.TrackColorHighlight = Color.Goldenrod;

            trackControl.ShowMap = true;
            //with Maps, it is always latitude/longitude to be used for further calculation!
            trackControl.XCategory = DrawCategory.Longitude;
            trackControl.YCategory = DrawCategory.Latitude;
            //show a map?
            trackControl.MapType = GMap.NET.MapType.GoogleMap;

            Redraw();
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
    }
}
