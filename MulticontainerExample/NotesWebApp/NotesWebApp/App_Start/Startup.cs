namespace NotesWebApp
{
    using NotesWebApp.Infrastructure.Mappings;

    public static class Startup
    {
        public static void Bootstrap()
        {
            AutoMapper.Mapper.Initialize(m => m.AddProfile(new NotesMapProfile()));
        }
    }
}