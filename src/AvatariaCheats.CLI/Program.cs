using System.Drawing;
using System.Runtime.InteropServices;
using AvatariaCheats.CLI;
using Point = AvatariaCheats.CLI.Point;
using Size = Avalonia.Size;

var keyInvoker = new KeyInvoker();
var obs = new ColorObserver();

var point1 = new Point(){ X = 751, Y = 870 };
var point2 = new Point(){ X = 880, Y = 878 };
var point3 = new Point(){ X = 1027, Y = 850 };
var point4 = new Point(){ X = 1205, Y = 865 };

var t1 = Task.Run(() =>
{
    while (true)
    {
        var point = point1;
    
        if (obs.GetPixelColor(point.X, point.Y).Any(IsArrowColor))
        {
            keyInvoker.Invoke(Keys.A);
            Task.Delay(30).GetAwaiter().GetResult();
        }
    }
});

var t2 = Task.Run(() =>
{
    while (true)
    {
        var point = point2;
    
        if (obs.GetPixelColor(point.X, point.Y).Any(IsArrowColor))
        {
            keyInvoker.Invoke(Keys.A);
            Task.Delay(30).GetAwaiter().GetResult();
        }
    }
});

var t3 = Task.Run(() =>
{
    while (true)
    {
        var point = point3;
    
        if (obs.GetPixelColor(point.X, point.Y).Any(IsArrowColor))
        {
            keyInvoker.Invoke(Keys.A);
            Task.Delay(30).GetAwaiter().GetResult();
        }
    }
});

var t4 =Task.Run(() =>
{
    while (true)
    {
        var point = point4;
    
        if (obs.GetPixelColor(point.X, point.Y).Any(IsArrowColor))
        {
            keyInvoker.Invoke(Keys.A);
            Task.Delay(30).GetAwaiter().GetResult();
        }
    }
});

Task.WhenAll(t1, t2, t3, t4).GetAwaiter().GetResult();

bool IsArrowColor(Color color)
{
    var isR = color.R == 1 || color.R < 21;
    var isG = color.G == 237 || (color.G < 255 && color.G > 217); 
    var isB = color.B == 233 || (color.B < 253 && color.B > 213);

    return isR && isG && isB;
}

static class DisplayTools
{
    [DllImport("gdi32.dll")]
    static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

    private enum DeviceCap
    {
        Desktopvertres = 117,
        Desktophorzres = 118
    }

    public static Size GetPhysicalDisplaySize()
    {
        Graphics g = Graphics.FromHwnd(IntPtr.Zero);
        IntPtr desktop = g.GetHdc();

        int physicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.Desktopvertres);
        int physicalScreenWidth = GetDeviceCaps(desktop, (int)DeviceCap.Desktophorzres);

        return new Size(physicalScreenWidth, physicalScreenHeight);
    }
}