using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IProjectInfoPrersenter
    {
        /// <summary>
        /// заголовок
        /// </summary>
        string Header { get; set; }

        /// <summary>
        /// текст
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// изображение
        /// </summary>
        byte[] Picture { get; set; }

        /// <summary>
        /// показывает информацию о проекте
        /// </summary>
        void ProjectInfoVisible();

        /// <summary>
        /// кнопка назад
        /// </summary>
        void InvokeBack();
    }
}
