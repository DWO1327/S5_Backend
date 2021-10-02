using GuestbookBackend.Controllers;
using GuestbookBackend.DAL;
using GuestbookBackend.DTOs;
using GuestbookBackend.Models;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using Xunit;

namespace GuestbookBackend.Tests
{
    public class UnitTests
    {
        protected GuestbookDbContext _context;

        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<GuestbookDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

            _context = new GuestbookDbContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

        }

        [Fact]
        public void CheckCreation()
        {
            _context.ShouldNotBeNull();
        }

        [Fact]
        public void CheckAdd()
        {
            var GBEntryDTO = new GuestBookEntryDTO();

            _context.GuestBookEntries.Add(new GuestBookEntry(GBEntryDTO));

            var controller = new GuestBookController(_context);
            var result = controller.GetGuestBookEntries();


            result.ShouldNotBeNull();
            Assert.True(result.IsCompleted);

        }
    }
}