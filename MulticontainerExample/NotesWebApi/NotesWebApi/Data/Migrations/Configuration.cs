namespace WebApiDemo.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NotesDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            MigrationsDirectory = @"Data\Migrations";
        }
    }
}
