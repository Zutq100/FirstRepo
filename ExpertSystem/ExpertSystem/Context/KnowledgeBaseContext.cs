namespace EFCore.Context
{
    class KnowledgeBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = KnowledgeBaseDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KnowledgeEntityTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestionsEntityTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarsEntityTypeConfiguration).Assembly);
        }
    }
}
