using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotesCore.Models;
using NotesCore.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Services.NoteService
{
	public class NoteService : INoteService
	{
		public NotesContext context;
		public NoteService(NotesContext dataContext)
		{
			context = dataContext;
		}		
		public IQueryable<Note> Notes
		{
			get
			{				
				return context.Notes;
			}
		}

		public void AddNote(Note note)
		{
			
			context.Notes.Add(note);
			context.SaveChanges();				
		}

		public Note GetNote(string guid)
		{			
			var note = context.Notes.FirstOrDefault(x => x.GuidNote == guid);
			return note;
		}

		public void UpdateNoteAlreadyDeleted(Note note)
		{			
			note.AlreadyDeleted = true;
			context.SaveChanges();				
		}		
	}
}
