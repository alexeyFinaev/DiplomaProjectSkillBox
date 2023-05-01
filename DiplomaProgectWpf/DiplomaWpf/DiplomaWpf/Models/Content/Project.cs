using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DiplomaWpf.Models.Content
{
    public class Project
    {
        public int Id { get; set; }

        /// <summary>
        /// заголовок
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// изображение
        /// </summary>
        public byte[] Picture { get; set; }


       
    }
}
