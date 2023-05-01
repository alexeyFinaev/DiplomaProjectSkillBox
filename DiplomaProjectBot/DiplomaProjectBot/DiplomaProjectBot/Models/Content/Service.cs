using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProjectBot.Models.Content
{
    class Service
    {
        public int Id { get; set; }

        /// <summary>
        /// название услуги
        /// </summary>
        public string NameService { get; set; }

        /// <summary>
        /// описание
        /// </summary>
        public string Text { get; set; }
    }
}
