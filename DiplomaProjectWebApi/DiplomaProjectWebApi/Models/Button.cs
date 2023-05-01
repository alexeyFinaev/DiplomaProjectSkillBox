using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProjectWebApi.Models
{
    public class Button
    {
        [Key]
        public string Name{ get;set;}

        /// <summary>
        /// Название кнопки управления
        /// </summary>
        public string ButtonName { get; set; }
  
    }
}
