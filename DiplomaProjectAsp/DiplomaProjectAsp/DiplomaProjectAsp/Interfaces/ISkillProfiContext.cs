using DiplomaProjectAsp.Models;
using System.Collections.Generic;

namespace DiplomaProjectAsp.Interfaces
{
    public interface ISkillProfiContext
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
        void UpdateButton(string buttonName, string newName);

        /// <summary>
        /// метод добавления заявки
        /// </summary>
        /// <param name="proposal"></param>
        void AddProposal(Proposal proposal);
        #endregion

        #region текст главной страницы

        /// <summary>
        /// метод получения текста главной страницы
        /// </summary>
        /// <returns></returns>
        TextHome GetTextHome();

        /// <summary>
        /// метод изменения текста главной страницы
        /// </summary>
        /// <param name="home"></param>
        void UpdateTextHome(TextHome home);

        #endregion

        #region Главная страница

        /// <summary>
        /// список с призывами к действию
        /// </summary>
        /// <returns></returns>
        IEnumerable<CallToAction> GetCallToActions();

        /// <summary>
        /// добавить запись с призывом
        /// </summary>
        /// <param name="action"></param>
        void AddCallToAction(CallToAction action);

        /// <summary>
        /// удалить запись с призывом
        /// </summary>
        /// <param name="id"></param>
        void DeleteCallToAction(int id);

        /// <summary>
        /// Метод получения текста по случайному индексу
        /// </summary>
        /// <returns></returns>
        string RandText();

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
        void AddProject(Project project);

        /// <summary>
        /// изменить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        void UpdateProject(int id, Project project);

        /// <summary>
        /// удалить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        void DeleteProject(int id);

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
        void AddService(Service service);

        /// <summary>
        /// Метод изменения услуги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        void UpdateService(int id, Service service);

        /// <summary>
        /// Метод удаления записи в услугах
        /// </summary>
        /// <param name="id"></param>
        void DeleteService(int id);

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
        void AddBlog(Blog blog);

        /// <summary>
        /// метод изменения блога
        /// </summary>
        /// <param name="id"></param>
        void UpdateBlog(int id, Blog blog);

        /// <summary>
        /// метод удаления блога
        /// </summary>
        /// <param name="id"></param>
        void DeleteBlog(int id);

        #endregion

        #region Контакты

        /// <summary>
        /// Метод получения списка контактов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Contact> GetContacts();

        /// <summary>
        /// добавить контакт
        /// </summary>
        void AddContact(Contact contact);

        /// <summary>
        /// удалить контакт
        /// </summary>
        void DeletelContact(int id);

        #endregion
    }
}
