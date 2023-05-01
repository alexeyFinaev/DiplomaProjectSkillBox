using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProjectAsp.Models
{
    public class Project
    {
        public int Id { get; set; }
        /// <summary>
        /// заголовок
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// текст
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// изображение
        /// </summary>
        public byte[] Picture { get; set; }
    }
}
