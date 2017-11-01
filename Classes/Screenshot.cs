using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Classes
{
    public static class Screenshot
    {
        internal static void CaptureScreen(string filepath)
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap screen = new Bitmap(bounds.Width, bounds.Height))
            using (Graphics g = Graphics.FromImage(screen))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                screen.Save(filepath, ImageFormat.Jpeg);
            }
        }
        internal static void CaptureWindow(Rectangle bounds, string filepath)
        {
            using (Bitmap screen = new Bitmap(bounds.Width, bounds.Height))
            using (Graphics g = Graphics.FromImage(screen))
            {
                g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                screen.Save(filepath, ImageFormat.Jpeg);
            }
        }
    }
}
