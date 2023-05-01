using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProjectBot.Models.Content
{
    class Project
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
