using DiplomaProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProjectWebApi.Interface
{
    public interface IBaseContext
    {
        /// <summary>
        /// прочитать json файл с элементами навигации
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="classType"></param>
        /// <param name="path"></param>
        IEnumerable<Button> ReadButtonJson(string path);

        /// <summary>
        /// сохранить json файл с элементами навигации
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="path"></param>
        void SaveButtonJson(List<Button> list, string path);

        /// <summary>
        /// прочитать файл с названиями элементов на главной странице
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        TextHome ReadTextHomeJson(string path);

        /// <summary>
        /// сохранить json файл с названиями элементов на главной странице
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path"></param>
        void SaveTextHomeJson(TextHome text, string path);
    }
}
