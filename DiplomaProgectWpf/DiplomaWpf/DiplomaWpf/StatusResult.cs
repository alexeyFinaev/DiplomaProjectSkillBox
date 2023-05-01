using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf
{
   public class StatusResult
    {
        /// <summary>
        /// получаем ответ от сервера
        /// </summary>
        /// <param name="str"></param>
        /// <param name="action"></param>
        public static void Invoke(string str,Action action)
        {
            //разбиваем строку на массив строк
            var arr = str.Split(new char[] { ',' });

            //если статус 200 то выполнить действие 
            if(arr[0]== "StatusCode: 200") { action(); }
            
        }
    }
}
