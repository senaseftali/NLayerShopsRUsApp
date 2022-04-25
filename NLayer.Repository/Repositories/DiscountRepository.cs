using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {

        public DiscountRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<InvoiceDto> GetOrderWithCustomer(OrderWithCustomerDto orderWithCustomerDto)
        {
            var invoiceDto = (from o in _context.Orders
                              join c in _context.Customers on o.CustomerId equals c.Id
                              join ct in _context.CustomerTypes on c.CustomerTypeId equals ct.Id
                              join d in _context.Discouts on ct.Id equals d.CustomerTypeId
                              join od in _context.OrderDetails on o.Id equals od.OrderId
                              join p in _context.Products on od.ProductId equals p.Id
                              where c.IsActive == true && o.Id == orderWithCustomerDto.OrderId && c.Id == orderWithCustomerDto.CustomerId
                              select new InvoiceDto
                              {
                                  CustomerName = c.Name,
                                  CustomerEmail = c.Email,
                                  CustomerCreatedDate = c.CreatedDate,
                                  TotalAmount = o.TotalAmount,
                                  CustomerTypeId = c.CustomerTypeId,
                                  CustomerTypeName = ct.Name,
                                  Rate = d.Rate,
                                  DiscountTypeName=d.Name,
                                  productDtos = new List<ProductDto>
                          {

                            new ProductDto {Id=p.Id, Name=p.Name, Price=p.Price, CategoryId=p.CategoryId , CategoryName=c.Name}
                          }
                              });
            InvoiceDto dto = new InvoiceDto();
            foreach (var item in invoiceDto)
            {
                dto = item;
            }

            return dto;



        }
    }
}
