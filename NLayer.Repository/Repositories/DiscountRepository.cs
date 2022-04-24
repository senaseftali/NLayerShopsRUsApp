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
        public  InvoiceDto GetOrderWithCustomer(Order orderWithCustomerDto)
        {
            InvoiceDto ınvoiceDto=  (InvoiceDto)(from o in _context.Orders
                          join c in _context.Customers on o.CustomerId equals c.Id
                          join cct in _context.CustomerCustomerTypes on c.Id equals cct.CusomerId
                          join ct in _context.CustomerTypes on cct.CusomerTypeId equals ct.Id
                          join d in _context.Discouts on cct.CusomerTypeId equals d.CustomerTypeId
                          join od in _context.OrderDetails on o.Id equals od.OrderId
                          join p in _context.Products on od.ProductId equals p.Id
                          where c.IsActive==true && o.Id== orderWithCustomerDto.Id && c.Id==orderWithCustomerDto.CustomerId
                          select new InvoiceDto { 
                          CustomerName=c.Name,
                          CustomerEmail=c.Email,
                          CustomerTypeName=ct.Name,
                          CreatedDate=c.CreatedDate,
                          TotalAmount=o.TotalAmount,
                          productDtos= new List<ProductDto> {
                          
                              new ProductDto {Id=p.Id, Name=p.Name, Price=p.Price, CategoryId=p.CategoryId ,CategoryName=p.Name}
                          }
                          
                          });
            return  ınvoiceDto;
        }
    }
}
//public string Name { get; set; }

//public int Stock { get; set; }

//public decimal Price { get; set; }

//public int CategoryId { get; set; }