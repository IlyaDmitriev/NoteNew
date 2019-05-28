using NotesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Helpers.HomeHelper
{
	public class FormingNote
	{
		public static Note FormingDateDeleting(Note note)
		{
			var currentDate = DateTime.Now;
			var guid = Guid.NewGuid().ToString();

			note.HoursDeleting = (note.DaysDeleting == 0 && note.MinutesDeleting == 0 && note.HoursDeleting == 0) ||
				(note.DaysDeleting == null && note.MinutesDeleting == null && note.HoursDeleting == null) ? 1 : note.HoursDeleting;
			var dateDeleting = currentDate.Add(new TimeSpan(note.DaysDeleting != null ? note.DaysDeleting.Value : 0, note.HoursDeleting != null ? note.HoursDeleting.Value : 1, note.MinutesDeleting != null ? note.MinutesDeleting.Value : 0, 0));

			note.DeletingDate = dateDeleting;
			note.GuidNote = guid;
			note.CreationDate = currentDate;

			return note;
		}
	}
}
