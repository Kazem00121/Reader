﻿using Reader.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Reader.Mapping
{
    public class Book_CategoryMap : IEntityTypeConfiguration<Book_Category>
    {
        public void Configure(EntityTypeBuilder<Book_Category> builder)
        {
            builder.HasKey(t => new { t.BookID, t.CategoryID });
            builder
                .HasOne(p => p.Book)
                .WithMany(c => c.book_Categories)
                .HasForeignKey(f => f.BookID);

            builder
               .HasOne(p => p.Category)
               .WithMany(c => c.book_Categories)
               .HasForeignKey(f => f.CategoryID);
        }
    }
}
