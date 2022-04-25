using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class DiscountAmountDto : ICampaignFactory
    {

        public DiscountAmountDto(InvoiceDto invoiceDto)
        {
            invoiceDto.DiscountAmount = invoiceDto.TotalAmount * invoiceDto.Rate / 100;
            invoiceDto.Amount = invoiceDto.TotalAmount - invoiceDto.DiscountAmount;
        }

    }

      

    
}
