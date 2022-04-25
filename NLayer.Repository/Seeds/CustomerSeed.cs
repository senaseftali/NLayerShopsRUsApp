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
    internal class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer
            {
                Id = 1,
                Name = "Sena",
                LastName = "ŞEFTALİ",
                Email = "seftalisena@gmail.com",
                CustomerTypeId=1,
                CreatedDate = DateTime.Now
            },
            new Customer
            {
                Id = 2,
                Name = "Fatih",
                LastName = "ŞEFTALİ",
                Email = "seftali@gmail.com",
                CustomerTypeId = 4,
                CreatedDate = DateTime.Now
            },
            new Customer
            {
                Id = 3,
                Name = "Ayşe",
                LastName = "ŞEFTALİ",
                Email = "seftali@gmail.com",
                CustomerTypeId = 3,
                CreatedDate = DateTime.Now
            }, new Customer
            {
                Id = 4,
                Name = "Ekrem",
                LastName = "ŞEFTALİ",
                Email = "seftali@gmail.com",
                CustomerTypeId = 4,
                CreatedDate = DateTime.Now
            
            //}, new Customer
            //{
            //    Id = 6,
            //    Name = "Elif",
            //    LastName = "ŞEFTALİ",
            //    Email = "seftali@gmail.com",
              
            //    CreatedDate = DateTime.Now
            //}, new Customer
            //{
            //    Id = 7,
            //    Name = "Şeyma",
            //    LastName = "ŞEFTALİ",
            //    Email = "seftali@gmail.com",
              
            //    CreatedDate = DateTime.Now
            //}, new Customer
            //{
            //    Id = 5,
            //    Name = "Ömer",
            //    LastName = "ŞEFTALİ",
            //    Email = "seftali@gmail.com",
               
            //    CreatedDate = DateTime.Now
            });
        }
    }
}


