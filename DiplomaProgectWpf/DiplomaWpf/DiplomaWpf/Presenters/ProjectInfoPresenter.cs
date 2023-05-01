using DiplomaWpf.Interfaces;
using DiplomaWpf.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace DiplomaWpf.Presenters
{
    class ProjectInfoPresenter : IProjectInfoPrersenter,INotifyPropertyChanged
    {
        /// <summary>
        /// поля
        /// </summary>
        private string header;
        private string text;
        private byte[] picture;
        MainWindow view;


        /// <summary>
        /// свойства
        /// </summary>
        public string Header { get => header; set { header = value;OnPropertyChanged("Header"); } }
        public string Text { get => text; set { text = value;OnPropertyChanged("Text"); } }
        public byte[] Picture { get => picture;set { picture = value;OnPropertyChanged("Picture"); } }

        /// <summary>
        /// конструктор
        /// </summary>
        public ProjectInfoPresenter(MainWindow View,Project project)
        {
            view = View;
            Header = project.Header;
            Text = project.Text;
            Picture = project.Picture;
            view.projectInfoGrid.DataContext = this;

        }

        /// <summary>
        /// кнопка назад
        /// </summary>
        public void InvokeBack()
        {
            view.projectInfoGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// показывает информацию о проекте
        /// </summary>
        public void ProjectInfoVisible()
        {
            view.projectInfoGrid.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// реализация интерфейса INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
