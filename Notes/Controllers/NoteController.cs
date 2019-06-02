using Microsoft.AspNetCore.Mvc;
using Notes.Services.NoteService;
using Notes.ViewModels;
using NotesCore.Models;
using System;
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
		public async Task<IActionResult> GetNote(string guid)
		{
			var note = await NoteService.GetNote(guid);
			var viewModel = FormingViewModel(note);

			if (viewModel.DeleteAfterRead && !viewModel.AlreadyDeleted)
			{
				NoteService.UpdateNoteAlreadyDeleted(note);
			}	

			return View("GetNote", viewModel);
		}

		[HttpPost]
		public  async Task<IActionResult> Create(Note note)
		{
			note = FormingDateDeleting(note);
			await NoteService.AddNote(note);
			return View("Create", note.GuidNote);
		}

		private Note FormingDateDeleting(Note note)
		{
			var currentDate = DateTime.Now;
			var guid = Guid.NewGuid().ToString();

			note.HoursDeleting = (note.DaysDeleting == 0 && note.MinutesDeleting == 0 && note.HoursDeleting == 0) ||
				(note.DaysDeleting == null && note.MinutesDeleting == null && note.HoursDeleting == null) ? 1 : note.HoursDeleting;
			var dateDeleting = currentDate.Add(new TimeSpan(note.DaysDeleting != null ? note.DaysDeleting.Value : 0, note.HoursDeleting != null ? note.HoursDeleting.Value : 1, note.MinutesDeleting != null ? note.MinutesDeleting.Value : 0, 0));

			note.DeletingDate = dateDeleting;
			note.GuidNote = guid;
			note.CreationDate = currentDate;
			note.UserName = !string.IsNullOrWhiteSpace(note.UserName) ? note.UserName : "Человек без имени";

			return note;
		}

		private static GetNote FormingViewModel(Note note)
		{
			var viewModel = new GetNote();
			if (note != null)
			{
				if (note.DeleteAfterRead)
				{
					viewModel.DeleteAfterRead = true;
					if (note.AlreadyDeleted)
					{
						viewModel.AlreadyDeleted = true;
						viewModel.Message = "Заметка удалена после первого просмотра";
					}
					else
					{
						viewModel.AlreadyDeleted = false;
						viewModel.Message = "Это последний раз, когда вы видите эту заметку)";
					}
				}
				else
				{
					var date = note.DeletingDate - DateTime.Now;
					viewModel.DeleteAfterRead = false;
					viewModel.DayDeleting = date.Value != null ? date.Value.Days : 0;
					viewModel.HourDeleting = date.Value != null ? date.Value.Hours : 0;
					viewModel.MinuteDeleting = date.Value != null ? date.Value.Minutes : 0;
					viewModel.SecondDeleting = date.Value != null ? date.Value.Seconds : 0;

					if (viewModel.MinuteDeleting < 0 || viewModel.HourDeleting < 0 || viewModel.DayDeleting < 0 || viewModel.SecondDeleting < 0)
					{
						viewModel.AlreadyDeleted = true;
						viewModel.Message = $"Заметка была удалена {Math.Abs(viewModel.DayDeleting)} - дней | {Math.Abs(viewModel.HourDeleting)} - часов | " +
							$"{Math.Abs(viewModel.MinuteDeleting)} - минут | { Math.Abs(viewModel.SecondDeleting)} - секунд назад";

					}
					else
					{
						viewModel.Message = $"Заметка удалится через:  {viewModel.DayDeleting} - дней | {viewModel.HourDeleting} - часов |" +
							$" {viewModel.MinuteDeleting} - минут | {viewModel.SecondDeleting} - секунд";
					}

				}
			}
			else
			{
				viewModel.Message = "Заметки по таким параметрам не было найдено";
			}

			viewModel.Note = note;

			return viewModel;
		}
	}
}
