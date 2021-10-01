﻿using GuestbookBackend.DAL;
using GuestbookBackend.DTOs;
using GuestbookBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestbookBackend.Controllers
{
    [Route("guestbook/entries")]
    public class GuestBookController : ControllerBase
    {
        private readonly GuestbookDbContext _context;

        public GuestBookController(GuestbookDbContext context)
        {
            _context = context;
        }

        // Get guestbook/entries laut Vorgabe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestBookEntry>>> GetGuestBookEntries()
        {
            return await _context.GuestBookEntries.ToListAsync();
        }
        // POST auf guestbook/entries laut Vorgabe
        [HttpPost]
        public async Task<ActionResult<GuestBookEntry>> PostGuestBookEntry([FromBody]GuestBookEntryDTO GBentryDTO)
        {
            GuestBookEntry guestBookEntry = new GuestBookEntry(GBentryDTO);
            _context.GuestBookEntries.Add(guestBookEntry);
            await _context.SaveChangesAsync();

            return guestBookEntry;
             
        }


    }
}
