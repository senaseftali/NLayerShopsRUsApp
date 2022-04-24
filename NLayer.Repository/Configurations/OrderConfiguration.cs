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
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            //builder.Property(x => x.OrderNo).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");

            builder.ToTable("Orders");

            builder.HasOne(x => x.Customer).WithOne(x => x.Order).HasForeignKey<Order>(x => x.CustomerId);
        }
    
    }
}
