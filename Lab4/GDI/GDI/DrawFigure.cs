using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace GDI
{
    class DrawFigure
    {
        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);
        static public void DrawRectangle(int x, int y, int width, int height, Color color)
        {
            SolidBrush filling = new SolidBrush(color);
            IntPtr desktop = GetDC(IntPtr.Zero);
            Graphics windowArea = Graphics.FromHdc(desktop);
            windowArea.FillRectangle(filling, x, y, width, height);
            windowArea.Dispose();
        }
        static public void DrawEllipse(int x, int y, int width, int height, Color color)
        {
            SolidBrush filling = new SolidBrush(color);
            IntPtr desktop = GetDC(IntPtr.Zero);
            Graphics windowArea = Graphics.FromHdc(desktop);
            windowArea.FillEllipse(filling, x, y, width, height);
            windowArea.Dispose();
        }
        static public void DrawTrapeze(int startX, int startY, int height, int lowerBase, int upperBase, Color color)
        {
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics windowArea = Graphics.FromHdc(desktopDC);
            Pen pen = new Pen(color, 8);
            int difference;
            if (upperBase > lowerBase)
            {
                difference = (upperBase - lowerBase) / 2;
            }
            else
            {
                difference = (lowerBase - upperBase) / 2;
            }
            windowArea.DrawLine(pen, new PointF(startX, startY), new PointF(startX + difference, startY + height));
            windowArea.DrawLine(pen, new PointF(startX + difference + lowerBase, startY + height), new PointF(startX + difference, startY + height));
            windowArea.DrawLine(pen, new PointF(startX + difference + lowerBase, startY + height), new PointF(startX + upperBase, startY));
            windowArea.DrawLine(pen, new PointF(startX, startY), new PointF(startX + upperBase, startY));
            windowArea.Dispose();
        }

        static public void DrawLine(int startX, int startY, int endX, int endY, Color color)
        {
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics windowArea = Graphics.FromHdc(desktopDC);
            Pen pen = new Pen(color, 4);
            windowArea.DrawLine(pen, new PointF(startX, startY), new PointF(endX, endY));
            windowArea.Dispose();
        }
    }
}
