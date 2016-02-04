
namespace GMap.NET.Internals
{
   /// <summary>
   /// tile load task
   /// </summary>
   public struct LoadTask
   {
      public Point Pos;
      public int Zoom;

      public LoadTask(Point pos, int zoom)
      {
         Pos = pos;
         Zoom = zoom;
      }

      public override string ToString()
      {
         return Zoom + " - " + Pos.ToString();
      }
   }
}
