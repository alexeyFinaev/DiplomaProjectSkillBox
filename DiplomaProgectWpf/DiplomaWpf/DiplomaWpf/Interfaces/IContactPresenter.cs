using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IContactPresenter
    {
        int Id { get; set; }

        /// <summary>
        /// текст с адресом
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// изображение
        /// </summary>
        byte[] Picture { get; set; }

        /// <summary>
        /// контакт facebook
        /// </summary>
        string FaceBookText { get; set; }
       
        /// <summary>
        /// контакт instagram
        /// </summary>
        string InstaText { get; set; }

        /// <summary>
        /// контакт twitter
        /// </summary>
        string TwitterText { get; set; }

        /// <summary>
        /// контакт whatsApp
        /// </summary>
        string WhatsAppText { get; set; }

        /// <summary>
        /// контакт youtube
        /// </summary>
        string YoutobeText { get; set; }

        /// <summary>
        /// список контактов
        /// </summary>
        ObservableCollection<Contact> Contacts { get; set; }


        /// <summary>
        /// получить контакт
        /// </summary>
        void GetContact();

        /// <summary>
        /// изменить контакт
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        void SaveUpdateContact();

        /// <summary>
        /// видимость вкладки с контактами
        /// </summary>
        void VisabilityContactGrid();

        /// <summary>
        /// отображает текстбокс для изменения контакта
        /// </summary>
        void TextBoxContactVisaility();

        /// <summary>
        /// изменение изображения
        /// </summary>
        void ImageUpdate();

        //открывает редактирование ссылок
        void OpenLinksUpdate();

    }
}
