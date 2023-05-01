using DiplomaWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Interfaces
{
    interface IAutorizationPresenter
    {
        string Login { get; set; }

        string Password { get; set; }

        bool User { get; set; }

        bool CheckUser(string login, string password);

        void AddUser();

        void Entrance();
    }
}
