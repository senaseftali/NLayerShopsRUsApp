using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class DiscountRateDto : ICampaignFactory
    {
        public DiscountRateDto(InvoiceDto invoiceDto)
        {

           int mod= (Convert.ToInt32(invoiceDto.TotalAmount) / 100);
            invoiceDto.DiscountAmount= mod * invoiceDto.Rate;
            invoiceDto.Amount=invoiceDto.TotalAmount - invoiceDto.DiscountAmount;
        }
    }
}
