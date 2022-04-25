using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
          Task<InvoiceDto> GetOrderWithCustomer(OrderWithCustomerDto orderWithCustomerDto);
    }
}
