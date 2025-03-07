using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public static class CaptchaGenerator
{
    private static readonly Random random = new Random();

    public static void GenerateImage(string text, Stream outputStream)
    {
        using (var bitmap = new Bitmap(120, 50))
        using (var graphics = Graphics.FromImage(bitmap))
        using (var font = new Font("Arial", 24, FontStyle.Bold))
        {
            graphics.Clear(Color.LightGray);

            // Рисуем шум
            for (int i = 0; i < 15; i++)
            {
                int x1 = random.Next(120);
                int y1 = random.Next(50);
                int x2 = random.Next(120);
                int y2 = random.Next(50);
                graphics.DrawLine(Pens.Gray, x1, y1, x2, y2);
            }

            // Рисуем текст с небольшим поворотом
            var textFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            var rect = new Rectangle(0, 0, 120, 50);
            graphics.RotateTransform(random.Next(-10, 10)); // Случайный угол наклона
            graphics.DrawString(text, font, Brushes.Black, rect, textFormat);
            graphics.ResetTransform();

            bitmap.Save(outputStream, ImageFormat.Png);
        }
    }
}
