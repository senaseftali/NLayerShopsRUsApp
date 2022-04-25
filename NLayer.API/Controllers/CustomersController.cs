using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CustomersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomersController(IMapper mapper, ICustomerService customerService)
        {

            _mapper = mapper;
            _customerService = customerService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var customer = await _customerService.GetAllAsync();

            var customerDto = _mapper.Map<List<CustomerDto>>(customer.ToList());

            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customerDto));

        }
    }
}