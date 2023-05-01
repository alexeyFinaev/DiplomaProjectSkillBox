using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiplomaProjectAsp.Models;
using DiplomaProjectAsp.Data;
using DiplomaProjectAsp.Interfaces;

namespace DiplomaProjectAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISkillProfiContext context;

        public HomeController(ISkillProfiContext Context)
        {
            context = Context;
        }

        /// <summary>
        /// метод возврашает список с названиями эл-тов управления
        /// </summary>
        /// <returns></returns>
        private List<string> ButtonsName()
        {
            var but = context.GetButtons();

            //создаем список с названиями эл-тов навигации
            var buttons = new List<string>
            {
                //заполняем список
                but.Where(w => w.Name == "HomeButton").FirstOrDefault().ButtonName,
                but.Where(w => w.Name == "ProjectButton").FirstOrDefault().ButtonName,
                but.Where(w => w.Name == "ServiceButton").FirstOrDefault().ButtonName,
                but.Where(w => w.Name == "BlogButton").FirstOrDefault().ButtonName,
                but.Where(w => w.Name == "ContactButton").FirstOrDefault().ButtonName
            };

            //загружаем список эл-тов навигации в динамическую переменную
            return buttons;


        }

        /// <summary>
        /// метод передачи данных в мастер страницу
        /// </summary>
        private void LayoutContent(int i)
        {
            var buttons = ButtonsName();

            //загружаем список эл-тов навигации в динамическую переменную
            ViewBag.Buttons = buttons;

            //загружаем призыв к действию в переменную
            ViewBag.Call = context.RandText();

            //создаем список
            var list = new List<string>();

            //загружаем в массив данные в зависимости от страницы в которой находимся
            if (i == 0)
            {
                list.Add(buttons[0]);

                ViewBag.NavInfoPage =list;
            }
            else
            {
                list.Add(buttons[0]);
                list.Add(buttons[i]);

                //передаем название страницы
                ViewBag.NavInfoPage = list;
            }


        }
        private void LayoutContent(int i,string str)
        {
            var buttons = ButtonsName();

            //загружаем список эл-тов навигации в динамическую переменную
            ViewBag.Buttons = buttons;

            //загружаем призыв к действию в переменную
            ViewBag.Call = context.RandText();

            //создаем список
            var list = new List<string>()
            {
                buttons[0],
                buttons[i],
                str
            };

            ViewBag.NavInfoPage = list;

        }

        /// <summary>
        /// главная страница
        /// </summary>
        /// <returns></returns>
        public IActionResult  Index()
        {
            LayoutContent(0);

            var text= context.GetTextHome();

            return View(text);
        }

        /// <summary>
        /// метод отправки формы заявки
        /// </summary>
        /// <param name="proposal"></param>
        /// <returns></returns>
        public IActionResult AddProposal(Proposal proposal)
        {
            context.AddProposal(proposal);

            return Redirect("~/");
        }

        /// <summary>
        /// страница с проектами
        /// </summary>
        /// <returns></returns>
        public IActionResult Projects()
        {
            LayoutContent(1);

            var projects =context.GetProjects();

            return View(projects);
        }
       
        /// <summary>
        /// страница с описанием проекта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Project(int id)
        {
            LayoutContent(1,"Проект");

            ///получаем объект по Id
            var project = context.GetProjects().Where(w => w.Id == id).FirstOrDefault();

            return View(project);
        }
       
        /// <summary>
        /// страница с сервисами
        /// </summary>
        /// <returns></returns>
        public IActionResult Services()
        {
            LayoutContent(2);

            var services = context.GetServices();

            return View(services);
        }

        /// <summary>
        /// страница с блогами
        /// </summary>
        /// <returns></returns>
        public IActionResult Blogs()
        {
            LayoutContent(3);

            var blogs = context.GetBlogs();

            return View(blogs);
        }

        /// <summary>
        /// страница с описанием блога
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Blog(int id)
        {
            var blogs = context.GetBlogs();
            //находим блог по Id
            var blog = blogs.Where(w => w.Id == id).FirstOrDefault();
            
            //загружаем название блога в строку навигации
            LayoutContent(3, blog.Header);

            return View(blog);
        }

        /// <summary>
        /// страница с контактами
        /// </summary>
        /// <returns></returns>
        public  IActionResult Contacts()
        {
            var contacts = context.GetContacts();

            LayoutContent(4);

            return View(contacts);
        }
    }
}
