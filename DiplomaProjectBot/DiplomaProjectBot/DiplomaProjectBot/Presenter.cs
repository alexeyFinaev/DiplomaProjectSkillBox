using DiplomaProjectBot.Data;
using DiplomaProjectBot.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace DiplomaProjectBot
{
    class Presenter : IPresenter,INotifyPropertyChanged
    {
        MainWindow view;
        SkillProfiContext context;


        static string token = "";//токен Telegramm bot




        TelegramBotClient client= new TelegramBotClient(token);

        private string text;
        private const string textService="Услуги";
        private const string textBlog = "Посты";
        private const string textProject = "Проекты";
        private const string textProposal = "Оставить заявку";
        private const string textstart = "/start";

        public string Text { get=>text; set { text = value;OnPropertyChanged("Text"); } }

        private Proposal proposal=new Proposal();//создаем объект класса с заявками

        public Presenter(MainWindow View)
        {
            view = View;
            context = new SkillProfiContext();
            view.DataContext = this;

        }

        /// <summary>
        /// метод запуска бота
        /// </summary>
        public void InvokeStart()
        {

            client.StartReceiving();//запускаем бота

            client.OnMessage += Client_OnMessageHandler;//подключем событие при получении сообщения

            view.buttonStop.Visibility = Visibility.Visible;

            view.buttonStart.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// обработчик события при получении сообщения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Client_OnMessageHandler(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

            var msg = e.Message;//переменная записи сообщения

            //при получении сообщения отправляем в чат  с элементы навигации
            try { await client.SendTextMessageAsync(msg.Chat.Id,msg.Text, replyMarkup: GetButtons()); } catch { }


            string formatStr = "";


            switch (msg.Text)//проверяем текст сообщения
            {
                case textService:
                    {
                        var services = GetServices();//получаем список услуг

                        foreach(var j in services)//пробегаемся по списку услуг=>форматируем и отправляем текст
                        {
                            formatStr = $"{j.NameService}\n\n\n{j.Text}";

                            try { await client.SendTextMessageAsync(msg.Chat.Id,formatStr, replyMarkup: GetButtons()); } catch { }//отправляем список кнопок
                            
                        }

                        //выводим панель навигации
                        try { await client.SendTextMessageAsync(msg.Chat.Id,"", replyMarkup: GetButtons()); }catch { }
                        break;
                    }
                case textProject:
                    {
                        var project = context.GetProjects();//получаем список проектов
                        foreach(var j in project)
                        {
                            formatStr = $"{j.Header}\n\n\n{j.Text}";//форматируем текст

                            using (var ms = new MemoryStream(j.Picture))//создаем поток и отправляем изображение
                            {
                                try { await client.SendPhotoAsync(msg.Chat.Id, new FileToSend("image.png", ms), replyMarkup: GetButtons()); } catch { }
                            }

                            try { await client.SendTextMessageAsync(msg.Chat.Id, formatStr, replyMarkup: GetButtons()); } catch { }//отправляем текст

                        }


                        //выводим панель навигации
                        try { await client.SendTextMessageAsync(msg.Chat.Id, "", replyMarkup: GetButtons()); } catch { }
                        break;
                    }
                case textBlog:
                    {
                        var blogs = context.GetBlogs();//получаем список блогов

                        foreach (var j in blogs)
                        {
                            formatStr = $"{j.Header}\n\n\n{j.Date}\n\n{j.Description}";//форматируем текст

                            using(var ms=new MemoryStream(j.Picture))
                            {
                                //отправляем изображение
                                try { await client.SendPhotoAsync(msg.Chat.Id, new FileToSend("image.png", ms), replyMarkup: GetButtons()); } catch { }
                                //отправляем текст
                                try { await client.SendTextMessageAsync(msg.Chat.Id, formatStr, replyMarkup: GetButtons()); } catch { }
                            }
                        }

                        //выводим панель навигации
                        try { await client.SendTextMessageAsync(msg.Chat.Id, "", replyMarkup: GetButtons()); } catch { }
                        break;
                    }
                case textstart:
                    {
                        break;
                    }
                case textProposal:
                    {
                        proposal = new Proposal();//создаем объект класса с заявками

                        try { await client.SendTextMessageAsync(msg.Chat.Id, "Напишите ваше имя", replyMarkup: GetButtons()); } catch { }

                        break;
                    }
                default:
                    {
                        new Proposal();//создаем объект класса с заявками

                        if (proposal.LastFirstName == default)
                        {
                            Text = msg.Text;
                            proposal.LastFirstName = Text;

                            try { await client.SendTextMessageAsync(msg.Chat.Id, "укажите Ваш Emale"); } catch { }
                            break;
                        }

                        if (proposal.Email == default)
                        {
                            Text = msg.Text;
                            proposal.Email = Text;

                            try { await client.SendTextMessageAsync(msg.Chat.Id, "укажите текст сообщения"); } catch { }
                            break;
                        }

                        if (proposal.Text == default)
                        {
                            //присваиваем оставшиеся значения заявке
                            Text = msg.Text;
                            proposal.Text = Text;
                            proposal.Status = "Получена";
                            proposal.Data = DateTime.Now
;
                            context.AddProposal(proposal);

                            try { await client.SendTextMessageAsync(msg.Chat.Id, "заявка отправлена", replyMarkup: GetButtons()); } catch { }

                            //обнуляем переменную для ханения заявки
                            proposal.LastFirstName = default;
                            proposal.Email = default;
                            proposal.Text = default;
                            proposal.Status = default;
                            proposal.Data = default;

                            break;
                        }

                        break;
                    }
            }

        }

        private IEnumerable<Service> GetServices()
        {
            return context.GetServices();
        }

       


        /// <summary>
        /// содаем кнопки меню бота
        /// </summary>
        /// <returns></returns>
        private IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                
                Keyboard=new KeyboardButton[4][]
                {
                   new KeyboardButton[1]
                   {
                      new KeyboardButton(textProposal)                        
                   },
                    new KeyboardButton[1]
                   {
                      new KeyboardButton(textBlog)
                   },
                     new KeyboardButton[1]
                   {
                      new KeyboardButton(textProject)
                   },

                      new KeyboardButton[1]
                   {
                      new KeyboardButton(textService)
                   },

                }
                
            };
        }

        public void InvokeStop()
        {
            client.StopReceiving();

            Text = "";

            view.buttonStop.Visibility = Visibility.Collapsed;
            view.buttonStart.Visibility = Visibility.Visible;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        }
    }
}
