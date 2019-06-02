using NotesCore.Models;
using System.Threading.Tasks;

namespace Notes.Services.NoteService
{
	public interface INoteService
	{
		Task AddNote(Note note);
		Task<Note> GetNote(string guid);
		Task UpdateNoteAlreadyDeleted(Note note);			
	}
}