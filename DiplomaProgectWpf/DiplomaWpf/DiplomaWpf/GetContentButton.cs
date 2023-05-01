using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DiplomaWpf
{
    /// <summary>
    /// получение контента кнопки
    /// </summary>
    class GetContentButton
    {
        /// <summary>
        /// Возвращает объект класса которому пренадлежит кнопка
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static T ContentButton<T>(object sender) where T:class
        {
            //приводим sender к типу Button
            var button = (Button)sender;

            //приводим button к классу Т и возвращаем объект
            return (T)button.DataContext;


        }
    }
}
