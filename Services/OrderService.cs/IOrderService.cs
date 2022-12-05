using CDCNfinal.API.Data.DTOs;

namespace CDCFinal.API.Services.OrderService.cs
{
    public interface IOrderService
    {
        List<OrderOverviewDto>? GetListOrders();

        bool SaveChange();
        void CreateOrder(OrderDTO oderDTO);

        OrderDetailDTO? GetOrderDetail(int idOrder);

        List<OrderOverviewDto>? GetListOrderByStatus(int idStatus);

        void ConfirmOrder(int idOrder);

        void CancelOrder(int idOrder);
    }
}