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

namespace DiplomaWpf.Presenters
{
    class AddUpdateBlogPresenter : IAddUpdateBlogPresenter, INotifyPropertyChanged
    {
        MainWindow view;
        ISkillProfiContext context;

        private int id;
        private DateTime date;
        private string header;
        private string description;
        private byte[] picture;

        /// <summary>
        /// окно добавления изображения
        /// </summary>
        OpenFileDialog dialog = new OpenFileDialog();

        /// <summary>
        /// конструктор
        /// </summary>
        public AddUpdateBlogPresenter(MainWindow View)
        {
            view = View;
            context = new SkillProfiContext();
            view.blogAddUpdateGrid.DataContext = this;
            view.addPictureBlog.Content = "Добавить изображение";
        }
        public AddUpdateBlogPresenter(MainWindow View,Blog blog)
        {
            view = View;
            context = new SkillProfiContext();
            view.blogAddUpdateGrid.DataContext = this;
            Id = blog.Id;
            Date = blog.Date;
            Header = blog.Header;
            Description = blog.Description;
            Picture = blog.Picture;

        }

        /// <summary>
        /// свойства
        /// </summary>
        public int Id { get => id; set { id = value;OnPropertyChanged("Id"); } }
        public DateTime Date { get => date; set { date = value;OnPropertyChanged("Date"); } }
        public string Header { get => header; set{ header = value;OnPropertyChanged("Header"); } }
        public string Description { get => description; set { description = value;OnPropertyChanged("Description"); } }
        public byte[] Picture { get => picture; set { picture = value;OnPropertyChanged("Picture"); } }



        /// <summary>
        /// метод добавления изображения
        /// </summary>
        public void AddPictureBlog()
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
        /// событие закрытия окна добавления изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dialog_FileOk(object sender, CancelEventArgs e)
        {
            
            //загружаем файл изображения
            Picture = File.ReadAllBytes(dialog.FileName);

            //убираем надпись с кнопки
            if (Picture != null) { view.addPictureBlog.Content = ""; }


        }

        /// <summary>
        /// метод добавления поста
        /// </summary>
        /// <param name="blog"></param>
        public void InvokeAddBlog(IBlogPresenter blogPresenter)
        {
            //создаем новый экземпляр класса Blog
            var blog = new Blog()
            {
                Header = this.Header,
                Description = this.Description,
                Picture = this.Picture,
                Date = DateTime.Now
            };

            //добавляем новый блог
            StatusResult.Invoke(context.AddBlog(blog), () => { blogPresenter.GetBlogs();view.blogAddSave.Visibility = Visibility.Collapsed;
                view.blogAddUpdateGrid.Visibility = Visibility.Collapsed; });
        }

        /// <summary>
        /// метод изменения поста
        /// </summary>
        /// <param name="blogPresenter"></param>
        public void InvokeUpdateBlog(IBlogPresenter blogPresenter)
        {
            //создаем экземпляр класса Blog
            var blog = new Blog()
            {
                Id = this.Id,
                Header = this.Header,
                Description = this.Description,
                Picture = this.Picture,
                Date = this.Date
            };

            //изменяем блог
            StatusResult.Invoke(context.UpdateBlog(blog.Id, blog), () => { blogPresenter.GetBlogs();view.blogUpdateSave.Visibility=Visibility.Collapsed
                ; view.blogAddUpdateGrid.Visibility = Visibility.Collapsed; });
        }




        /// <summary>
        /// реализация интерфейса INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
