using NLayer.Core.DTOs;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public abstract class CampaignFactory : ICampaignFactory
    {


        public static ICampaignFactory CreateCampaign(InvoiceDto invoiceDto)
        {
            ICampaignFactory campaignFactory;
            if (invoiceDto.CustomerTypeName == (object)CampaignType.Amount)
            { campaignFactory = new DiscountAmountDto(invoiceDto); }
            else if (invoiceDto.CustomerTypeName == (object)CampaignType.Rate)
            { campaignFactory = new DiscountRateDto(invoiceDto); }
            else
            {
                throw new Exception("Not Implemented!");
            }
            return campaignFactory;
        }

    }
}
