using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestbookBackend.Models
{
    public class GuestBookEntry
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Visitor { get; set; }
        public DateTime Created { get; set; }
    }
}
