using AvatariaCheats.CLI;
using Microsoft.Extensions.Configuration;
using Point = AvatariaCheats.CLI.Point;

ConfigurationBuilder builder = new ConfigurationBuilder();
builder.AddJsonFile("appsettings.json", false, true);

var configuration = builder.Build();

var point1 = new Point();
var point2 = new Point();
var point3 = new Point();
var point4 = new Point();

configuration.Bind("Point1", point1);
configuration.Bind("Point2", point2);
configuration.Bind("Point3", point3);
configuration.Bind("Point4", point4);

var keyInvoker = new KeyInvoker();
var obs = new ColorObserver();

var t1 = Task.Run(() => ProcessAsync(obs, keyInvoker, point1, Keys.A));
var t2 = Task.Run(() => ProcessAsync(obs, keyInvoker, point2, Keys.S));
var t3 = Task.Run(() => ProcessAsync(obs, keyInvoker, point3, Keys.W));
var t4 = Task.Run(() => ProcessAsync(obs, keyInvoker, point4, Keys.D));

Task.WhenAll(t1, t2, t3, t4).GetAwaiter().GetResult();

static async Task ProcessAsync(ColorObserver obs, KeyInvoker keyInvoker, Point point, Keys key)
{
    while (true)
    {
        if (obs.GetPixelColor(point.X, point.Y))
        {
            keyInvoker.Invoke(key);
            
            Console.WriteLine($"{point.X} {point.Y} {key}");

            await Task.Delay(100);
        }
    }
}