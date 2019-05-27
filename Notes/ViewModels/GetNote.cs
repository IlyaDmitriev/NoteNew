using NotesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.ViewModels
{
	public class GetNote
	{
		public Note Note { get; set; }
		public int DayDeleting { get; set; }
		public int HourDeleting { get; set; }
		public int MinuteDeleting { get; set; }
		public string Message { get; set; }
		public bool AlreadyDeleted { get; set; }
		public bool DeleteAfterRead { get; set; }
	}
}
