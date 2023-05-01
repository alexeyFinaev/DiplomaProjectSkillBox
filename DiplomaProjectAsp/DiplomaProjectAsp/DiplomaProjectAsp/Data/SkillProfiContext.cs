using DiplomaProjectAsp.Interfaces;
using DiplomaProjectAsp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;

namespace DiplomaProjectAsp.Data
{
    public class SkillProfiContext:ISkillProfiContext
    {

        private HttpClient Client()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => { return true; };

            clientHandler.SslProtocols = SslProtocols.None;

            return new HttpClient(clientHandler);
        }

        private readonly string url = @"https://localhost:44346/api/values";


        #region Элементы навигации
        /// <summary>
        /// метод получения списка с названиями элементов навигации
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Button> GetButtons()
        {
            //получаем json файл в виде строки
            var json = Client().GetStringAsync(url).Result;

            //возвращаем объект из полученой строки
            return JsonConvert.DeserializeObject<IEnumerable<Button>>(json);
        }

        /// <summary>
        /// метод изменнения  названия элемента навигации 
        /// </summary>
        public void UpdateButton(string buttonName, string newName)
        {
            //отправляем пустой post-запрос 
            Client().PostAsync(requestUri: $"{url}/updatebutton/buttonName/{buttonName}/newName/{newName}",
               content: new StringContent(""));
        }

        #endregion

        #region текст главной страницы

        /// <summary>
        /// метод получения текста главной страницы
        /// </summary>
        /// <returns></returns>
         public TextHome GetTextHome()
        {
            var json = Client().GetStringAsync($"{url}/gettext").Result;

            return JsonConvert.DeserializeObject<TextHome>(json);
        }

        /// <summary>
        /// метод изменения текста главной страницы
        /// </summary>
        /// <param name="home"></param>
        public void UpdateTextHome(TextHome home)
        {
            Client().PostAsync(requestUri: $"{url}/updatetext", content:
                new StringContent(JsonConvert.SerializeObject(home), Encoding.UTF8,
                mediaType: "application/json"));
        }

        #endregion

        #region Методы работы с призывами к действию

        /// <summary>
        /// список с призывами к действию
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CallToAction> GetCallToActions()
        {
            var json = Client().GetStringAsync($"{url}/getcalltoactions").Result;

            return JsonConvert.DeserializeObject<IEnumerable<CallToAction>>(json);
        }

        /// <summary>
        /// добавить запись с призывом
        /// </summary>
        /// <param name="action"></param>
        public void AddCallToAction(CallToAction action)
        {
            Client().PostAsync(requestUri: $"{url}/addcalltoaction",
                content: new StringContent(JsonConvert.SerializeObject(action), Encoding.UTF8,
                mediaType: "application/json"));
        }

        /// <summary>
        /// удалить запись с призывом
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCallToAction(int id)
        {
            Client().PostAsync(requestUri: $"{url}/deletecaltoaction/id/{id}",
                content: new StringContent(""));
        }

        /// <summary>
        /// Получаем случайный текст
        /// </summary>
        /// <returns></returns>
        public string RandText()
        {
            //создаем список с призывами к действию
            var list = new List<string>();

            //заполняем список
            foreach(var e in GetCallToActions())
            {
                list.Add(e.Text);
            }

            if (list.Count != 0)
            {
                Random rnd = new Random();

                //создаем случайное число
                int i = rnd.Next(0, list.Count);

                //возвращаем элемент со случайным индексом 
                return list[i];
            }
            return "";
            
        }

        /// <summary>
        /// метод добавления заявки
        /// </summary>
        /// <param name="proposal"></param>
        public void AddProposal(Proposal proposal)
        {
            Client().PostAsync(requestUri: $"{url}/addproposal", content:
                new StringContent(JsonConvert.SerializeObject(proposal), Encoding.UTF8,
                mediaType: "application/json"));
        }

        #endregion

        #region Проекты

        /// <summary>
        /// список с проектами
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetProjects()
        {
            var json = Client().GetStringAsync($"{url}/getprojects").Result;

            return JsonConvert.DeserializeObject<IEnumerable<Project>>(json);
        }

        /// <summary>
        /// Добавить запись в список проектов
        /// </summary>
        /// <param name="project"></param>
        public void AddProject(Project project)
        {
            Client().PostAsync(requestUri: $"{url}/addproject",
                content: new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8,
                mediaType: "application/json"));
        }

        /// <summary>
        /// изменить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        public void UpdateProject(int id, Project project)
        {
            Client().PostAsync(requestUri: $"{url}/updateproject/id/{id}",
                content: new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8,
                mediaType: "application/json"));
        }

        /// <summary>
        /// удалить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProject(int id)
        {
            Client().PostAsync(requestUri: $"{url}/deleteproject/id/{id}",
                content: new StringContent(""));
        }

        #endregion

        #region Услуги

        /// <summary>
        /// метод получения списка услуг
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Service> GetServices()
        {
            var json = Client().GetStringAsync($"{url}/getservices").Result;

            return JsonConvert.DeserializeObject<IEnumerable<Service>>(json);
        }

        /// <summary>
        /// Метод добавления услуги
        /// </summary>
        /// <param name="service"></param>
        public void AddService(Service service)
        {
            Client().PostAsync(requestUri: $"{url}/addservise", content:
                new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8,
                mediaType: "application/json"));
        }

        /// <summary>
        /// Метод изменения услуги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        public void UpdateService(int id, Service service)
        {
            Client().PostAsync(requestUri: $"{url}/updateservise/id/{id}", content:
                new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8,
                mediaType: "application/json"));
        }

        /// <summary>
        /// Метод удаления записи в услугах
        /// </summary>
        /// <param name="id"></param>
        public void DeleteService(int id)
        {
            Client().PostAsync(requestUri: $"{url}/deleteservice/id/{id}", content:
                new StringContent(""));
                
        }

        #endregion

        #region Блог

        /// <summary>
        /// метод получения списка блогов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Blog> GetBlogs()
        {
            var json = Client().GetStringAsync($"{url}/getblogs").Result;

            return JsonConvert.DeserializeObject<IEnumerable<Blog>>(json);
        }

        /// <summary>
        /// метод добавления блога
        /// </summary>
        /// <param name="blog"></param>
        public void AddBlog(Blog blog)
        {
            Client().PostAsync(requestUri: $"{url}/addblog",
                content: new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8,
                mediaType: "application/json"));
        }

        /// <summary>
        /// метод изменения блога
        /// </summary>
        /// <param name="id"></param>
        public void UpdateBlog(int id, Blog blog)
        {
            Client().PostAsync(requestUri: $"{url}/deleteblog/{id}",
                content: new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8,
                mediaType: "application/json"));
        }

        /// <summary>
        /// метод удаления блога
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBlog(int id)
        {
            Client().PostAsync(requestUri: $"{url}/deleteblog/{id}",
                content: new StringContent(""));
        }

        #endregion

        #region Контакты

        /// <summary>
        /// Метод получения списка контактов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetContacts()
        {
            var json = Client().GetStringAsync($"{url}/getcontacts").Result;

            return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);
        }

        /// <summary>
        /// добавить контакт
        /// </summary>
        public void AddContact(Contact contact)
        {
            Client().PostAsync(requestUri: $"{url}/addcontact",
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json"));
        }

        /// <summary>
        /// удалить контакт
        /// </summary>
        public void DeletelContact(int id)
        {
            Client().PostAsync(requestUri: $"{url}/deletecontact/id/{id}",
                content: new StringContent(""));
        }

        #endregion
    }
}
