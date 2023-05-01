using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IProjectPresenter
    {
        /// <summary>
        /// свойства
        /// </summary>
        ObservableCollection<Project> Projects { get; set; }
        IProjectInfoPrersenter ProjectInfoPresenter { get; set; }
        IAddUpdateProjectPresenter AddUpdateProjectPresenter { get; set; }

        /// <summary>
        /// получает список проектов
        /// </summary>
        void GetProject();

        /// <summary>
        /// отправляет данные на страницу с инфо-ей о проекте
        /// </summary>
        void ProjectInfoVisabilty(object sender);

        /// <summary>
        /// удаляет проект
        /// </summary>
        /// <param name="index"></param>
        void DeleteProject(object sender);

        /// <summary>
        /// добавление проекта
        /// </summary>
        void AddProject();

        /// <summary>
        /// изменяет проект
        /// </summary>
        /// <param name="sender"></param>
        void UpdateProject(object sender);

        /// <summary>
        /// отображает список проектов
        /// </summary>
        void ProjectVisability();
    }
}
