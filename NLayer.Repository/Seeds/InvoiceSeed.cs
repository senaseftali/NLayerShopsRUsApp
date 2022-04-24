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
    internal class InvoiceSeed : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasData(new Invoice
            {
                Id = 1,
                CustomerId =1,
                OrderId=1,
                CreatedDate = DateTime.Now
            },
            new Invoice
            {
                Id = 2,
                CustomerId = 2,
                OrderId = 2,
                CreatedDate = DateTime.Now
            },
           new Invoice
           {
               Id = 3,
               CustomerId = 3,
               OrderId = 3,
               CreatedDate = DateTime.Now
           }, new Invoice
           {
               Id = 4,
               CustomerId = 4,
               OrderId = 4,
               CreatedDate = DateTime.Now
           });
        }
    }
}
