namespace WebApiDemo.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using WebApiDemo.Data.Models;

    public class NotesDatabaseContext : DbContext
    {
        public NotesDatabaseContext()
        {
        }

        public NotesDatabaseContext(string connectionString)
            : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Note>().Property(n => n.Text).HasMaxLength(4000).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Note>()
                .HasRequired(n => n.Category)
                .WithMany()
                .HasForeignKey(n => n.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}