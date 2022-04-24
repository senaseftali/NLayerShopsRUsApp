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
    internal class OrderSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(new Order
            {
                Id = 1,
                CustomerId = 1,
                TotalAmount = 1000,
                Status = 1,
                CreatedDate = DateTime.Now
            },
            new Order
            {
                Id = 2,
                CustomerId = 2,
                TotalAmount = 2000,
                Status = 1,
                CreatedDate = DateTime.Now
            },
           new Order
           {
               Id = 3,
               CustomerId = 3,
               TotalAmount = 3000,
               Status = 1,
               CreatedDate = DateTime.Now
           }, new Order
           {
               Id = 4,
               CustomerId = 4,
               TotalAmount = 4000,
               Status = 1,
               CreatedDate = DateTime.Now
           });
        }
    }
}


