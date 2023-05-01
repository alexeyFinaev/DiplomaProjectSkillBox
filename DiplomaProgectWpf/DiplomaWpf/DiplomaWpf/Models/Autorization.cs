using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Models
{
    class Autorization
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public Autorization(string login,string password)
        {
            Login = login;
            Password = password;
        }
    }
}
