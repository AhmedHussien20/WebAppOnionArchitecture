using BusinessLayer.Heplers;
using BusinessLayer.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAppOnionArchitecture.Helper;
using BusinessLayer.DTOs;

namespace WebAppOnionArchitecture.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    

    public class OrderHeaderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderHeaderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
         
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> GetOrder([FromBody] CustomListParam lstParams)
        {
            var response = new BaseResponse();

            try
            {
                response.Data = _orderService.GetOrders(lstParams).Result;
                response.IsSuccess = true;
                response.GetHttpResponse(ResponseType.Ok);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("AddOrder")]
        public  IActionResult  AddOrder(AddOrderDTO dto)
        {
            var response = new BaseResponse();

            try
            {
                var EntryUser = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
                _orderService.AddOrder(dto,EntryUser);
                response.IsSuccess = true;
                response.GetHttpResponse(ResponseType.Ok);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

   
}
