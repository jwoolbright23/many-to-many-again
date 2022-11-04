using System;
using CodingEventsMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingEventsMVC.Data
{
    public class EventDbContext : DbContext
    {

        public DbSet<Event> Events { get; set; }


        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }
    }
}

