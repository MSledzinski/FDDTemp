namespace NotesWebApp.Infrastructure
{
    using System.Configuration;

    public static class Configuration
    {
        public static string BackendServiceUri => ConfigurationManager.AppSettings["NotesServiceUrl"];

        public static string RedisConnectionString => ConfigurationManager.ConnectionStrings["Redis"].ConnectionString;
    }
}