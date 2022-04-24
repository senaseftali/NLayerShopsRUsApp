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
    internal class InvoiceDetailSeed : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.HasData(new InvoiceDetail
            {
                Id = 1,
                InvoiceId = 1,
                DiscountId = 1,
                Quantity=3,
                Price=1500,
                CreatedDate = DateTime.Now
            },
            new InvoiceDetail
            {
                Id = 2,
                InvoiceId = 2,
                DiscountId = 2,
                Quantity =1,
                Price = 2500,
                CreatedDate = DateTime.Now
            },
           new InvoiceDetail
           {
               Id = 3,
               InvoiceId = 3,
               DiscountId = 3,
               Quantity = 5,
               Price = 7500,
               CreatedDate = DateTime.Now
           }, new InvoiceDetail
           {
               Id = 4,
               InvoiceId = 4,
               DiscountId = 4,
               Quantity = 1,
               Price = 5500,
               CreatedDate = DateTime.Now
           });
        }
    }
}


