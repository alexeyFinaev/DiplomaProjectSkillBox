using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Presenters
{
    class NavigateButtonsPresenter:INavigateButtonsPresenter
    {
        ISkillProfiContext context;
        MainWindow view;

        public NavigateButtonsPresenter(MainWindow View)
        {
            view = View;
            context = new SkillProfiContext();
        }

        /// <summary>
        ///возвращает название кнопки навигации
        /// </summary>
        /// <param name="buttons"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string OldNameButton(List<Models.Button> buttons, int index)
        {
            return buttons[index].ButtonName;
        }

        /// <summary>
        /// передает в текстбокс название кнопки навигации
        /// </summary>
        /// <param name="window"></param>
        /// <param name="index"></param>
        private void TextBoxTextNewNameButtonNavigateWindow(NewNameButtonNavigate window, int index)
        {
            //получаем список с названиями кнопок навигации
            var buttons = context.GetButtons().ToList();

            //передаем название кнопки в TextBox
            window.newButtonName.Text = OldNameButton(buttons, index);
        }

        /// <summary>
        /// открывает окно изменения названия кнопки навигации
        /// </summary>
        /// <param name="navigate"></param>
        public void ViewUpdateButtonNavigationName(NewNameButtonNavigate navigate)
        {
            //получаем индекс
            var index = view.nawigateButtonsList.SelectedIndex;

            //передаем значение в TextBlock
            TextBoxTextNewNameButtonNavigateWindow(navigate, index);

            //отправляем индекс на окно изменения названия 
            navigate.indexNewNameButton.Text = index.ToString();

            //открываем окно
            navigate.ShowDialog();

            navigate.Closing += Navigate_Closing;
        }

        /// <summary>
        /// событие при закрытии окна изменения названия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigate_Closing(object sender, CancelEventArgs e)
        {
            GetButtonsName();
        }


        /// <summary>
        ///метод получения названий кнопок
        /// </summary>
        public void GetButtonsName()
        {
            var buttons = context.GetButtons();

            // присваиваем значения элементам управления

            view.desctopButton.Content = buttons.Where(w => w.Name == "ProposalButton").FirstOrDefault().ButtonName;
            view.homeButton.Content = buttons.Where(w => w.Name == "HomeButton").FirstOrDefault().ButtonName;
            view.projectButton.Content = buttons.Where(w => w.Name == "ProjectButton").FirstOrDefault().ButtonName;
            view.serviceButton.Content = buttons.Where(w => w.Name == "ServiceButton").FirstOrDefault().ButtonName;
            view.blogButton.Content = buttons.Where(w => w.Name == "BlogButton").FirstOrDefault().ButtonName;
            view.contactButton.Content = buttons.Where(w => w.Name == "ContactButton").FirstOrDefault().ButtonName;

        }

        
    }
}
