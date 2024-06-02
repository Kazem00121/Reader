using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reader.Models;

namespace Reader.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookID);
            builder.Property(b => b.Image).HasColumnType("image");
            builder.ToTable("BookInfo");

            builder
               .HasOne(p => p.Discount)
               .WithOne(t => t.Book)
               .HasForeignKey<Discount>(p => p.BookID);

            builder
               .HasOne(p => p.SubCategory)
               .WithMany(t => t.Books)
               .HasForeignKey(f => f.SCategoryID);
        }
    }
}
