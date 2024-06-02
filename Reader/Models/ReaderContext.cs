using Microsoft.EntityFrameworkCore;
using Reader.Mapping;

namespace Reader.Models
{
	public class ReaderContext: DbContext
	{
        public ReaderContext(DbContextOptions<ReaderContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Author_BookMap());
            modelBuilder.ApplyConfiguration(new BookMap());


            modelBuilder.Entity<Discount>().HasKey(b => b.BookID);
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasColumnName("FName").HasColumnType("nvarchar(20)"); ;
            modelBuilder.Entity<Customer>().Ignore(p => p.Age).Property(p => p.LastName).HasColumnName("LName").HasMaxLength(100);
            modelBuilder.Entity<City>().Property(p => p.CityID).ValueGeneratedNever();
            modelBuilder.Entity<Provice>().Property(p => p.ProvinceID).ValueGeneratedNever();
            modelBuilder.Entity<Order_Book>().HasKey(t => new { t.BookID, t.OrderID });

            modelBuilder.Entity<Order_Book>()
               .HasOne(p => p.Book)
               .WithMany(t => t.Order_Books)
               .HasForeignKey(f => f.BookID);

            modelBuilder.Entity<Order_Book>()
               .HasOne(p => p.Order)
               .WithMany(t => t.Order_Books)
               .HasForeignKey(f => f.OrderID);




            modelBuilder.Entity<Customer>()
               .HasOne(p => p.city1)
               .WithMany(t => t.Customers1)
               .HasForeignKey(p => p.CityID1);

            modelBuilder.Entity<Customer>()
              .HasOne(p => p.city2)
              .WithMany(t => t.Customers2)
              .HasForeignKey(p => p.CityID2).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "هنر" },
                new Category { CategoryID = 2, CategoryName = "عمومی" },
                new Category { CategoryID = 3, CategoryName = "دانشگاهی" }
                );

        }

        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<SubCategory> SubCategories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Provice> Provices { get; set; }
        DbSet<Author_Book> Author_Books { get; set; }
        DbSet<Order_Book> Order_Books { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<OrderStatus> OrderStatuses { get; set; }
        DbSet<Customer> Customers { get; set; }

    }
}
