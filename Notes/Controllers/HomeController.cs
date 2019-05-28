using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notes.Helpers.HomeHelper;
using Notes.Models;
using Notes.Services.NoteService;
using NotesCore.Models;
using NotesCore.Models.Context;

namespace Notes.Controllers
{
	public class HomeController : Controller
	{
		public INoteService NoteService;
		public HomeController(INoteService _service)
		{
			NoteService = _service;
		}
		public IActionResult Index()
		{				
			return View();
		}

		[HttpPost]
		public IActionResult Create(Note note)
		{
			note = FormingNote.FormingDateDeleting(note);
			NoteService.AddNote(note);
			return View("Create", note.GuidNote);
		}		
	}
}
