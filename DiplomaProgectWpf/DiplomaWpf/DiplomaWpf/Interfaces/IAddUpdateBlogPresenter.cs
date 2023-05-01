using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IAddUpdateBlogPresenter
    {
        /// <summary>
        /// свойства
        /// </summary>
        int Id { get; set; }
        DateTime Date { get; set; }
        string Header { get; set; }
        string Description { get; set; }
        byte[] Picture { get; set; }

        /// <summary>
        /// метод добавления изображения
        /// </summary>
        void AddPictureBlog();

        /// <summary>
        /// метод добавления поста
        /// </summary>
        /// <param name="blog"></param>
        void InvokeAddBlog(IBlogPresenter blogPresenter);

        /// <summary>
        /// метод изменения поста
        /// </summary>
        /// <param name="blogPresenter"></param>
        void InvokeUpdateBlog(IBlogPresenter blogPresenter);
    }
}
