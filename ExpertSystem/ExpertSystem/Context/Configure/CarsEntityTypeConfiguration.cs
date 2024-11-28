namespace EFCore.Context.Configure
{
    internal class CarsEntityTypeConfiguration : IEntityTypeConfiguration<CarsModel>
    {
        public void Configure(EntityTypeBuilder<CarsModel> builder)
        {
            builder
                .HasKey(x => x.ID);
            builder
                .HasMany(x => x.Knowledge)
                .WithOne(x => x.Car)
                .HasForeignKey(x => x.CarID)
                .IsRequired();
            builder
                .ToTable("CarsTable");
        }
    }
}
