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
            //source A - used here and in Event and Tag models
            modelBuilder.Entity<EventTag>()
                .HasKey(et => new { et.EventId, et.TagId });
            modelBuilder.Entity<EventTag>()
                .HasOne(et => et.Event)
                .WithMany(e => e.EventTags)
                .HasForeignKey(et => et.EventId);
            modelBuilder.Entity<EventTag>()
                .HasOne(et => et.Tag)
                .WithMany(t => t.EventTags)
                .HasForeignKey(et => et.TagId);
        }
    }
}

//A -- https://learn.microsoft.com/en-us/ef/core/modeling/relationships?tabs=data-annotations%2Cfluent-api-simple-key%2Csimple-key#many-to-many
//B -- https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration