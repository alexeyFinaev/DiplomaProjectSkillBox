using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IBlogPresenter
    {
        /// <summary>
        /// коллекция постов
        /// </summary>
        ObservableCollection<Blog> Blogs { get; set; }

        /// <summary>
        /// презентер изменения-удаления поста
        /// </summary>
        IAddUpdateBlogPresenter Presenter { get; set; }

        /// <summary>
        /// получение списка блогов
        /// </summary>
        void GetBlogs();

        /// <summary>
        /// изменение поста
        /// </summary>
        void InvokeUpdateBlog(Blog blog);

        /// <summary>
        /// удаление
        /// </summary>
        void InvokeDeleteBlog(int id);

        /// <summary>
        /// добавление блога
        /// </summary>
        void InvokeAddBlog();

        /// <summary>
        /// отображение окна со списком постов
        /// </summary>
        void BlogsVisability();
        
    }
}
