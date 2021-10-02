using GuestbookBackend.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestbookBackend.Models
{
    public class GuestBookEntry
    {
        //Leerer Konstruktor - sonst tut EFCore irgendwie blöd...
        private GuestBookEntry()
        {
        }

        public GuestBookEntry(GuestBookEntryDTO entryDTO)
        {
            Title = entryDTO.Title;
            Visitor = entryDTO.Visitor;
            Text = entryDTO.Text;
            Created = DateTime.Now;
        }

        [Required]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Visitor { get; set; }
        public DateTime Created { get; set; }
    }
}
