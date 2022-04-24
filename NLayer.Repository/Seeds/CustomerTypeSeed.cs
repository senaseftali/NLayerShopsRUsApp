using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class CustomerTypeSeed : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.HasData(new CustomerType
            {
                Id = 1,
                Name = "Employee",
                CreatedDate = DateTime.Now
            },
            new CustomerType
            {
                Id = 2,
                Name = "Affiliate",
                CreatedDate = DateTime.Now
            },
           new CustomerType
           {
                Id =3,
                Name = "Customer",
                CreatedDate = DateTime.Now
            },new CustomerType
           {
                Id =4,
                Name = "Other",
                CreatedDate = DateTime.Now
            });
        }
    }
}
