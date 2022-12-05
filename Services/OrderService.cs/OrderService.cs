using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CDCNfinal.API.Data.DTOs;
using CDCNfinal.API.Data;
using CDCNfinal.API.Data.Entities;

namespace CDCFinal.API.Services.OrderService.cs
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OrderService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CancelOrder(int idOrder)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == idOrder);
            if(order.StatusOrder == (int)Status.StatusEnum.Unconfimred){
                order.StatusOrder = (int)Status.StatusEnum.Cancelled;
            }
        }

        public void ConfirmOrder(int idOrder)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == idOrder);
            if(order.StatusOrder == (int)Status.StatusEnum.Unconfimred){
                order.StatusOrder = (int)Status.StatusEnum.Confirmed;
            }
        }

        public void CreateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<OrderDTO, Order>(orderDTO);
            order.StatusOrder = ((int)Status.StatusEnum.Unconfimred);
            order.OrderAt = DateTime.Now;
            _context.Orders.Add(order);
        }

        public List<OrderOverviewDto>? GetListOrderByStatus(int idStatus)
        {
            if(!Enum.IsDefined(typeof(Status.StatusEnum), idStatus))
            {
                return GetListOrders();
            }
            var orders = _context.Orders.Include(o => o.Product).Where(o => o.StatusOrder == idStatus).ToList();
            return _mapper.Map<List<Order>, List<OrderOverviewDto>>(orders);
        }

        public List<OrderOverviewDto> GetListOrders()
        {
            var allOrder = _context.Orders.Include(o => o.Product).ToList();
            return _mapper.Map<List<Order>, List<OrderOverviewDto>>(allOrder);
        }

        public OrderDetailDTO? GetOrderDetail(int idOrder)
        {
            var order = _context.Orders.Include(o => o.Product).FirstOrDefault(o => o.Id == idOrder);
            if(order == null) return null;
            return new OrderDetailDTO()
            {
                Id = order.Id,
                Product = _mapper.Map<Product, ProductDetailDTO>(order.Product),
                CustomerName = order.CustomerName,
                CustomerAddress = order.CustomerAddress,
                PhoneNumber = order.PhoneNumber,
                StatusOrder = ((Status.StatusEnum)order.StatusOrder).ToString(),
                OrderAt = order.OrderAt
            };
        }

        public bool SaveChange()
        {
            return _context.SaveChanges() > 0;
        }

        
    }
}