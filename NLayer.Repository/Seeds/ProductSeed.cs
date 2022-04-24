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
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "Kalem 1",
                Price = 100,
                Stock = 20,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 2,
                CategoryId = 1,
                Name = "Fabel Castel Pencil",
                Price = 200,
                Stock = 30,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 3,
                CategoryId = 1,
                Name = "Rotring Pencil",
                Price = 600,
                Stock = 60,
                CreatedDate = DateTime.Now
            }, new Product
            {
                Id = 4,
                CategoryId = 2,
                Name = "Pc",
                Price = 600,
                Stock = 60,
                CreatedDate = DateTime.Now
            }, new Product
            {
                Id = 6,
                CategoryId = 4,
                Name = "Pasta",
                Price = 50,
                Stock = 60,
                CreatedDate = DateTime.Now
            }, new Product
            {
                Id = 7,
                CategoryId = 4,
                Name = "Meet",
                Price = 100,
                Stock = 60,
                CreatedDate = DateTime.Now
            }, new Product
            {
                Id = 5,
                CategoryId = 2,
                Name = "Phone",
                Price = 6600,
                Stock = 320,
                CreatedDate = DateTime.Now
            });
        }
    }
}
