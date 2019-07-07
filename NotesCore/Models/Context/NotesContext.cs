using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Http;
using NotesCore.Models.Context.Configurations;

namespace NotesCore.Models.Context
{
	public class NotesContext : DbContext
	{
        public DbSet<Note> Notes { get; set; }

        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
