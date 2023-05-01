using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaWpf.Models.Content
{
    public class Blog
    {
        public int Id{ get; set; }

        /// <summary>
        /// изображение
        /// </summary>
        public byte[] Picture { get; set; }

        /// <summary>
        /// заголовок
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// дата публикации
        /// </summary>
        public DateTime Date { get; set; }

        
    }
}
