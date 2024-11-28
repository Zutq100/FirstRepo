namespace EFCore.Context.Configure
{
    internal class KnowledgeEntityTypeConfiguration : IEntityTypeConfiguration<KnowledgeModel>
    {
        public void Configure(EntityTypeBuilder<KnowledgeModel> builder)
        {
            builder
                .HasKey(x => x.ID);
            builder
                .HasOne(x => x.Question)
                .WithMany(x => x.Knowledges)
                .HasForeignKey(x => x.QuestionID)
                .IsRequired();
            builder.ToTable("KnowledgeTable");
        }
    }
}
