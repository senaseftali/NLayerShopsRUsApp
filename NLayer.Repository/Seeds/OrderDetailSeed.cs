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
    internal class OrderDetailSeed : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasData(new OrderDetail
            {
                Id = 1,
                OrderId = 1,
                ProductId = 4


            }, new OrderDetail
            {
                Id = 2,
                OrderId = 2,
                ProductId = 7,

            },
           new OrderDetail
           {
               Id = 3,
               OrderId = 3,
               ProductId = 5

           }, new OrderDetail
           {
               Id = 4,
               OrderId = 4,
               ProductId = 3

           });
        }
    }
}

//Products = new List<Product>() {
//                new Product { Id = 2 },
//                new Product { Id = 7 },
//                new Product { Id = 5}}

//            }