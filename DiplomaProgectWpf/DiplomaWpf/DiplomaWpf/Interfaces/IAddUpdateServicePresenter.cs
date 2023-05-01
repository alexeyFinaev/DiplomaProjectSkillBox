using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IAddUpdateServicePresenter
    {
        /// <summary>
        /// поле Id
        /// </summary>
        int IdService { get; }

        /// <summary>
        /// название услуги
        /// </summary>
        string NameService { get; set; }

        /// <summary>
        /// описание услуги
        /// </summary>
        string DescriptionService { get; set; }

        /// <summary>
        /// добавление услуги
        /// </summary>
        /// <param name="service"></param>
        void InvokeAddService(IServicePresenter presenter);

        /// <summary>
        /// изменение услуги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        void InvokeUpdateService(IServicePresenter presenter);

       
    }
}
