using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiplomaWpf.Presenters
{
    class NewNameButtonNawigatePresenter
    {
        NewNameButtonNavigate view;
        ISkillProfiContext context;

        public NewNameButtonNawigatePresenter(NewNameButtonNavigate view)
        {
            context = new SkillProfiContext();

            this.view = view;
        }

        /// <summary>
        /// меняет название кнопки навигации
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newName"></param>
        public void NavigateNameChange(int index, string newName)
        {
            //получаем список с кнопками навигации
            var buttons = context.GetButtons().ToList();

            //меняем значение
            StatusResult.Invoke(context.UpdateButton(buttons[index].ButtonName, newName),()=> { });

          

        }
    }
}
