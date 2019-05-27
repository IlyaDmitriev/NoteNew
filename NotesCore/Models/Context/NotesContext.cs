using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace NotesCore.Models.Context
{
	public class NotesContext : DbContext
	{
		public DbSet<Note> Notes { get; set; }

		public NotesContext(DbContextOptions<NotesContext> options) : base(options)
		{
			
		}						
	}
}
