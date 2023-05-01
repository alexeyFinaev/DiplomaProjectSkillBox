using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomaWpf.Presenters
{
    class BlogPresenter : IBlogPresenter,INotifyPropertyChanged
    {
        ISkillProfiContext context;
        MainWindow view;
        private ObservableCollection<Blog> blogs;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="View"></param>
        public BlogPresenter(MainWindow View)
        {
            context = new SkillProfiContext();
            view = View;
            view.blogGrid.DataContext = this;
            
        }

       
        
        
        /// <summary>
        /// презентер изменения-удаления поста
        /// </summary>
        public IAddUpdateBlogPresenter Presenter { get; set; }

        /// <summary>
        /// коллекция постов
        /// </summary>
        public ObservableCollection<Blog> Blogs{ get { return blogs; } set { blogs = value;OnPropertyChanged("Blogs"); } }

        /// <summary>
        /// получение списка постов
        /// </summary>
        public void GetBlogs()
        {
            //присваиваем свойству Blogs полученые данные из контекста
            Blogs = new ObservableCollection<Blog>(context.GetBlogs());
        }

        /// <summary>
        /// удалить блог
        /// </summary>
        public void InvokeDeleteBlog(int id)
        {
            //удаляем пост, ожидаем ответ от сервера и обновляем список
            StatusResult.Invoke(context.DeleteBlog(id), () =>{ GetBlogs(); } ); 

        }

        /// <summary>
        /// добавить блог
        /// </summary>
        public void InvokeAddBlog()
        {
            Presenter = new AddUpdateBlogPresenter(view);//инициализируем презентер

            view.blogAddSave.Visibility = Visibility.Visible;//включаем видимость кнопки добавления

            view.blogAddUpdateGrid.Visibility = Visibility.Visible;//открываем страницу добавления поста
        }

        /// <summary>
        /// изменить блог
        /// </summary>
        public void InvokeUpdateBlog(Blog blog)
        {
            Presenter = new AddUpdateBlogPresenter(view, blog);//инициализируем презентер

            view.blogUpdateSave.Visibility = Visibility.Visible;//включаем видимость кнопки изменения поста

            view.blogAddUpdateGrid.Visibility = Visibility.Visible;//открываем страницу добавления поста

        }

        /// <summary>
        /// отображение окна со списком постов
        /// </summary>
        public void BlogsVisability()
        {
            view.homeGrid.Visibility = Visibility.Collapsed;
            view.mainGrid.Visibility = Visibility.Collapsed;
            view.projectGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.serviceGrid.Visibility = Visibility.Collapsed;
            view.serviceAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.blogGrid.Visibility = Visibility.Visible;
            view.blogAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.contactsGrid.Visibility = Visibility.Collapsed;
        }



        /// <summary>
        /// реализация интерфейса INotifyProprtyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        
    }
}
