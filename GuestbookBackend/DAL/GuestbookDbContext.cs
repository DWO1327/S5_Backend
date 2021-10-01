using GuestbookBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestbookBackend.DAL
{
    public class GuestbookDbContext : DbContext
    {
        public GuestbookDbContext(DbContextOptions<GuestbookDbContext> options)
            : base(options)
        {
        }

        public DbSet<GuestBookEntry> GuestBookEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
