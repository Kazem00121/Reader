using Reader.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reader.Mapping
{
    public class Author_BookMap : IEntityTypeConfiguration<Author_Book>
    {
        public void Configure(EntityTypeBuilder<Author_Book> builder)
        {
            builder.HasKey(t => new { t.BookID, t.AuthorID });
            builder
              .HasOne(p => p.Book)
              .WithMany(t => t.Author_Books)
              .HasForeignKey(f => f.BookID);

            builder
               .HasOne(p => p.Author)
               .WithMany(t => t.Author_Books)
               .HasForeignKey(f => f.AuthorID);
        }
    }
}
