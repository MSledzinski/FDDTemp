namespace WebApiDemo.Infrastructure
{
    using System.Configuration;

    public static class ConnectionStringProvider
    {
        private const string EntityDatabaseConnectionStringKey = "EntityDatabase";

        public static string EntityDatabaseConnectionString => 
            ConfigurationManager.ConnectionStrings[EntityDatabaseConnectionStringKey].ConnectionString;
    }
}