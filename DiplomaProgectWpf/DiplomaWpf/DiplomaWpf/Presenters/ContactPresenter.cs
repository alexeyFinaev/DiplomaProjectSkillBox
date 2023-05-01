using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models.Content;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomaWpf.Presenters
{
    class ContactPresenter : IContactPresenter,INotifyPropertyChanged
    {
        /// <summary>
        /// поля
        /// </summary>
        private int id;
        private string text;
        private byte[] picture;
        private string faceBookText;
        private string instaText;
        private string twitterText;
        private string whatsAppText;
        private string youtobeText;
        private ObservableCollection<Contact> contacts;

        private OpenFileDialog dialog;

        MainWindow view;
        ISkillProfiContext context;

        /// <summary>
        /// конструктор
        /// </summary>
        public ContactPresenter(MainWindow View)
        {
            view = View;
            context = new SkillProfiContext();
            view.contactsGrid.DataContext = this;
            view.contactLinksGrid.DataContext = this;
        }

        /// <summary>
        /// свойства
        /// </summary>
        public int Id { get => id; set { id = value;OnPropertyChanged("Id"); } }
        public string Text { get => text; set { text = value;OnPropertyChanged("Text"); } }
        public byte[] Picture { get => picture; set { picture = value;OnPropertyChanged("Picture"); } }
        public string FaceBookText { get => faceBookText; set { faceBookText = value;OnPropertyChanged("FaceBookText"); } }
        public string InstaText { get => instaText; set { instaText = value;OnPropertyChanged("InstaText"); } }
        public string TwitterText { get => twitterText; set { twitterText = value;OnPropertyChanged("TwitterText"); } }
        public string WhatsAppText { get => whatsAppText; set { whatsAppText = value;OnPropertyChanged("WhatsAppText"); } }
        public string YoutobeText { get => youtobeText; set { youtobeText = value;OnPropertyChanged("YoutobeText"); } }
        public ObservableCollection<Contact> Contacts { get => contacts; set { contacts = value;OnPropertyChanged("Contacts"); } }

        /// <summary>
        /// получить контакт
        /// </summary>
        public void GetContact()
        {
            Contacts = new ObservableCollection<Contact>(context.GetContacts());

            //выключаем действие кнопки изменения изображения
            view.imagUpadeContact.IsEnabled = false;

            //включаем видимость кнопки редактирования
            view.contactsEdit.Visibility = Visibility.Visible;

            Id = Contacts[0].Id;
            Text = Contacts[0].Text;
            Picture = Contacts[0].Picture;
            FaceBookText = Contacts[0].FaceBookText;
            InstaText = Contacts[0].InstaText;
            TwitterText = Contacts[0].TwitterText;
            WhatsAppText = Contacts[0].WhatsAppText;
            YoutobeText = Contacts[0].YoutobeText;

        }

        /// <summary>
        /// изменить контакт
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        private void UpdateContact(int id,Contact contact)
        {

           StatusResult.Invoke(context.UpdateContact(id, contact),()=> GetContact());

        }

        /// <summary>
        /// отображает текстбокс для изменения контакта
        /// </summary>
        public void TextBoxContactVisaility()
        {
            //редактирование текста
            view.contactTextBox.Visibility = Visibility.Visible;

            //выключаем видимость кнопки редактирования
            view.contactsEdit.Visibility = Visibility.Visible;

            //включаем видимость кнопки сохренения
            view.contactsSave.Visibility = Visibility.Visible;

            //включаем действие кнопки изменения изображения
            view.imagUpadeContact.IsEnabled = true;


        }

        /// <summary>
        /// сохраняет измененный контакт
        /// </summary>
        public void SaveUpdateContact()
        {
            UpdateContact(this.Id, new Contact()
            {
                Text = this.Text,
                Picture = this.Picture,
                FaceBookText = this.FaceBookText,
                InstaText = this.InstaText,
                TwitterText = this.TwitterText,
                WhatsAppText = this.WhatsAppText,
                YoutobeText = this.YoutobeText
            });

            //отключаем видимость текстбокса
            view.contactTextBox.Visibility = Visibility.Collapsed;

            //отключаем видимость кнопки
            view.contactsSave.Visibility = Visibility.Collapsed;

            GetContact();//получаем обновленный контакт
        }

        /// <summary>
        /// видимость вкладки с контактами
        /// </summary>
        public void VisabilityContactGrid()
        {
            view.homeGrid.Visibility = Visibility.Collapsed;
            view.mainGrid.Visibility = Visibility.Collapsed;
            view.projectGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
            view.projectAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.serviceGrid.Visibility = Visibility.Collapsed;
            view.serviceAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.blogGrid.Visibility = Visibility.Collapsed;
            view.blogAddUpdateGrid.Visibility = Visibility.Collapsed;
            view.contactsGrid.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// изменение изображения
        /// </summary>
        public void ImageUpdate()
        {
            dialog = new OpenFileDialog();//создаем экземпляр касса для добавления зображения

            //событие при выборе файла
            dialog.FileOk += Dialog_FileOk;

            //выбор директории при открытии
            dialog.InitialDirectory = "c:\\";

            //фильтр файлов
            dialog.Filter = "Файлы(*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";

            //открывает проводник
            dialog.ShowDialog();

        }

        public void OpenLinksUpdate()
        {
            this.TextBoxContactVisaility();

            view.contactLinksGrid.Visibility = Visibility.Visible;//включаем видимость грида
        }

        /// <summary>
        /// событие при закрытии окна добавления изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dialog_FileOk(object sender, CancelEventArgs e)
        {
            //загружаем файл изображения
            Picture = File.ReadAllBytes(dialog.FileName);
  
        }



        /// <summary>
        /// реализация интерфейса INitifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
