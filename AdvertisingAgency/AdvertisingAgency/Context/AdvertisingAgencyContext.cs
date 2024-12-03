using Microsoft.EntityFrameworkCore;
using AdvertisingAgency.Models;

namespace AdvertisingAgency.Context
{
    //Класс с контекстом базы данных.
    class AdvertisingAgencyContext : DbContext
    {
        //Поля в которых создается экземпляр таблицы.
        public DbSet<ClientsTable> Clients { get; set; }
        public DbSet<OrdersTable> Orders { get; set; }
        public DbSet<ReviewsTable> Reviews { get; set; }
        public AdvertisingAgencyContext()
        {
            //Метод создания базы данных, если не существует
            Database.EnsureCreated();
        }
        //Переопределенный метод в котором прописываем провайдера БД и название файла с БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = AdvertisingAgencyDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Указание поля Первичного ключа при создании БД
            modelBuilder.Entity<ClientsTable>().HasKey(x => x.ID);
            modelBuilder.Entity<OrdersTable>().HasKey(x => x.ID);
            modelBuilder.Entity<ReviewsTable>().HasKey(x => x.ID);

            //При создание поля в таблице OrdersTable у атрибута Status проставляется стандартное значение.
            modelBuilder.Entity<OrdersTable>().Property(x => x.Status).HasDefaultValue("Не принят");
            //При создание базы данных создается внешний ключ, связью один ко многим. В таблице OrdersTable создается атрибут ClientID, который ссылается на таблицу ClientsTable.
            modelBuilder.Entity<ClientsTable>().HasMany(x => x.Requests).WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientID).OnDelete(DeleteBehavior.Cascade).IsRequired();
            //При создание базы данных создается внешний ключ, связью один ко многим. В таблице ReviewsTable создается атрибут OrderId, который ссылается на таблицу ClientsTable.
            modelBuilder.Entity<ReviewsTable>().HasOne(x => x.Order).WithMany(x => x.Reviews)
                .HasForeignKey(x => x.OrderID).OnDelete(DeleteBehavior.Cascade).IsRequired();

            //Ограничение на максимальную длинну символов в поле Telephone.
            modelBuilder.Entity<ClientsTable>().Property(x => x.Telephone).HasMaxLength(10);
            //При создание поля в таблице OrdersTable у атрибута TermOfRealization проставляется стандартное значение.
            modelBuilder.Entity<OrdersTable>().Property(x => x.TermOfRealization).HasDefaultValue("Неограничен");
        }
    }
}
