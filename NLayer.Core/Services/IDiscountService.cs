using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IDiscountService : IService<Discount>
    {
        Task<CustomResponseDto<InvoiceDto>> GetInvoiceCalculate(OrderWithCustomerDto orderWithCustomerDto);
    }
}
