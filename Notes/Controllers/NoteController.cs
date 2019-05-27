using Microsoft.AspNetCore.Mvc;
using Notes.Services.NoteService;
using Notes.ViewModels;
using NotesCore.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Controllers
{
	public class NoteController : Controller
	{
		private NoteService NoteService;
		public NoteController (NoteService _service)
		{
			NoteService = _service;
		}
		public IActionResult GetNote(string guid)
		{
			var note = NoteService.GetNote(guid);
			var viewModel = new GetNote();

			if (note.DeleteAfterRead)
			{
				viewModel.DeleteAfterRead = true;
				if (note.AlreadyDeleted)
				{
					viewModel.AlreadyDeleted = true;					
				}
				else
				{
					NoteService.UpdateNoteAlreadyDeleted(note);
				}
			}
			else
			{				
				var date = DateTime.Now - note.DeletingDate;

				viewModel.DeleteAfterRead = false;
				viewModel.DayDeleting = date.Value != null ? date.Value.Days : 0;
				viewModel.HourDeleting = date.Value != null ? date.Value.Hours : 0;
				viewModel.MinuteDeleting = date.Value != null ? date.Value.Minutes : 0;
			}			
			
			return View("GetNote", viewModel);
		}
	}
}
