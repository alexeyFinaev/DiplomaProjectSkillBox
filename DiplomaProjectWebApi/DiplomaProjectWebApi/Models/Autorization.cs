using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProjectWebApi.Models
{
    public class Autorization
    {
        [Key]
        public string Login { get; set; }

        public string Password { get; set; }

        public Autorization(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
