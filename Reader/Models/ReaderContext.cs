using Microsoft.EntityFrameworkCore;

namespace Reader.Models
{
	public class ReaderContext: DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);Database=ReaderDB;Trusted_Connection=True");
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
