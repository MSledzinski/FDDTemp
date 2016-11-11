namespace WebApiDemo.Infrastructure.Mappings
{
    using AutoMapper;

    public class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            CreateMap<Data.Models.Note, Models.NoteDto>();
            CreateMap<Models.NoteDto, Data.Models.Note>();

            CreateMap<Data.Models.Category, Models.CategoryDto>();
            CreateMap<Models.CategoryDto, Data.Models.Category>();
        }
    }
}