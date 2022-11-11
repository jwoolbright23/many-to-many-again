using System;
using CodingEventsMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingEventsMVC.Data
{
    public class EventDbContext : DbContext
    {
        
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<EventTag> EventTags { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //overriding from DbContext
            //put configuration code about models
            //useful for creating customized models

            modelBuilder.Entity<EventTag>().HasKey(et => new { et.EventId, et.TagId });

        }
    }
}

