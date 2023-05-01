using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DiplomaWpf
{
    /// <summary>
    /// класс представляет конвертацию массива байт в картинку
    /// </summary>
    public class Base64Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream((byte[])value);
                bitmap.EndInit();
                return bitmap;
            }
            else { return null; }

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public ImageSource Convert(byte[] array)
        {
            var bitmap = new BitmapImage();

            var ms = new MemoryStream(array);

            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            return bitmap;

        }

        public byte[] ConvertBack(string path)
        {
            return File.ReadAllBytes(path);
        }
    }



}
