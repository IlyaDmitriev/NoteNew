using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notes.Models;
using Notes.Services.NoteService;
using NotesCore.Models;
using NotesCore.Models.Context;

namespace Notes.Controllers
{
	public class HomeController : Controller
	{
		public NoteService NoteService;
		public HomeController(NoteService _service)
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
			var currentDate = DateTime.Now;
			note.CreationDate = currentDate;
			
			var dateDeleting = currentDate.Add(new TimeSpan(note.DaysDeleting != null ? note.DaysDeleting.Value : 0, note.HoursDeleting != null ? note.HoursDeleting.Value : 0, note.MinutesDeleting != null ? note.MinutesDeleting.Value : 0, 0));
			note.DeletingDate = dateDeleting;
			var guid = Guid.NewGuid().ToString();
			note.GuidNote = guid;

			NoteService.AddNote(note);			

			return View("Create", guid);
		}

		

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
