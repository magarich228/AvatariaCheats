﻿using System.Drawing;

namespace AvatariaCheats.CLI;

public class Point
{
    public int X { get; init; }
    public int Y { get; init; }
}

public class ColorObserver()
{
    public bool GetPixelColor(int x, int y)
    {
        Rectangle captureRectangle = new Rectangle(x, y, 10, 10);

        using Bitmap bitmap = new Bitmap(captureRectangle.Width, captureRectangle.Height);
        
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.CopyFromScreen(captureRectangle.Location, new System.Drawing.Point(), captureRectangle.Size);
        }
        
        for (int by = 0; by < bitmap.Height; by++)
        {
            for (int bx = 0; bx < bitmap.Width; bx++)
            {
                Color pixelColor = bitmap.GetPixel(bx, by);

                if (IsArrowColor(pixelColor))
                    return true;
            }
        }

        return false;
    }
    
    bool IsArrowColor(Color color)
    {
        var isR = color.R == 1 || color.R < 21;
        var isG = color.G == 237 || (color.G < 255 && color.G > 217); 
        var isB = color.B == 233 || (color.B < 253 && color.B > 213);

        return isR && isG && isB;
    }
}