using DiplomaProjectWebApi.Interface;
using DiplomaProjectWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProjectWebApi.Data
{
    public class BaseContext:IBaseContext
    {
        /// <summary>
        /// прочитать json файл с элементами навигации
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="classType"></param>
        /// <param name="path"></param>
        public IEnumerable<Button> ReadButtonJson(string path)
        {
            var fi = new FileInfo(path);

            //проверяем наличие файла
            if (fi.Exists)
            {
                string str = "";

                //если существует получаем файл и возвращаем коллекцию
                using(StreamReader sr=new StreamReader(path))
                {
                    str = sr.ReadToEnd();
                }

                var collection = JsonConvert.DeserializeObject<IEnumerable<Button>>(str);

                return collection;
            }
            else
            {

                //если не существует создаем файл
                fi.Create().Close();

                //создаем список с элементами элементами
                var buttons = new List<Button>() 
                    {
                        new Button(){Name="ProposalButton",ButtonName="Рабочий стол"},
                        new Button(){Name="HomeButton",ButtonName="Главная"},
                        new Button(){Name="ProjectButton",ButtonName="Проекты"},
                        new Button(){Name="ServiceButton",ButtonName="Услуги"},
                        new Button(){Name="BlogButton",ButtonName="Блог"},
                        new Button(){Name="ContactButton",ButtonName="Контакты"}

                    };

                //сохраняем спиок
                SaveButtonJson(buttons, path);

                //возвращаем коллекцию
                 return buttons.AsEnumerable();

            }
        }
        
        /// <summary>
        /// сохранить json файл с элементами навигации
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public void SaveButtonJson(List<Button> list,string path)
        {
            string str = JsonConvert.SerializeObject(list);

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write(str);
            }
        }

        /// <summary>
        /// прочитать файл с названиями элементов на главной странице
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public TextHome ReadTextHomeJson(string path)
        {
            var fi = new FileInfo(path);

            if (fi.Exists)
            {
                string str = "";

                //создаем поток и получаем данные
                using(StreamReader sr=new StreamReader(path))
                {
                    str = sr.ReadToEnd();
                }

                return JsonConvert.DeserializeObject<TextHome>(str);

            }
            else
            {
                //создаем экземпляр класса с данными
                var text = new TextHome()
                {
                    Text_1 = "IT-консалтинг",
                    Text_2 = "без регистрации и смс",
                    TextButton = "оставить заявку"
                };

                //сохраняем данные в файл
                SaveTextHomeJson(text, path);

                return text;

            }
        }
       
        /// <summary>
        /// сохранить json файл с названиями элементов на главной странице
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path"></param>
        public void SaveTextHomeJson(TextHome text,string path)
        {
            string str = JsonConvert.SerializeObject(text);

            using (var sw = new StreamWriter(path, false))
            {
                sw.Write(str);
            }
        }
    }
}
