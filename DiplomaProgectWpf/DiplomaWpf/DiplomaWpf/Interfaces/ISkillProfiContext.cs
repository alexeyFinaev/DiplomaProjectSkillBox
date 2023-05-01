using DiplomaWpf.Models;
using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface ISkillProfiContext
    {
        #region Элементы навигации

        /// <summary>
        /// метод получения списка с названиями элементов навигации
        /// </summary>
        /// <returns></returns>
        IEnumerable<Button> GetButtons();

        /// <summary>
        /// метод изменнения  названия элемента навигации 
        /// </summary>
        string UpdateButton(string buttonName, string newName);

        #endregion

        # region Методы работы со списоком призывов к действию

        /// <summary>
        /// список с призывами к действию
        /// </summary>
        /// <returns></returns>
        IEnumerable<CallToAction> GetCallToActions();

        /// <summary>
        /// добавить запись с призывом
        /// </summary>
        /// <param name="action"></param>
        string AddCallToAction(CallToAction action);

        /// <summary>
        /// удалить запись с призывом
        /// </summary>
        /// <param name="id"></param>
        string DeleteCallToAction(int id);

        #endregion

        #region текст главной страницы

        /// <summary>
        /// получения текста главной страницы
        /// </summary>
        /// <returns></returns>
        TextHome GetTextHome();

        /// <summary>
        /// изменения текста главной страницы
        /// </summary>
        /// <param name="home"></param>
        string UpdateTextHome(TextHome home);

        #endregion

        #region Заявки
        /// <summary>
        /// возвращает список заявок
        /// </summary>
        /// <returns></returns>
        IEnumerable<Proposal> GetProposals();

        /// <summary>
        /// возвращает список заявок за выбранный период
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        IEnumerable<Proposal> GetDateProposals(DateTime startDate, DateTime endDate);

        /// <summary>
        /// получение заявки с определенным статусом
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        IEnumerable<Proposal> GetProposalsStatus(string status);

        /// <summary>
        /// метод изменения статуса заявки
        /// </summary>
        string UpdateProposal(string id, string status);

        #endregion

        #region Проекты

        /// <summary>
        /// список с проектами
        /// </summary>
        /// <returns></returns>
        IEnumerable<Project> GetProjects();

        /// <summary>
        /// Добавить запись в список проектов
        /// </summary>
        /// <param name="project"></param>
        string AddProject(Project project);

        /// <summary>
        /// изменить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        string UpdateProject(int id, Project project);

        /// <summary>
        /// удалить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        string DeleteProject(int id);

        #endregion

        #region Услуги

        /// <summary>
        /// метод получения списка услуг
        /// </summary>
        /// <returns></returns>
        IEnumerable<Service> GetServices();

        /// <summary>
        /// Метод добавления услуги
        /// </summary>
        /// <param name="service"></param>
        string AddService(Service service);

        /// <summary>
        /// Метод изменения услуги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        string UpdateService(int id, Service service);

        /// <summary>
        /// Метод удаления записи в услугах
        /// </summary>
        /// <param name="id"></param>
        string DeleteService(int id);

        #endregion

        #region Блог

        /// <summary>
        /// метод получения списка блогов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Blog> GetBlogs();

        /// <summary>
        /// метод добавления блога
        /// </summary>
        /// <param name="blog"></param>
        string AddBlog(Blog blog);

        /// <summary>
        /// метод изменения блога
        /// </summary>
        /// <param name="id"></param>
        string UpdateBlog(int id, Blog blog);

        /// <summary>
        /// метод удаления блога
        /// </summary>
        /// <param name="id"></param>
        string DeleteBlog(int id);

        #endregion

        #region Контакты

        /// <summary>
        /// Метод получения списка контактов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Contact> GetContacts();

        /// <summary>
        /// метод изменения контакта
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        string UpdateContact(int id, Contact contact);

        #endregion

        #region Авторизация

        void Adduser(Autorization autorization);
        bool CheckUser(string login, string password);
        

        #endregion


    }
}
