using DiplomaWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IMainPresenter
    {
        /// <summary>
        /// свойства
        /// </summary>
        string Text1 { get; set; }
        string Text2 { get; set; }
        string TextButton { get; set; }
        string Text3 { get; set; }

        /// <summary>
        /// отображение вкладки "Главная"
        /// </summary>
        void MainVisability();

        /// <summary>
        /// получение текста для текстовых блоков главной страницы
        /// </summary>
        /// <returns></returns>
        void GetContent();

        /// <summary>
        /// отображает текстбоксы для редактирования
        /// </summary>
        void ViewTextBlockMainGrid();
        

        /// <summary>
        /// изменение контента на странице
        /// </summary>
        void UpdateContent();
       
        
    }
}
