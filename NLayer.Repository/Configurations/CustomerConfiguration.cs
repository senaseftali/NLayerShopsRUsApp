using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);

            builder.ToTable("Customers");

            builder.HasOne(x => x.CustomerType).WithMany(x => x.Customers).HasForeignKey(x => x.CustomerTypeId);
            //builder.HasOne(x => x.CustomerType).WithOne(x => x.Customer).HasForeignKey<Customer>(x => x.CustomerTypeId).OnDelete(DeleteBehavior.NoAction) ;
            //builder.HasMany(x => x.CustomerTypes).WithMany(x => x.Customers);
        }
    }
}
