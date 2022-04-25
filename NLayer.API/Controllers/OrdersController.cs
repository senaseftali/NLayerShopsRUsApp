using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class OrdersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {

            _mapper = mapper;
            _orderService = orderService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var order = await _orderService.GetAllAsync();

            var orderDto = _mapper.Map<List<OrderDto>>(order.ToList());

            return CreateActionResult(CustomResponseDto<List<OrderDto>>.Success(200, orderDto));

        }
    }
}