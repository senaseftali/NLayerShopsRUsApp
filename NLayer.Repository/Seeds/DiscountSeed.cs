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
    internal class DiscountSeed : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasData(new Discount
            {
                Id = 1,
                Name = "Rate",
                Rate=30,
                CustomerTypeId=1,
                CreatedDate = DateTime.Now
            },
            new Discount
            {
                Id = 2,
                Name = "Amount",
                Rate = 5,
                CustomerTypeId = 4,
                CreatedDate = DateTime.Now
            },
            new Discount
            {
                Id = 3,
                Name = "Rate",
                Rate = 5,
                CustomerTypeId = 3,
                CreatedDate = DateTime.Now
            },
           new Discount
           {
               Id = 4,
               Name = "Rate",
               Rate = 10,
               CustomerTypeId = 2,
               CreatedDate = DateTime.Now
           });
        }
    }
}
