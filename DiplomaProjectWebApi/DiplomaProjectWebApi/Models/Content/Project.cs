using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProjectWebApi.Models
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
