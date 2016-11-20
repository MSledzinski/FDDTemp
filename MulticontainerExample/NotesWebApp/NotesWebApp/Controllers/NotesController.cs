namespace NotesWebApp.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using NotesWebApp.Models.Create;
    using NotesWebApp.Models.Data;
    using NotesWebApp.Models.View;
    using NotesWebApp.Services;

    public class NotesController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var notes = await NotesDataProvidingService.GetAllNotes();
            var categories = await NotesDataProvidingService.GetAllCategories();

            NotesMainViewItem viewItem =
                new NotesMainViewItem(
                    notes.Select(n =>
                        {
                            var mapped = n.Map<NoteViewItem>();
                            mapped.CategoryName = categories.Single(c => c.Id == n.CategoryId).Name;
                            return mapped;
                        }),
                    categories.Select(c => c.Map<CategoryViewItem>()));

            return View(viewItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NoteAddRequest noteData)
        {
            await AddNoteService.CreateNote(noteData.Map<NoteItem>());
       
            return RedirectToAction("Index");
        }
    }
}