using Microsoft.AspNetCore.Mvc;
using Notes.Helpers.NoteHelper;
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
		private INoteService NoteService;
		public NoteController (INoteService _service)
		{
			NoteService = _service;
		}
		public IActionResult GetNote(string guid)
		{
			var note = NoteService.GetNote(guid);
			var viewModel = FormingModel.FormingViewModel(note);

			if (viewModel.DeleteAfterRead && !viewModel.AlreadyDeleted)
			{
				NoteService.UpdateNoteAlreadyDeleted(note);
			}		

			return View("GetNote", viewModel);
		}
	}
}
