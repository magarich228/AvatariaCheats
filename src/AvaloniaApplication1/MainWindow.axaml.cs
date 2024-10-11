using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DrawPoint(700, 800); // Координаты точки
        DrawPoint(850, 800); // Координаты точки
        DrawPoint(1000, 800); // Координаты точки
        DrawPoint(1150, 800); // Координаты точки
        
        
        DrawPoint(1900, 1000); // Координаты точки
        
        
    }

    private void DrawPoint(double x, double y)
    {
        // Создаем круг для представления точки
        var point = new Ellipse
        {
            Width = 5,
            Height = 5,
            Fill = Brushes.Red // Цвет точки
        };

        // Устанавливаем позицию точки на Canvas
        Canvas.SetLeft(point, x);
        Canvas.SetTop(point, y);

        // Добавляем точку на Canvas
        Canvas.Children.Add(point);
    }
}