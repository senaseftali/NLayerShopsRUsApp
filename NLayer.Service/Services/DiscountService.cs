using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class DiscountService : Service<Discount>, IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        public DiscountService(IGenericRepository<Discount> repository, IUnitOfWork unitOfWork, IMapper mapper, IDiscountRepository discountRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _discountRepository = discountRepository;
        }


        public async Task<CustomResponseDto<InvoiceDto>> GetInvoiceCalculate(OrderWithCustomerDto orderWithCustomerDto)
        {
            var invoiceDto = await _discountRepository.GetOrderWithCustomer(orderWithCustomerDto);


            CampaignFactory.CreateCampaign(invoiceDto);
            
            return CustomResponseDto<InvoiceDto>.Success(200, invoiceDto);

        }

    }




}
