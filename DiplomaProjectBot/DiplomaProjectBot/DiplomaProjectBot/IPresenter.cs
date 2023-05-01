using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProjectBot
{
    interface IPresenter
    {
        string Text { get; set; }

        void InvokeStart();

        void InvokeStop();
    }
}
