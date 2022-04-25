using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class DiscountsController : CustomBaseController
    {
        private readonly IDiscountService _discountService;
        //private readonly IOrderService _orderService;
        //private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;


        public DiscountsController(IDiscountService discountService, IMapper mapper /*IOrderService orderService, ICustomerService customerTypeService*/)
        {
            _discountService = discountService;
            _mapper = mapper;
            //_orderService = orderService;
            //_customerService = customerTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var discount = await _discountService.GetAllAsync();

            var discountDto = _mapper.Map<List<DiscountDto>>(discount.ToList());

            return CreateActionResult(CustomResponseDto<List<DiscountDto>>.Success(200, discountDto));

        }
        [ServiceFilter(typeof(NotFoundFilter<Discount>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountService.GetByIdAsync(id);

            var discountDto = _mapper.Map<DiscountDto>(discount);

            return CreateActionResult(CustomResponseDto<DiscountDto>.Success(200, discountDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(DiscountDto discountDto)
        {
            var response = await _discountService.AddAsync(_mapper.Map<Discount>(discountDto));

            return CreateActionResult(CustomResponseDto<DiscountDto>.Success(201, discountDto));
        }

        [HttpPost]
        [Route("/api/[controller]/[action]")]
        public async Task<IActionResult> InvoiceCalculate(OrderWithCustomerDto orderWithCustomerDto)
        {
           

                return CreateActionResult(await _discountService.GetInvoiceCalculate(orderWithCustomerDto));

            

        }

    }
}