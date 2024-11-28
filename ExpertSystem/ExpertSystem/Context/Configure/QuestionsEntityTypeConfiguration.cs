namespace EFCore.Context.Configure
{
    internal class QuestionsEntityTypeConfiguration : IEntityTypeConfiguration<QuestionsModel>
    {
        public void Configure(EntityTypeBuilder<QuestionsModel> builder)
        {
            builder
                .HasKey(x => x.ID);
            builder
                .ToTable("QuestionsTable");
        }
    }
}
