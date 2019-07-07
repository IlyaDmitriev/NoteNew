//using Microsoft.AspNetCore.SignalR;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using NotesCore.Models;
//using NotesCore.Models.Context;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Notes.Services.NoteService
//{
//	public class NoteService : INoteService
//	{
//		public NotesContext context;
//		public NoteService(NotesContext dataContext)
//		{
//			context = dataContext;
//		}		

//		public async Task AddNote(Note note)
//		{			
//			context.Notes.Add(note);
//			await context.SaveChangesAsync();				
//		}

//		public async Task<Note> GetNote(string guid)
//		{			
//			var note = await context.Notes.FirstOrDefaultAsync(x => x.GuidNote == guid);
//			return note;
//		}

//		public async Task UpdateNoteAlreadyDeleted(Note note)
//		{			
//			note.AlreadyDeleted = true;
//			await context.SaveChangesAsync();				
//		}		
//	}
//}
