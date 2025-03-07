using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Models
{
    class Converter
    {
        public static Bitmap LoadImage(string photoFileName, string path)
        {
            string fullPath = Path.Combine(path, photoFileName);
            if (File.Exists(fullPath))
            {
                return new Bitmap(fullPath);
            }
            else
            {
                Console.WriteLine($"Изображение не найдено: {fullPath}");
                return new Bitmap("C:\\Users\\kkrok\\source\\repos\\EventApp\\EventApp\\Assets\\Модераторы_import\\foto1.jpg");
            }
        }
    }
}
