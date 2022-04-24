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
      
        public abstract ICampaign CreateObj();

        public static T CreateCampaign<T>() where T : ICampaignFactory, new()
        {
            return (T)new T().CreateObj();
        }

        public static ICampaign CreateCampaign(object dataObj)
        {
            if (dataObj == (object)CampaignType.Amount)
                return CreateCampaign<DiscountAmountDto>();
            if (dataObj == (object)CampaignType.Rate)
                return CreateCampaign<DiscountRateDto>();
            throw new Exception("Not Implemented!");
        }

        
    }
  
}
