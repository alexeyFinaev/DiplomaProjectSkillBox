using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface INavigateButtonsPresenter
    {

        /// <summary>
        /// открывает окно изменения названия кнопки навигации
        /// </summary>
        /// <param name="navigate"></param>
        void ViewUpdateButtonNavigationName(NewNameButtonNavigate navigate);

        /// <summary>
        ///метод получения названий кнопок
        /// </summary>
        void GetButtonsName();
  
    }
}
