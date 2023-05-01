using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models;
using DiplomaWpf.Models.Content;
using DiplomaWpf.Presenters;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiplomaWpf
{

    public partial class MainWindow : Window
    {
        //объявляем презентеры 
        INavigateButtonsPresenter navigateButtonsPresenter;
        IHomePresenter homePresenter;
        IMainPresenter mainPresenter;
        IProjectPresenter projectPresenter;
        IServicePresenter servicePresenter;
        IBlogPresenter blogPresenter;
        IContactPresenter contactPresenter;
        ICallToActionPresenter callToActionPresenter;
        IAutorizationPresenter autorization;



        public MainWindow()
        {
            InitializeComponent();

            autorization = new AutorizationPresenter(this);//инисиализируем презентер с авторизацией

            navigateButtonsPresenter = new NavigateButtonsPresenter(this);//инициализируем презентер


            navigateButtonsPresenter.GetButtonsName();//загружаем названия кнопок навигации

         
        }

        /// <summary>
        /// Событие изменения названия кнопоки навигации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NawigateButtonHeaderChange(object sender, RoutedEventArgs e)
        {
            //инициализируем окно изменения названия кнопки навигации
            NewNameButtonNavigate navigate = new NewNameButtonNavigate
            {
                Owner = this,

                //позиционируем положение окна
                WindowStartupLocation = WindowStartupLocation.Manual,

                Left = Mouse.GetPosition(this).X,
                Top = Mouse.GetPosition(this).Y
            };

            //изменяем название кнопки навигации
            navigateButtonsPresenter.ViewUpdateButtonNavigationName(navigate);

            //обработчик закрытия окна
            navigate.Unloaded += Navigate_Closed;

        }

        /// <summary>
        /// событие закрытия окна ввода нового названия кнопки навигации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigate_Closed(object sender, EventArgs e)
        {
            //обновляем панель с кнопками навигации
            navigateButtonsPresenter.GetButtonsName();

        }



        #region homeGrid

        /// <summary>
        /// событие нажатия на кнопку "рабочий стол"
        /// на панели навигации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DesctopButton_Click(object sender, RoutedEventArgs e)
        {
            homePresenter = new HomePresenter(this);//присваиваем значение презентеру

            homePresenter.GetProposalDataGrid();//загружаем данные в таблицу

            homePresenter.DesctopGridVisability();//открываем грид
        }

        #region кнопки выборки заявок по дате

        /// <summary>
        /// кнопка полученных заявок за сегодня
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Todey_ButtonClick(object sender, RoutedEventArgs e)
        {

            homePresenter.CalendarButtonsStart();

            homePresenter.GetDateProposals(DateTime.Today, DateTime.Now);


        }

        /// <summary>
        /// кнопка получения заявок за вчера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Yesterday_ButtonClick(object sender, RoutedEventArgs e)
        {
            homePresenter.CalendarButtonsStart();

            homePresenter.GetDateProposals(DateTime.Today.AddDays(-1), DateTime.Today);
        }

        /// <summary>
        /// кнопка получения заявок за неделю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Week_ButtonClick(object sender, RoutedEventArgs e)
        {
            homePresenter.CalendarButtonsStart();

            homePresenter.GetDateProposals(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek), DateTime.Now);
        }

        /// <summary>
        /// кнопка получения заявок за месяц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Month_ButtonClick(object sender, RoutedEventArgs e)
        {

            homePresenter.CalendarButtonsStart();

            //устанавливаем стартовую дату на начало месяца
            homePresenter.GetDateProposals(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTime.Now);
        }



        #region установка даты из календаря

        /// <summary>
        /// установка начального переода выборки заявок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeriodStart_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.GetCalendarStart();

        }

        /// <summary>
        ///  /// установка конечного переода выборки заявок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeriodEnd_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.GetCalendarEnd();
        }

        /// <summary>
        /// событие ввода начальной даты в календаре
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calendar_SelectedDatesChangedStart(object sender, SelectionChangedEventArgs e)
        {
            homePresenter.EnterCalendarPeriodStart();

        }

        /// <summary>
        /// событие ввода конечной даты в календаре
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalendarEnd_SelectedDatesChangedEnd(object sender, SelectionChangedEventArgs e)
        {
            homePresenter.EnterCalendarPeriodEnd();
        }
        #endregion

        #endregion

        #region кнопки выборки заявок по категориям

        /// <summary>
        /// выводит список со статусом "получена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReceivedButton_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.GetCategory("Получена");
        }

        /// <summary>
        /// выводит список со статусом "В работе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AtWorkButton_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.GetCategory("В работе");
        }

        /// <summary>
        /// выводит список со статусом "Выполнена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.GetCategory("Выполнена");
        }

        /// <summary>
        /// выводит список со статусом "Отменена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelledButton_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.GetCategory("Отменена");
        }

        /// <summary>
        /// выводит список со статусом "Отклонена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RejectedButton_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.GetCategory("Отклонена");
        }
        #endregion

        /// <summary>
        /// выбор элемента в списке заявок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProposalsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            homePresenter.ProposalInfoSelection(sender);

        }

        /// <summary>
        /// полная информация по выбраной заявке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClosePropoasalInfo_Click(object sender, RoutedEventArgs e)
        {
           homePresenter.ProposalInfoClose();

        }

        #region кнопки меню измения статуса

        /// <summary>
        /// получена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuReceived_Click(object sender, RoutedEventArgs e)
        {
            //меняем статус заявки
            homePresenter.ProposalStatusToChange(homePresenter.Id, StatusesProposal.Statuses[0]);


        }

        /// <summary>
        /// В работе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAtWork_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.ProposalStatusToChange(homePresenter.Id, StatusesProposal.Statuses[1]);

        }

        /// <summary>
        /// Выполнена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuDone_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.ProposalStatusToChange(homePresenter.Id, StatusesProposal.Statuses[2]);


        }

        /// <summary>
        /// Отменена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuRejected_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.ProposalStatusToChange(homePresenter.Id, StatusesProposal.Statuses[3]);


        }

        /// <summary>
        /// Отклонена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuCancelled_Click(object sender, RoutedEventArgs e)
        {
            homePresenter.ProposalStatusToChange(homePresenter.Id, StatusesProposal.Statuses[4]);

        }

        #endregion

        #endregion

        #region mainGrid

        /// <summary>
        /// кнопка редактирования текстовых блоков главной страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButtonMainGrid_Click(object sender, RoutedEventArgs e)
        {
            //включаем видимость TextBox
            mainPresenter.ViewTextBlockMainGrid();
        }

        /// <summary>
        /// кнопка сохранения отредактированных блоков главной страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButtonMainGrid_Click(object sender, RoutedEventArgs e)
        {
            //изменяем данные
            mainPresenter.UpdateContent();
        }

        /// <summary>
        /// Событие кнопки навигации "Главная"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            //иницыализируем презентер
            mainPresenter = new MainPresenter(this); 

            //получаем контент
            mainPresenter.GetContent();

            //отображаем страницу
            mainPresenter.MainVisability();
        }

        #endregion

        #region CallToActionGrid
        /// <summary>
        /// открывает страницу с призывами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallToActionVisibilityButton_Click(object sender, RoutedEventArgs e)
        {
            callToActionPresenter = new CallToActionPresenter(this);//инициализируем презентер

            callToActionPresenter.GetActionList();//получаем список

            callToActionPresenter.CallToActionVisability();//отображаем грид со списком

        }

        /// <summary>
        /// удаляет призыв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAction_Click(object sender, RoutedEventArgs e)
        {
            callToActionPresenter.RemoveAction();
        }

        /// <summary>
        /// добавляет призыв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAction_Click(object sender, RoutedEventArgs e)
        {
            callToActionPresenter.AddAction();
        }

        /// <summary>
        /// вернуться назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackAction_Click(object sender, RoutedEventArgs e)
        {
            callToActionPresenter.BackAction();
        }

        /// <summary>
        /// сохраняет новый призыв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAction_Click(object sender, RoutedEventArgs e)
        {
            callToActionPresenter.SaveAction();
        }

        /// <summary>
        /// событие при выборе элемента из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxAction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            callToActionPresenter.SelectionChanged();
        }

        #endregion

        #region projectGrid

        /// <summary>
        /// событие кнопки навигации "Проекты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectButton_Click(object sender, RoutedEventArgs e)
        {
            projectPresenter = new ProjectPresenter(this);//инициализируем презентер

            projectPresenter.GetProject();//загружаем список проектов

            projectPresenter.ProjectVisability();//отображаем список проектов
        }

        /// <summary>
        /// событие при выборе проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            projectPresenter.ProjectInfoVisabilty(sender);//отображает информацию о проекте
        }

        /// <summary>
        /// кнопка назад на странице с описанием проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectInfoBackButton_Click(object sender, RoutedEventArgs e)
        {
            projectPresenter.ProjectInfoPresenter.InvokeBack();
        }

        /// <summary>
        /// кнопка добавления проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            //открывает окно добавления проекта
            projectPresenter.AddProject();  
        }

        /// <summary>
        /// кнопка добавления и сохранения нового проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectAddSave_Click(object sender, RoutedEventArgs e)
        {
            //добавляем проект
            projectPresenter.AddUpdateProjectPresenter.AddProjectSave(projectPresenter);
        }

        /// <summary>
        /// кнопка изменения проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            //открывает окно изменения пректа
            projectPresenter.UpdateProject(sender);

        }

        /// <summary>
        /// сохранение изменений проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectUpdateSave_Click(object sender, RoutedEventArgs e)
        {
            //изменяем проект
            projectPresenter.AddUpdateProjectPresenter.UpdateProjectSave(projectPresenter);

        }

        /// <summary>
        /// кнопка добавления фото
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectAddPictire_Click(object sender, RoutedEventArgs e)
        {
            //метод добавления фото
            projectPresenter.AddUpdateProjectPresenter.OpenFileExplorer(); 
        }

        /// <summary>
        /// кнопка удаления проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProjectButton_Click(object sender, RoutedEventArgs e)
        {
            projectPresenter.DeleteProject(sender);//удаляем проект
        }



        #endregion

        #region serviceGrid

        /// <summary>
        /// открывает вкладку услуг
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceButton_Click(object sender, RoutedEventArgs e)
        {
            //присваиваем значение презентеру
            servicePresenter = new ServicePresenter(this);

            //получаем список услуг
            servicePresenter.GetServices();

            //отображаем окно со списком услуг
            servicePresenter.ServiceVisability();

        }

        /// <summary>
        /// редактирование услуги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateService_Click(object sender, RoutedEventArgs e)
        {
            //получаем данные выделенного элемента
            var item = GetContentButton.ContentButton<Service>(sender);

            //передаем данные и открываем страницу изменения услуги
            servicePresenter.InvokeUpdateService(this,item);
            
        }
        
        /// <summary>
        /// удаляет услугу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {

            //получаем элемент из списка сервисов
            var item = GetContentButton.ContentButton<Service>(sender);

            //удаляем услугу
            servicePresenter.InvokeDeleteService(item.Id,servicePresenter);

            
        }

        /// <summary>
        /// открывает окно добавления услуги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            //открываем окно добавления услуги
            servicePresenter.InvokeAddService();
        }

        /// <summary>
        /// кнопка изменения и сохранения услуги 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceUpdateSave_Click(object sender, RoutedEventArgs e)
        {
            //изменяем данные
            servicePresenter.AddUpdateServicePresenter.InvokeUpdateService(servicePresenter);

        }

        /// <summary>
        /// кнопка добавления и сохранения услуги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceAddSave_Click(object sender, RoutedEventArgs e)
        {
            //добавляем услугу
            servicePresenter.AddUpdateServicePresenter.InvokeAddService(servicePresenter);

        }
        #endregion

        #region blogGrid

        /// <summary>
        /// открывает вкладку блог
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlogButton_Click(object sender, RoutedEventArgs e)
        {
            //инициализируем презентер
            blogPresenter = new BlogPresenter(this);

            blogPresenter.GetBlogs();//получаем список постов

            blogPresenter.BlogsVisability();//включаем отображение постов
        }

        /// <summary>
        /// открывает страницу добавления поста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBlogButton_Click(object sender, RoutedEventArgs e)
        {
            blogPresenter.InvokeAddBlog();
        }

        /// <summary>
        /// открывает страницу изменения поста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBlogButton_Click(object sender, RoutedEventArgs e)
        {
            var item = GetContentButton.ContentButton<Blog>(sender);//получаем контент выбраного объекта

            blogPresenter.InvokeUpdateBlog(item);
        }

        /// <summary>
        /// кнопка удаления поста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBlogButton_Click(object sender, RoutedEventArgs e)
        {
            var item = GetContentButton.ContentButton<Blog>(sender);//получаем контент

            blogPresenter.InvokeDeleteBlog(item.Id);//удаляем пост
  
        }

        /// <summary>
        /// добавление изображения в пост
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPictureBlog_Click(object sender, RoutedEventArgs e)
        {
            blogPresenter.Presenter.AddPictureBlog();//добавляем изображение
        }

        /// <summary>
        /// кнопка изменения и сохранения поста 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlogUpdateSave_Click(object sender, RoutedEventArgs e)
        {

            blogPresenter.Presenter.InvokeUpdateBlog(blogPresenter);
        }
       
        /// <summary>
        /// кнопка добавления и сохранения поста 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlogAddSave_Click(object sender, RoutedEventArgs e)
        {
            blogPresenter.Presenter.InvokeAddBlog(blogPresenter);
        }
        #endregion

        #region contactGrid

        /// <summary>
        /// открывавет вкладку с контактами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            contactPresenter = new ContactPresenter(this);//инициализируем презентер

            contactPresenter.GetContact();//получаем контакт

            contactPresenter.VisabilityContactGrid();//отображаем грид

        }

        /// <summary>
        /// кнопка редактирования контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsEdit_Click(object sender, RoutedEventArgs e)
        {
            contactPresenter.TextBoxContactVisaility();
        }

        /// <summary>
        /// кнопка загрузки изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagUpdateContact(object sender, RoutedEventArgs e)
        {
            contactPresenter.ImageUpdate();
        }

        /// <summary>
        /// кнопка сохранения контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsSave_Click(object sender, RoutedEventArgs e)
        {
            contactPresenter.SaveUpdateContact();
        }

        /// <summary>
        /// открывает окно изменения ссылок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinksEdit_Click(object sender, RoutedEventArgs e)
        {
            contactPresenter.OpenLinksUpdate();
        }

        /// <summary>
        /// кнопка сохранения ссылок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactLinksSave_Click(object sender, RoutedEventArgs e)
        {
            contactLinksGrid.Visibility = Visibility.Collapsed;//выключаем видимость грида
        }





        #endregion


        #region autorizationGrid
        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            autorization.Entrance();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            autorization.AddUser();
        }
        #endregion

    }
}
