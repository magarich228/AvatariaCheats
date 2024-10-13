using AvatariaCheats.CLI;
using Point = AvatariaCheats.CLI.Point;

var keyInvoker = new KeyInvoker();
var obs = new ColorObserver();

var point1 = new Point(){ X = 751, Y = 870 };
var point2 = new Point(){ X = 900, Y = 860 };
var point3 = new Point(){ X = 1000, Y = 840 };
var point4 = new Point(){ X = 1170, Y = 870 };

var t1 = Task.Run(() =>
{
    while (true)
    {
        var point = point1;
    
        if (obs.GetPixelColor(point.X, point.Y))
        {
            keyInvoker.Invoke(Keys.A);
            Console.WriteLine($"{point.X} {point.Y} A");
            Task.Delay(100).GetAwaiter().GetResult();
        }
    }
});

var t2 = Task.Run(() =>
{
    while (true)
    {
        var point = point2;
    
        if (obs.GetPixelColor(point.X, point.Y))
        {
            keyInvoker.Invoke(Keys.S);
            Console.WriteLine($"{point.X} {point.Y} S");
            Task.Delay(100).GetAwaiter().GetResult();
        }
    }
});

var t3 = Task.Run(() =>
{
    while (true)
    {
        var point = point3;
    
        if (obs.GetPixelColor(point.X, point.Y))
        {
            keyInvoker.Invoke(Keys.W);
            Console.WriteLine($"{point.X} {point.Y} W");
            Task.Delay(100).GetAwaiter().GetResult();
        }
    }
});

var t4 = Task.Run(() =>
{
    while (true)
    {
        var point = point4;
    
        if (obs.GetPixelColor(point.X, point.Y))
        {
            keyInvoker.Invoke(Keys.D);
            Console.WriteLine($"{point.X} {point.Y} D");
            Task.Delay(100).GetAwaiter().GetResult();
        }
    }
});

Task.WhenAll(t1, t2, t3, t4).GetAwaiter().GetResult();