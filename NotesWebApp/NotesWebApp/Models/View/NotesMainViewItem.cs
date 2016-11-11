namespace NotesWebApp.Models.View
{
    using System.Collections.Generic;

    public class NotesMainViewItem
    {
        public NotesMainViewItem(IEnumerable<NoteViewItem> notes, IEnumerable<CategoryViewItem> availableCategories)
        {
            Notes = notes;
            AvailableCategories = availableCategories;
        }

        public IEnumerable<NoteViewItem> Notes { get;}

        public IEnumerable<CategoryViewItem> AvailableCategories { get; }
    }
}