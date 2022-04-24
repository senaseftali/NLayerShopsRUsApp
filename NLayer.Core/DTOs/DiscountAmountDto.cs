using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class DiscountAmountDto : ICampaign
    {
        public string CampaignName { get { return "Amount"; } }

        public ICampaign CreateObj()
        {
            return new DiscountAmountDto();
        }

    }
}
