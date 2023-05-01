using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProjectAsp.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public byte[] Picture { get; set; }

        public string FaceBookText { get; set; }

        public string InstaText { get; set; }

        public string TwitterText { get; set; }

        public string WhatsAppText { get; set; }

        public string YoutobeText { get; set; }
    }
}
