using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Models
{
    class TextHome
    {
        public string Text_1 { get; set; }
        public string Text_2 { get; set; }
        public string TextButton { get; set; }
        public string Text_3 { get; set; }

        public TextHome(string text1,string text2,string textButton,string text3)
        {
            Text_1 = text1;
            Text_2 = text2;
            TextButton = textButton;
            Text_3 = text3;

        }


    }
}
