using DiplomaWpf.Models.Content;
using DiplomaWpf.Presenters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IServicePresenter
    {
        /// <summary>
        /// переменная для хранения списка услуг
        /// </summary>
        ObservableCollection<Service> ServiceList { get; set; }

        /// <summary>
        /// презентер изменения-удаления услги
        /// </summary>
        IAddUpdateServicePresenter AddUpdateServicePresenter { get; set; }

        /// <summary>
        /// получение данных из контекста
        /// </summary>
        void GetServices();

        /// <summary>
        /// изменение услуги
        /// </summary>
        void InvokeUpdateService(MainWindow view,Service service);

        /// <summary>
        /// удаление услуги
        /// </summary>
        void InvokeDeleteService(int id,IServicePresenter presenter);

        /// <summary>
        /// добавление услуги
        /// </summary>
        void InvokeAddService();

        /// <summary>
        /// отображение окна со списком услуг
        /// </summary>
        void ServiceVisability();
        

    }
}
