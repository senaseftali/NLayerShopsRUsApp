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
    internal class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
    {
       
            public void Configure(EntityTypeBuilder<CustomerType> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).UseIdentityColumn();
                builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

                builder.ToTable("CustomerTypes");
          
            //builder.HasMany(x => x.CustomerTypes).WithMany(x => x.Customers);
        }
        
    }
}
