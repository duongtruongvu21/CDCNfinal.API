using CDCFinal.API.Services.OrderService.cs;
using CDCNfinal.API.Data.DTOs;
using CDCNfinal.API.Data.Entities;
using CDCNfinal.API.Services.ProductServices.cs;
using Microsoft.AspNetCore.Mvc;

namespace CDCFinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }
        [HttpGet("/orders")]
        public ActionResult<IEnumerable<OrderOverviewDto>> Get()
        {
            return _orderService.GetListOrders();
        }

        [HttpGet("/orders/{id}")]
        public ActionResult<OrderDetailDTO> Get(int id)
        {
            var order = _orderService.GetOrderDetail(id);
            if(order == null) return NotFound();
            return Ok(order);
        }

        [HttpGet("/orders/status/{id}")]
        public ActionResult<List<OrderOverviewDto>> GetOrdersById(int id)
        {
            return _orderService.GetListOrderByStatus(id);
        }

        [HttpPost("/orders")]
        public ActionResult Post([FromBody] OrderDTO orderDTO)
        {
            if(_productService.GetProductById(orderDTO.ProductId) == null) return BadRequest("Product not exist");
            _orderService.CreateOrder(orderDTO);
            if(_orderService.SaveChange()) return NoContent();
            return BadRequest("Order failed");
        }

        [HttpGet("/orders/statuses")]
        public ActionResult<List<StatusDTO>> GetStatuses()
        {
            List<StatusDTO> statusDTOs = new List<StatusDTO>()
            {
                new StatusDTO(){Id = 0, Status = "Chưa xác nhận"},
                new StatusDTO(){Id = (int)Status.StatusEnum.Unconfimred, Status = "Chưa xác nhận"},
                new StatusDTO(){Id = (int)Status.StatusEnum.Confirmed, Status = "Đã xác nhận"},
                new StatusDTO(){Id = (int)Status.StatusEnum.Cancelled, Status = "Đã bị hủy"}
            };
            return statusDTOs;
        }

        [HttpPut("/orders/confirm/{idOrder}")]
        public ActionResult ConfirmOrder(int idOrder)
        {
            if(_orderService.GetOrderDetail(idOrder) == null) return BadRequest("Order not exist");
            _orderService.ConfirmOrder(idOrder);
            if(_orderService.SaveChange()) return NoContent();
            return BadRequest("Confirm order failed");
        }

        [HttpPut("/orders/cancel/{idOrder}")]
        public ActionResult CancelOrder(int idOrder)
        {
            if(_orderService.GetOrderDetail(idOrder) == null) return BadRequest("Order not exist");
            _orderService.CancelOrder(idOrder);
            if(_orderService.SaveChange()) return NoContent();
            return BadRequest("Cancel order failed");
        }
    }
}