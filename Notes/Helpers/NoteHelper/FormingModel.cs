using Notes.ViewModels;
using NotesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Helpers.NoteHelper
{
	public class FormingModel
	{
		public static GetNote FormingViewModel(Note note)
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
					if (viewModel.MinuteDeleting < 0 || viewModel.HourDeleting < 0 || viewModel.DayDeleting < 0)
					{
						viewModel.AlreadyDeleted = true;
						viewModel.Message = $"Заметка была удалена {Math.Abs(viewModel.DayDeleting)} - дней | {Math.Abs(viewModel.HourDeleting)} - часов | {Math.Abs(viewModel.MinuteDeleting)} - минут назад";
					}
					else
					{
						viewModel.Message = $"Заметка удалится через {viewModel.DayDeleting} - дней | {viewModel.HourDeleting} - часов | {viewModel.MinuteDeleting} - минут";
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
