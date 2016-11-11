namespace NotesWebApp.Infrastructure.Mappings
{
    using AutoMapper;

    using NotesWebApp.Models.Create;
    using NotesWebApp.Models.Data;
    using NotesWebApp.Models.View;

    public class NotesMapProfile : Profile
    {
        public NotesMapProfile()
        {
            CreateMap<NoteItem, NoteViewItem>();
            CreateMap<CategoryItem, CategoryViewItem>();

            CreateMap<NoteAddRequest, NoteItem>();
        }
    }
}