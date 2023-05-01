using DiplomaProjectWebApi.Context;
using DiplomaProjectWebApi.Interface;
using DiplomaProjectWebApi.Models;
using DiplomaProjectWebApi.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProjectWebApi.Data
{
    public class SkillProfiContext : ISkillProfiContext
    {
        private readonly ApplicationContext context;

        public SkillProfiContext(ApplicationContext Context)
        {
            context = Context;
        }

        readonly IBaseContext baseContext = new BaseContext();

        private readonly string buttonJson = @"~/../Json/buttons.json";
        private readonly string textJson = @"~/../Json/textHome.json";

        #region Элементы навигации
        /// <summary>
        /// метод получения списка с названиями элементов навигации
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Button> GetButtons()
        {
            //возвращаем список
            return baseContext.ReadButtonJson(buttonJson);
        }

        /// <summary>
        /// метод изменнения названия элемента навигации 
        /// </summary>
        public void UpdateButton(string buttonName, string newName)
        {
            //пoлучаем список эл-тов управления 
            var list = new List<Button>( baseContext.ReadButtonJson(buttonJson));

            //находим эл-т по названию и меняем значения
            list.Where(w => w.ButtonName == buttonName).FirstOrDefault().ButtonName = newName;

            //сoхраняеи изменения
            baseContext.SaveButtonJson(list, buttonJson);
        }

       #endregion
        
        #region текст главной страницы
        /// <summary>
        /// метод получения
        /// </summary>
        /// <returns></returns>
        public TextHome GetTextHome()
        {
            return baseContext.ReadTextHomeJson(textJson);
        }

        /// <summary>
        /// метод изменения текста главной страницы
        /// </summary>
        /// <param name="home"></param>
        public void UpdateTextHome(TextHome home)
        {
            //получаем данные на главной странице
            var e = GetTextHome();

            //меняем данные
            e.Text_1 = home.Text_1;
            e.Text_2 = home.Text_2;
            e.TextButton = home.TextButton;
            e.Text_3 = home.Text_3;

            //сохраняем изменения
            baseContext.SaveTextHomeJson(e, textJson);

        }

        #endregion

        #region Методы работы со списоком призывов к действию

        /// <summary>
        /// список с призывами к действию
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CallToAction> GetCallToActions()
        {
            return context.CallToActions;
        }

        /// <summary>
        /// добавить запись с пизывом
        /// </summary>
        /// <param name="action"></param>
        public void AddCallToAction(CallToAction action)
        {
            //добавляем запись
            context.CallToActions.Add(action);

            //сохраняем изменения
            context.SaveChanges();
        }

        /// <summary>
        /// удалить запись с призывом
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCallToAction(int id)
        {
            //находим и удаляем элемент по id
            context.CallToActions.Remove(context.CallToActions.Where(w => w.Id == id).FirstOrDefault());

            //сохраняем изменения
            context.SaveChanges();
        }

        #endregion

        #region Заявки

        /// <summary>
        /// показать список заявок
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Proposal> GetProposals()
        {
            return context.Proposals;
        }

        /// <summary>
        /// показать список заявок за выбранный период
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<Proposal>GetDateProposals(DateTime startDate,DateTime endDate)
        {
            //возвращаем список за выбранный период
            return GetProposals().Where(w => w.Data >= startDate && w.Data <= endDate);  
        }

        /// <summary>
        /// добавить заявку
        /// </summary>
        /// <param name="proposal"></param>
        public void AddProposal(Proposal proposal)
        {
            //добавляем заявку
            context.Proposals.Add(proposal);

            //сохраняем изменения
            context.SaveChanges();
        }

        /// <summary>
        /// показать список заявок определенного статуса
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public IEnumerable<Proposal>GetProposalsStatus(string status)
        {
            return context.Proposals.Where(w => w.Status == status);
        }

        /// <summary>
        /// изменение статуса заявки
        /// </summary>
        /// <param name="proposal"></param>
        public void UpdateProposal(int id, string status)
        {
            //находим эл-т по id
            var proposal = context.Proposals.Where(w => w.Id == id).FirstOrDefault();

            //меняем статус
            proposal.Status = status;

            //сохраняем изменения
            context.SaveChanges();
        }

         #endregion

        #region Проекты

        /// <summary>
        /// список с проектами
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetProjects()
        {
            return context.Projects;
        }

        /// <summary>
        /// Добавить запись в список проектов
        /// </summary>
        /// <param name="project"></param>
        public void AddProject(Project project)
        {
            //добавляем запись
            context.Projects.Add(project);

            //сохраняем изменения
            context.SaveChanges();
        }

        /// <summary>
        /// изменить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        public void UpdateProject(int id, Project project)
        {
            //получаем нужную запись по id
            var p = context.Projects.Where(w => w.Id == id).FirstOrDefault();

            //меняем значения
            p.Picture = project.Picture;

            p.Header = project.Header;

            p.Text = project.Text;

            //сохраняем изменения
            context.SaveChanges();
        }

        /// <summary>
        /// удалить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProject(int id)
        {
            //находим и удаляем запись
            context.Projects.Remove(context.Projects.Where(w => w.Id == id).FirstOrDefault());

            //сохраняем изменения
            context.SaveChanges();
        }

        #endregion

        #region Услуги

        /// <summary>
        /// метод получения списка услуг
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Service> GetServices()
        {
            //возвращаем список услуг
            return context.Services;
        }

        /// <summary>
        /// Метод добавления услуги
        /// </summary>
        /// <param name="service"></param>
        public void AddService(Service service)
        {
            context.Services.Add(service);

            context.SaveChanges();
        }

        /// <summary>
        /// Метод изменения услуги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        public void UpdateService(int id, Service service)
        {
            //находим элемент из списка по id
            var s=context.Services.Where(w => w.Id == id).FirstOrDefault();

            //меняем значения
            s.NameService = service.NameService;
            s.Text = service.Text;

            //сохраняем изменения
            context.SaveChanges();
        }

        /// <summary>
        /// Метод удаления записи в услугах
        /// </summary>
        /// <param name="id"></param>
        public void DeleteService(int id)
        {
            //находим и удаляем эл-т по Id
            context.Services.Remove(context.Services.Where(w => w.Id == id).FirstOrDefault());

            //сохраняем изменения
            context.SaveChanges();
        }

        #endregion

        #region Блог
        /// <summary>
        /// метод получения списка блогов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Blog> GetBlogs()
        {
            return context.Blogs;
        }

        /// <summary>
        /// метод добавления блога
        /// </summary>
        /// <param name="blog"></param>
        public void AddBlog(Blog blog)
        {
            context.Blogs.Add(blog);

            context.SaveChanges();
        }

        /// <summary>
        /// метод изменения блога
        /// </summary>
        /// <param name="id"></param>
        public void UpdateBlog(int id, Blog blog)
        {
            //получаем блог из списка блогов по id
            var b = context.Blogs.Where(w => w.Id == id).FirstOrDefault();

            //изменяем запись
            b.Date = blog.Date;
            b.Header = blog.Header;
            b.Description = blog.Description;
            b.Picture = blog.Picture;

            //сохраняем изменения
            context.SaveChanges();
        }

        /// <summary>
        /// метод удаления блога
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBlog(int id)
        {
            //удаляем блог по id
            context.Blogs.Remove(context.Blogs.Where(w => w.Id == id).FirstOrDefault());

            //сохраняем изменения
            context.SaveChanges();
        }

        #endregion

        #region Контакты

        /// <summary>
        /// Метод получения списка контактов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetContacts()
        {
            return context.Contacts;
        }

        /// <summary>
        /// изменение контакта
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        public void UpdateContact(int id,Contact contact)
        {
            //находим контакт по id
            var item = context.Contacts.Where(w => w.Id == id).FirstOrDefault();

            //меняем контакт
            item.Text = contact.Text;
            item.Picture = contact.Picture;
            item.WhatsAppText = contact.WhatsAppText;
            item.InstaText = contact.InstaText;
            item.TwitterText = contact.TwitterText;
            item.YoutobeText = contact.YoutobeText;
            item.FaceBookText = contact.FaceBookText;

            //сщхраняем изменения
            context.SaveChanges();
        }
        #endregion

        #region Авторизация

        /// <summary>
        /// добавить пользователя
        /// </summary>
        /// <param name="autorization"></param>
        public void AddUser(Autorization autorization)
        {
            context.Add(autorization);

            context.SaveChanges();
        }

        /// <summary>
        /// проверка пользователя
        /// </summary>
        /// <param name="autorization"></param>
        /// <returns></returns>
        public bool CheckUser(string login,string password)
        {
            bool b = false;

            IEnumerable<Autorization> userList = context.Autorizations;//получаем список

            var user= userList.Where(w => w.Login == login).FirstOrDefault();//находим пользователя с данным логином

            if (user != null)
            {
                if (user.Password == password)
                {
                    b = true;
                }
            }

            return b;
        }

        #endregion

    }
}
