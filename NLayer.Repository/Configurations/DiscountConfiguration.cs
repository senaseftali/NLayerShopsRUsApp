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
    internal class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {

        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Rate).IsRequired().HasColumnType("decimal(18,2)");

            builder.ToTable("Discounts");

            //builder.HasOne(x => x.CustomerTypes).WithMany(x => x.Customers);
            builder.HasOne(x => x.CustomerType).WithOne(x => x.Discount).HasForeignKey<Discount>(x => x.CustomerTypeId);
            //builder.HasOne(x => x.Product).WithOne(x => x.ProductFeature).HasForeignKey<ProductFeature>(x => x.ProductId);
        }
    
    }
}
