using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProjectAsp.Models
{
    public class Blog
    {
        public int Id { get; set; }

        /// <summary>
        /// заголовок
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// изображение
        /// </summary>
        public byte[] Picture { get; set; }

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
