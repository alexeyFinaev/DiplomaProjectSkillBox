using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DiplomaWpf.Presenters
{
    class ProjectPresenter : IProjectPresenter,INotifyPropertyChanged
    {
        /// <summary>
        /// поля
        /// </summary>
        MainWindow view;
        ISkillProfiContext context;
        private ObservableCollection<Project> projects;


        /// <summary>
        /// свойства
        /// </summary>
        public ObservableCollection<Project> Projects { get=>projects; set { projects = value;OnPropertyChanged("Projects"); } }
        public IProjectInfoPrersenter ProjectInfoPresenter { get; set; }
        public IAddUpdateProjectPresenter AddUpdateProjectPresenter { get; set; }


        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="view"></param>
        public ProjectPresenter(MainWindow view)
        {
            context = new SkillProfiContext();

            this.view = view;

            view.projectGrid.DataContext = this;
        }


        /// <summary>
        /// отображает грид со списком проектов
        /// </summary>
        public void ProjectVisability()
        {
            view.homeGrid.Visibility = Visibility.Collapsed;
            view.mainGrid.Visibility = Visibility.Collapsed;
            view.projectGrid.Visibility = Visibility.Visible;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.serviceGrid.Visibility = Visibility.Collapsed;
            view.serviceAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.blogGrid.Visibility = Visibility.Collapsed;
            view.blogAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.contactsGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// получает список проектов
        /// </summary>
        public void GetProject()
        {
            //загружаем список проектов 
            Projects = new ObservableCollection<Project>(context.GetProjects());

          
        }

        /// <summary>
        /// возвращает выбраный проект
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private Project GetSelectedProject(object sender)
        {
            var listItems = sender as ListView;

            return (Project)listItems.SelectedItem;
        }

        /// <summary>
        /// показывает информацию о проекте
        /// </summary>
        public void ProjectInfoVisabilty(object sender)
        {
            if (GetSelectedProject(sender) != null)
            {
                //получаем выбранный проект
                this.ProjectInfoPresenter = new ProjectInfoPresenter(view, GetSelectedProject(sender));

                //открываем окно с информацией о проекте
                this.ProjectInfoPresenter.ProjectInfoVisible();
            }
            

        }

        /// <summary>
        /// удаление проекта
        /// </summary>
        /// <param name="index"></param>
        public void DeleteProject(object sender)
        {
            //получаем элемент из списка проектов
            var item = GetContentButton.ContentButton<Project>(sender);

            //удаляем проект=> ожидаем ответ от сервера=> отображаем измененный список с проектами
            StatusResult.Invoke(context.DeleteProject(item.Id), () => GetProject());

        }

        /// <summary>
        /// добавление проекта
        /// </summary>
        public void AddProject()
        {

            //включаем видимость кнопки добавления фото
           view.projectAddSave.Visibility = Visibility.Visible;

            view.projectAddPictire.Content = "Добавить фото";

            AddUpdateProjectPresenter = new AddUpdateProjectPresenter(view);

            //включаем отображение страницы добавления проекта
            view.projectAddUpdateGrid.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// изменение проекта
        /// </summary>
        /// <param name="sender"></param>
        public void UpdateProject(object sender)
        {
            //получаем элемент из списка проектов
            var item = GetContentButton.ContentButton<Project>(sender);

            //включаем видимость кнопки добавления фото
            view.projectUpdateSave.Visibility = Visibility.Visible;

            view.projectAddPictire.Content = "Изменить фото";

            //присваиваем презентер
            AddUpdateProjectPresenter = new AddUpdateProjectPresenter(view,item);

            //включаем отображение страницы добавления проекта
            view.projectAddUpdateGrid.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// реализация интерфейса INotifiPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
