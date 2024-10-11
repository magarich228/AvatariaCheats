using System.Drawing;
using System.Runtime.InteropServices;

namespace AvatariaCheats.CLI;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class ColorObserver()
{
    // private readonly Point[] _points = points;
    
    public Color[] GetPixelColor(int x, int y)
    {
        // Получаем контекст устройства экрана
        IntPtr hdc = GetDC(IntPtr.Zero);
        Color color = Color.Empty;

        try
        {
            // Создаем битмап для получения цвета
            using (Bitmap bmp = new Bitmap(12, 1))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(x, y, 0, 0, bmp.Size);
                }
                color = bmp.GetPixel(0, 0);
                var color1 = bmp.GetPixel(1, 0);
                var color2 = bmp.GetPixel(2, 0);
                var color3 = bmp.GetPixel(3, 0);
                var color4 = bmp.GetPixel(4, 0);
                var color5 = bmp.GetPixel(5, 0);
                var color6 = bmp.GetPixel(6, 0);
                var color7 = bmp.GetPixel(7, 0);
                var color8 = bmp.GetPixel(8, 0);
                var color9 = bmp.GetPixel(9, 0);
                var color10 = bmp.GetPixel(10, 0);

                return new[] {color, color1, color2, color3, color4, color5, color6, color7, color8, color9, color10};
            }
        }
        finally
        {
            // Освобождаем контекст устройства
            ReleaseDC(IntPtr.Zero, hdc);
        }
    }
    
    // Импортируем функцию для получения DC (Device Context) экрана
    [DllImport("user32.dll")]
    private static extern IntPtr GetDC(IntPtr hWnd);

    // Импортируем функцию для освобождения DC
    [DllImport("user32.dll")]
    private static extern void ReleaseDC(IntPtr hWnd, IntPtr hDC);
}