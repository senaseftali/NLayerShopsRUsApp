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
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.Order).WithOne(x => x.OrderDetail).HasForeignKey<OrderDetail>(x => x.OrderId);
            builder.HasOne(x => x.Product).WithOne(x => x.OrderDetail).HasForeignKey<OrderDetail>(x => x.ProductId);
        }
    
    }
}
