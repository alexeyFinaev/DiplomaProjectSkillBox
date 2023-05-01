using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models.Content;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DiplomaWpf.Presenters
{

    class AddUpdateProjectPresenter : IAddUpdateProjectPresenter,INotifyPropertyChanged
    {
        /// <summary>
        /// поля
        /// </summary>
        ISkillProfiContext context;
        MainWindow view;
        private int id;
        private string header;
        private string text;
        private byte[] picture;
        private OpenFileDialog dialog = new OpenFileDialog();

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="view"></param>
        public AddUpdateProjectPresenter(MainWindow view)
        {
            context = new SkillProfiContext();
            this.view = view;
            Header = default;
            Text = default;
            Picture = default;
            view.projectAddUpdateGrid.DataContext = this;
        }
        public AddUpdateProjectPresenter(MainWindow view,Project project)
        {
            context = new SkillProfiContext();
            this.view = view;
            Id = project.Id;
            Header = project.Header;
            Text = project.Text;
            Picture = project.Picture;
            view.projectAddUpdateGrid.DataContext = this;
        }

        /// <summary>
        /// Свойства
        /// </summary>
        public int Id { get => id; set { id = value;OnPropertyChanged("Id"); } }
        public string Header { get => header; set { header = value;OnPropertyChanged("Header"); } }
        public string Text { get => text; set { text = value;OnPropertyChanged("Text"); } }
        public byte[] Picture { get => picture; set { picture = value;OnPropertyChanged("Picture"); } }


        /// <summary>
        /// открывает проводник
        /// </summary>
        public void OpenFileExplorer()
        {
            //событие при выборе файла
            dialog.FileOk += Dialog_FileOk;

            //выбор директории при открытии
            dialog.InitialDirectory = "c:\\";

            //фильтр файлов
            dialog.Filter = "Файлы(*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";

            //открывает проводник
            dialog.ShowDialog();

           

        }

        /// <summary>
        /// событие при выборе файла в проводнике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //получаем изображение из проводника
            Picture = File.ReadAllBytes(dialog.FileName);

        }

        /// <summary>
        /// добавляет новый проект
        /// </summary>
        public void AddProjectSave(IProjectPresenter projectPresenter)
        {
            //создаем новый экземпляр класса
            Project project = new Project()
            {
                Header = this.Header,
                Text = this.Text,
                Picture = this.Picture
            };
            //сохраняем проект в базе данных=> получаем новые данные=>открывааем страницу с проектами
            StatusResult.Invoke(context.AddProject(project), () => { projectPresenter.GetProject(); projectPresenter.ProjectVisability(); });

        }

        /// <summary>
        /// изменяет проект
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        public void UpdateProjectSave(IProjectPresenter projectPresenter)
        {
            var project = new Project()
            {
                Header = this.Header,
                Text = this.Text,
                Picture = this.Picture
            };
            
            //сохраняем проект в базе данных=> получаем новые данные=>открывааем страницу с проектами
            StatusResult.Invoke(context.UpdateProject(Id,project), () => { projectPresenter.GetProject(); projectPresenter.ProjectVisability(); });
        }


        /// <summary>
        /// реализация интерфейса INotifyPripertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
