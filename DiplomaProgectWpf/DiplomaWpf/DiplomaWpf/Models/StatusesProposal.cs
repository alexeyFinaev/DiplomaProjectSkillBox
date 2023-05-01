using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaWpf.Models
{
  public static  class StatusesProposal
    {
        public static string[] Statuses
        {
            get => new string[5] { "Получена", "В работе", "Выполнена", "Отменена", "Отклонена" };
        }
    }
}
