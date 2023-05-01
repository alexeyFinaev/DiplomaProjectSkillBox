using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IAddUpdateProjectPresenter
    {
        /// <summary>
        /// свойства
        /// </summary>
        int Id { get; set; }
        string Header { get; set; }
        string Text { get; set; }
        byte[] Picture { get; set; }


        /// <summary>
        /// открывает проводник
        /// </summary>
        void OpenFileExplorer();

        /// <summary>
        /// добавляет новый проект
        /// </summary>
        /// <param name="projectPresenter"></param>
        void AddProjectSave(IProjectPresenter projectPresenter);

        /// <summary>
        /// изменяет проект
        /// </summary>
        /// <param name="project"></param>
        /// <param name="projectPresenter"></param>
        void UpdateProjectSave(IProjectPresenter projectPresenter);

    }
}
