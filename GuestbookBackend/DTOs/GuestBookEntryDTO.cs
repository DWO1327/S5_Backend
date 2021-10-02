using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestbookBackend.DTOs
{
    public class GuestBookEntryDTO
    {
        public GuestBookEntryDTO(string title, string text, string visitor)
        {
            Title = title;
            Text = text;
            Visitor = visitor;
        }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Visitor { get; set; }
        //public DateTime Created { get; set; }
    }
}
