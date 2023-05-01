using DiplomaWpf.Data;
using DiplomaWpf.Interfaces;
using DiplomaWpf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomaWpf.Presenters
{
    class AutorizationPresenter : IAutorizationPresenter,INotifyPropertyChanged
    {
        ISkillProfiContext context;
        MainWindow view;

        private string login;
        private string password;


        public string Login { get => login; set { login = value;OnPropertyChanged("Login"); } }
        public string Password { get => password; set { password = value;OnPropertyChanged("Password"); } }
        public bool User { get; set; }


        public AutorizationPresenter(MainWindow View)
        {
            view = View;
            context = new SkillProfiContext();
            view.autorizationGrid.DataContext = this;

        }


        public void AddUser()
        {
            context.Adduser(new Autorization(Login,Password));
        }

        public bool CheckUser(string login, string password)
        {
           return context.CheckUser(login, password);
        }

        public void Entrance()
        {

          var b= CheckUser(Login,Password);//получаем ответ

            if (b)
            {
                view.checkAutorize.Visibility = Visibility.Collapsed;
                view.autorizationGrid.Visibility = Visibility.Collapsed;
                view.nameText.Text = Login;
            }
            else
            {
                view.checkAutorize.Visibility = Visibility.Visible;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
