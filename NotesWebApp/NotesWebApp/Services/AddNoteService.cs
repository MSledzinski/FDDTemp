namespace NotesWebApp.Services
{
    using System.Threading.Tasks;

    using NotesWebApp.Infrastructure;
    using NotesWebApp.Models.Data;

    public static class AddNoteService
    {
        public static async Task CreateNote(NoteItem item)
        {
            await HttpProxy.Post(item, "api/notes");
        }
    }
}