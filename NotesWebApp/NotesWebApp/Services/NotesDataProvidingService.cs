namespace NotesWebApp.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using NotesWebApp.Infrastructure;
    using NotesWebApp.Models.Data;

    public static class NotesDataProvidingService
    {
        public static async Task<IEnumerable<NoteItem>> GetAllNotes()
        {
            return await HttpProxy.Get<NoteItem[]>("api/notes");
        }

        public static async Task<IEnumerable<CategoryItem>> GetAllCategories()
        {
            return await HttpProxy.Get<CategoryItem[]>("api/categories");
        }
    }
}