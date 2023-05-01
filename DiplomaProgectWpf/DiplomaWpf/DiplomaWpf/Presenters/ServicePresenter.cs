using DiplomaWpf.Interfaces;
using DiplomaWpf.Data;
using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DiplomaWpf.Presenters
{
    class ServicePresenter:IServicePresenter,INotifyPropertyChanged
    {
        /// <summary>
        /// поля
        /// </summary>
        ObservableCollection<Service> serviceList;
        MainWindow view;
        ISkillProfiContext context;

        /// <summary>
        /// презентер для изменения-добавления услуги
        /// </summary>
        public IAddUpdateServicePresenter AddUpdateServicePresenter { get; set; }
       
        /// <summary>
        /// Свойства
        /// </summary>
        public ObservableCollection<Service> ServiceList
        {
            get => serviceList;
            set { serviceList = value; OnPropertyChanged("ServiceList"); }
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="view"></param>
        public ServicePresenter(MainWindow view)
        {
            this.view = view;
            context = new SkillProfiContext();  
            view.DataContext = this;
        }

        /// <summary>
        /// получаем список услуг
        /// </summary>
        public void GetServices()
        {
            ServiceList = new ObservableCollection<Service>(context.GetServices());
        }

        /// <summary>
        /// удаление услуги
        /// </summary>
        public void InvokeDeleteService( int id,IServicePresenter presenter)
        {
            //удаляем услугу и обновляем данные
            StatusResult.Invoke(context.DeleteService(id), () => {
                presenter.GetServices();
            });
        }

        /// <summary>
        /// добавление услуги
        /// </summary>
        public void InvokeAddService()
        {
            //инициализируем презентер
            this.AddUpdateServicePresenter = new AddUpdateServicePresenter(view);

            //включаем видимость кнопки изменения-добавления услуги
            view.serviceAddSave.Visibility = Visibility.Visible;

            //открываем окно изменения-добавления услуги
            view.serviceAddUpdateGrid.Visibility = Visibility.Visible;

        }
       
        /// <summary>
        /// изменение услуги
        /// </summary>
        public void InvokeUpdateService(MainWindow view,Service service)
        {
            //инициализируем презентер
            this.AddUpdateServicePresenter = new AddUpdateServicePresenter(view, service);
           
           
            //отображаем кнопку изменения на странице редактирования
            view.serviceUpdateSave.Visibility = Visibility.Visible;

            //отображаем окно редактирования услуги
            view.serviceAddUpdateGrid.Visibility = Visibility.Visible;

            
        }

        /// <summary>
        /// отображение окна со списком услуг
        /// </summary>
        public void ServiceVisability()
        {
            view.homeGrid.Visibility = Visibility.Collapsed;
            view.mainGrid.Visibility = Visibility.Collapsed;
            view.projectGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.serviceGrid.Visibility = Visibility.Visible;
            view.serviceAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.blogGrid.Visibility = Visibility.Collapsed;
            view.blogAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.contactsGrid.Visibility = Visibility.Collapsed;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
