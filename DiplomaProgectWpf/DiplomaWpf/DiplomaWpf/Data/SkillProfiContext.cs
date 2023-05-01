using DiplomaWpf.Interfaces;
using DiplomaWpf.Models;
using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Linq;
using Newtonsoft.Json;


namespace DiplomaWpf.Data
{
    class SkillProfiContext:ISkillProfiContext
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
        public string UpdateButton(string buttonName, string newName)
        {
            //отправляем пустой post-запрос 
            return Client().PostAsync(requestUri: $"{url}/updatebutton/buttonName/{buttonName}/newName/{newName}",
               content: new StringContent("")).Result.ToString();
        }

        #endregion

        #region Методы работы со списоком призывов к действию

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
        public string AddCallToAction(CallToAction action)
        {
           return Client().PostAsync(requestUri: $"{url}/addcalltoaction",
                content: new StringContent(JsonConvert.SerializeObject(action), Encoding.UTF8,
                mediaType: "application/json")).Result.ToString();
        }

        /// <summary>
        /// удалить запись с призывом
        /// </summary>
        /// <param name="id"></param>
        public string DeleteCallToAction(int id)
        {
            return Client().PostAsync(requestUri: $"{url}/deletecaltoaction/id/{id}",
                content: new StringContent("")).Result.ToString();
        }

        #endregion

        #region текст главной страницы

        /// <summary>
        /// метод получения текста главной страницы
        /// </summary>
        /// <returns></returns>
        public TextHome GetTextHome()
        {
            var json = Client().GetStringAsync(requestUri: $"{url}/gettext").Result;

            return JsonConvert.DeserializeObject<TextHome>(json);
           
        }

        /// <summary>
        /// метод изменения текста главной страницы
        /// </summary>
        /// <param name="textHome"></param>
        public string UpdateTextHome(TextHome textHome)
        {
           return Client().PostAsync(requestUri: $"{url}/updatetext", content:
                new StringContent(JsonConvert.SerializeObject(textHome), Encoding.UTF8,
                mediaType: "application/json")).Result.ToString();
        }

        #endregion

        #region Заявки

        /// <summary>
        /// показать список заявок
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Proposal> GetProposals()
        {
            var json = Client().GetStringAsync($"{url}/getproposals").Result;

            return JsonConvert.DeserializeObject<IEnumerable<Proposal>>(json);
        }

        /// <summary>
        /// показать список заявок нужного статуса
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public IEnumerable<Proposal> GetProposalsStatus(string status)
        {
            var json = Client().GetStringAsync($"{url}/getproposalsstatus/status/{status}").Result;

            return JsonConvert.DeserializeObject<IEnumerable<Proposal>>(json);
        }

        /// <summary>
        /// показать список заявок за выбранный период
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<Proposal>GetDateProposals(DateTime startDate,DateTime endDate)
        {
            var proposals = Client()
                .GetStringAsync($"{url}/getdateproposals/startdate/{startDate}/enddate/{endDate}").Result;

            return JsonConvert.DeserializeObject<IEnumerable<Proposal>>(proposals);
        }

        /// <summary>
        /// изменение статуса заявки
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusId"></param>
        public string UpdateProposal(string id,string status)
        {
           return Client().PostAsync(requestUri: $"{url}/updateproposal/id/{id}/status/{status}", content:
                new StringContent("")).Result.ToString();
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
        public string AddProject(Project project)
        {
            return Client().PostAsync(requestUri: $"{url}/addproject",
                 content: new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8,
                 mediaType: "application/json")).Result.ToString();
        }

        /// <summary>
        /// изменить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        public string UpdateProject(int id, Project project)
        {
            return Client().PostAsync(requestUri: $"{url}/updateproject/id/{id}",
                  content: new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8,
                  mediaType: "application/json")).Result.ToString();


        }

        /// <summary>
        /// удалить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        public string DeleteProject(int id)
        {
             return Client().PostAsync(requestUri: $"{url}/deleteproject/id/{id}",
                content: new StringContent("")).Result.ToString();
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
        public string AddService(Service service)
        {
           return Client().PostAsync(requestUri: $"{url}/addservise", content:
                new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8,
                mediaType: "application/json")).Result.ToString();
        }

        /// <summary>
        /// Метод изменения услуги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        public string UpdateService(int id, Service service)
        {
           return Client().PostAsync(requestUri: $"{url}/updateservise/id/{id}", content:
                new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8,
                mediaType: "application/json")).Result.ToString();
        }

        /// <summary>
        /// Метод удаления записи в услугах
        /// </summary>
        /// <param name="id"></param>
        public string DeleteService(int id)
        {
           return Client().PostAsync(requestUri: $"{url}/deleteservice/id/{id}", content:
                new StringContent("")).Result.ToString();

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
        public string AddBlog(Blog blog)
        {
           return Client().PostAsync(requestUri: $"{url}/addblog",
                content: new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8,
                mediaType: "application/json")).Result.ToString();
        }

        /// <summary>
        /// метод изменения блога
        /// </summary>
        /// <param name="id"></param>
        public string UpdateBlog(int id, Blog blog)
        {
            return Client().PostAsync(requestUri: $"{url}/updateblog/{id}",
                content: new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8,
                mediaType: "application/json")).Result.ToString();

          
        }

        /// <summary>
        /// метод удаления блога
        /// </summary>
        /// <param name="id"></param>
        public string DeleteBlog(int id)
        {
           return Client().PostAsync(requestUri: $"{url}/deleteblog/{id}",
                content: new StringContent("")).Result.ToString();
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
        /// метод изменения контакта
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        public string UpdateContact(int id,Contact contact)
        {
            return Client().PostAsync(requestUri: $"{url}/updatecontact/id/{id}", content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json")).Result.ToString();
        }

        #endregion

        #region Авторизация

        public void Adduser(Autorization autorization)
        {
            Client().PostAsync(requestUri: $"{url}/adduser", content: new StringContent(JsonConvert.SerializeObject(autorization), Encoding.UTF8,
                mediaType: "application/json"));
        }

        public bool CheckUser(string login,string password)
        {
            var json=Client().GetStringAsync($"{url}/checkuser/login/{login}/password/{password}").Result;

            return JsonConvert.DeserializeObject<bool>(json);
        }

        #endregion
    }
}
