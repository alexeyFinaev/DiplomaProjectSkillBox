using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Threading;

namespace DiplomaWpf.Presenters
{
    class AddUpdateServicePresenter : IAddUpdateServicePresenter, INotifyPropertyChanged
    {
        /// <summary>
        /// поля
        /// </summary>
        private int id;
        private string nameService;
        private string descriptionService;
        ISkillProfiContext context;
        MainWindow view;

        /// <summary>
        /// свойства
        /// </summary>
        public int IdService
        {
            get { return id; }
            set { id = value; OnPropertyChanged("IdService"); }
        }
        public string NameService
        {
            get { return nameService; }
            set { nameService = value;OnPropertyChanged("NameService"); }
        }
        public string DescriptionService
        {
            get { return descriptionService; }
            set { descriptionService = value;OnPropertyChanged("DescriptionService"); }
        }

        /// <summary>
        /// конструктор
        /// </summary>
        public AddUpdateServicePresenter(MainWindow view)
        {
            context = new SkillProfiContext();
            this.view = view;
            IdService = default;
            NameService = default;
            DescriptionService = default;
            view.serviceAddUpdateGrid.DataContext = this;
        }
        public AddUpdateServicePresenter(MainWindow view,Service service)
        {
            context = new SkillProfiContext();
            this.view = view;
            IdService = service.Id;
            NameService = service.NameService;
            DescriptionService = service.Text;
            view.serviceAddUpdateGrid.DataContext = this;

        }

        /// <summary>
        /// добавление услуги
        /// </summary>
        /// <param name="service"></param>
        public void InvokeAddService(IServicePresenter presenter)
        {

            //создаем экземпляр класса Service
            var service = new Service() { NameService = this.NameService, Text = this.DescriptionService };

            //обновляем данные и закрываем окно
            StatusResult.Invoke(context.AddService(service), () => {
                presenter.GetServices();
                view.serviceAddSave.Visibility = Visibility.Collapsed;
                presenter.ServiceVisability();
            });
        }

        /// <summary>
        /// изменение услуги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        public void InvokeUpdateService(IServicePresenter presenter)
        {
            //создаем экземпляр класса Service
            var service = new Service() { NameService = this.NameService, Text = this.DescriptionService };

            //обновляем данные и закрываем окно
            StatusResult.Invoke(context.UpdateService(IdService,service), () => {presenter.GetServices();
                view.serviceUpdateSave.Visibility = Visibility.Collapsed; presenter.ServiceVisability();

            });

        }

       

        /// <summary>
        /// реализация интерфейса INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop)); 
        }


        
    }
}
