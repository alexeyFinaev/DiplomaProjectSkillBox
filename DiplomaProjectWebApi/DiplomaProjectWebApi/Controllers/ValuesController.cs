using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomaProjectWebApi.Data;
using DiplomaProjectWebApi.Interface;
using DiplomaProjectWebApi.Models;
using DiplomaProjectWebApi.Models.Content;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjectWebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ISkillProfiContext context;

        /// <summary>
        /// используем метод внедрения зависимости
        /// </summary>
        /// <param name="Context"></param>
        public ValuesController(ISkillProfiContext Context)
        {
            context = Context;
        }


        #region Mетоды для элементов управления

        /// <summary>
        /// метод получения спаска эл-тов управления
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Button> GetButtons()
        {
            return context.GetButtons();
        }

        /// <summary>
        /// метод изменения элемента управления
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newName"></param>
        [HttpPost]
        [Route("updatebutton/buttonName/{buttonName}/newName/{newName}")]
        public void UpdateButton(string buttonName, string newName)
        {
            context.UpdateButton(buttonName, newName);
        }

        #endregion

        #region Методы работы с текстовыми элементами  главной страницы

        /// <summary>
        /// метод получения текста главной страницы
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("gettext")]
        public ActionResult<TextHome> GetText()
        {
            return context.GetTextHome();
        }

        /// <summary>
        /// метод изменения текста главной страницы
        /// </summary>
        /// <param name="home"></param>
        [HttpPost]
        [Route("updatetext")]
        public void UpdateText([FromBody]TextHome text)
        {
            context.UpdateTextHome(text);
        }

        #endregion

        #region Методы работы со списоком призывов к действию

        /// <summary>
        /// метод получения списка с призывами к действию
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getcalltoactions")]
        public IEnumerable<CallToAction> GetCallToActions()
        {
            return context.GetCallToActions();
        }

        /// <summary>
        /// метод добавления элемента списка с призывами
        /// </summary>
        /// <param name="call"></param>
        [HttpPost]
        [Route("addcalltoaction")]
        public void AddCallToAction([FromBody]CallToAction call)
        {
            context.AddCallToAction(call);
        }
        
        /// <summary>
        /// метод удаления элемента списка с призывами
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("deletecaltoaction/id/{id}")]
        public void DeleteCallToAction(string id)
        {
            context.DeleteCallToAction(Convert.ToInt32(id));
        }

        #endregion

        #region Методы работы со списком заявок

        /// <summary>
        /// метод добавления заявки
        /// </summary>
        /// <param name="proposal"></param>
        [HttpPost]
        [Route("addproposal")]
        public void AddProposal([FromBody]Proposal proposal)
        {
            context.AddProposal(proposal);
        }

        /// <summary>
        /// метод возврашает список заявок
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getproposals")]
        public IEnumerable<Proposal> GetProposals()
        {
            return context.GetProposals();
        }

        /// <summary>
        /// показать список заявок определенного статуса
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getproposalsstatus/status/{status}")]
        public IEnumerable<Proposal> GetProposalsStatus(string status)
        {
            return context.GetProposalsStatus(status);
        }

        /// <summary>
        /// показать список заявок за выбранный период
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getdateproposals/startdate/{startdate}/enddate/{enddate}")]
        public IEnumerable<Proposal> GetDateProposals(string startdate, string enddate)
        {
            return context.GetDateProposals(DateTime.Parse(startdate), DateTime.Parse(enddate));
        }

        /// <summary>
        /// метод изменения статуса заявки
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        [HttpPost]
        [Route("updateproposal/id/{id}/status/{status}")]
        public void UpdateProposal(string id,string status)
        {
            context.UpdateProposal(Convert.ToInt32(id), status);
        }

        #endregion

        #region Методы работы со списком проектов

        /// <summary>
        /// Добавить запись в список проектов
        /// </summary>
        /// <param name="project"></param>
        [HttpGet]
        [Route("getprojects")]
        public IEnumerable<Project> GetProjects()
        {
            return context.GetProjects();
        }

        /// <summary>
        /// Добавить запись в список проектов
        /// </summary>
        /// <param name="project"></param>
        [HttpPost]
        [Route("addproject")]
        public void AddProject([FromBody]Project project)
        {
            context.AddProject(project);
        }

        /// <summary>
        /// изменить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        [HttpPost]
        [Route("updateproject/id/{id}")]
        public void UpdateProject(string id, [FromBody]Project project)
        {
            context.UpdateProject(Convert.ToInt32(id), project);
        }

        /// <summary>
        /// удалить запись в списке проектов
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("deleteproject/id/{id}")]
        public void DeleteProject(string id)
        {
            context.DeleteProject(Convert.ToInt32(id));
        }

        #endregion

        #region Методы работы со списком услуг

        /// <summary>
        /// метод получения списка услуг
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getservices")]
        public IEnumerable<Service> GetServices()
        {
            return context.GetServices();
        }

        /// <summary>
        /// Метод добавления услуги
        /// </summary>
        /// <param name="service"></param>
        [HttpPost]
        [Route("addservise")]
        public void AddService([FromBody]Service service)
        {
            context.AddService(service);
        }

        /// <summary>
        /// Метод изменения услуги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        [HttpPost]
        [Route("updateservise/id/{id}")]
        public void UpdateService(string id, [FromBody]Service service)
        {
            context.UpdateService(Convert.ToInt32(id),service);
        }

        /// <summary>
        /// Метод удаления записи в услугах
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("deleteservice/id/{id}")]
        public void DeleteService(string id)
        {
            context.DeleteService(Convert.ToInt32(id));
        }

        #endregion

        #region Методы работы со списоком блогов

        /// <summary>
        /// получить список болгов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getblogs")]
        public IEnumerable<Blog> GetBlogs()
        {
            return context.GetBlogs();
        }

        /// <summary>
        /// добавление блога
        /// </summary>
        /// <param name="blog"></param>
        [HttpPost]
        [Route("addblog")]
        public void AddBlog([FromBody]Blog blog)
        {
            context.AddBlog(blog);
        }

        /// <summary>
        /// удаление блога
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        [Route("deleteblog/{id}")]
        public void DeleteBlog(string id)
        {
            context.DeleteBlog(Convert.ToInt32(id));
        }

        /// <summary>
        /// изменение блога
        /// </summary>
        /// <param name="id"></param>
        /// <param name="blog"></param>
        [HttpPost]
        [Route("updateblog/{id}")]
        public void UpdateBlog(string id, [FromBody]Blog blog)
        {
            context.UpdateBlog(Convert.ToInt32(id), blog);
        }
        

        #endregion

        #region Методы работы со списком контактов

        /// <summary>
        /// Метод получения списка контактов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getcontacts")]
        public IEnumerable<Contact> GetContacts()
        {
            return context.GetContacts();
        }

        [HttpPost]
        [Route("updatecontact/id/{id}")]
        public void UpdateContact(string id,[FromBody]Contact contact)
        {
            context.UpdateContact(Convert.ToInt32(id), contact);
        }

        #endregion

        #region Методы для авторизации
        /// <summary>
        /// добавить пользователя
        /// </summary>
        /// <param name="autorization"></param>
        [HttpPost]
        [Route("adduser")]
        public void AddUser([FromBody]Autorization autorization)
        {
            context.AddUser(autorization);
        }

        /// <summary>
        /// проверка пользователя
        /// </summary>
        /// <param name="autorization"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("checkuser/login/{login}/password/{password}")]
        public bool CheckUser(string login,string password)
        {
            return context.CheckUser(login, password);
        }

        #endregion

    }
}
