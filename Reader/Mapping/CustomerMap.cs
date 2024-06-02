using Reader.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reader.Mapping
{
    public class CustomerMap: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
              .HasOne(p => p.city1)
              .WithMany(t => t.Customers1)
              .HasForeignKey(p => p.CityID1);

            builder
                  .HasOne(p => p.city2)
                  .WithMany(t => t.Customers2)
                  .HasForeignKey(p => p.CityID2).OnDelete(DeleteBehavior.Restrict);
        }
       
    }
}
