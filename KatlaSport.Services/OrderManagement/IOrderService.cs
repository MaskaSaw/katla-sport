using System.Collections.Generic;
using System.Threading.Tasks;
using KatlaSport.DataAccess.OrderCatalogue;

namespace KatlaSport.Services.OrderManagement
{
    public interface IOrderService
    {
        Task<List<OrderRequest>> GetOrdersAsync();

        Task<OrderRequest> GetOrderAsync(int orderid);

        Task<Order> CreateOrderAsync(OrderRequest createRequest);

        Task<Order> UpdateOrderAsync(int orderid, OrderRequest updateRequest);

        Task DeleteOrderAsync(int orderid);
    }
}