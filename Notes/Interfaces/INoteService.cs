using NotesCore.Models;
using NotesCore.Models.Context;
using System.Linq;

namespace Notes.Services.NoteService
{
	public interface INoteService
	{
		void AddNote(Note note);
		Note GetNote(string guid);
		void UpdateNoteAlreadyDeleted(Note note);
		IQueryable<Note> Notes { get; }		
	}
}