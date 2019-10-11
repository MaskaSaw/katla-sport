using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.OrderCatalogue;

namespace KatlaSport.Services.OrderManagement
{
    internal sealed class OrderManagmentService : IOrderService
    {
        IOrderContext _context;

        public OrderManagmentService(IOrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<OrderRequest>> GetOrdersAsync()
        {
            var dbOrders = await _context.Orders.OrderBy(o => o.Id).ToListAsync();
            var orders = dbOrders.Select(o => Mapper.Map<Order, OrderRequest>(o)).ToList();

            return orders;
        }

        public async Task<OrderRequest> GetOrderAsync(int orderid)
        {
            var dbOrders = await _context.Orders.Where(o => o.Id == orderid).ToArrayAsync();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var order = Mapper.Map<Order, OrderRequest>(dbOrders[0]);

            return order;
        }

        public async Task<Order> CreateOrderAsync(OrderRequest createRequest)
        {
            var dbOrders = await _context.Orders.Where(o => (o.ManagerId == createRequest.ManagerId && o.ClientId == createRequest.ClientId)).ToArrayAsync();
            if (dbOrders.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var order = Mapper.Map<OrderRequest, Order>(createRequest);
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> UpdateOrderAsync(int orderid, OrderRequest updateRequest)
        {
            var dbOrders = await _context.Orders.Where(o => (o.ManagerId == updateRequest.ManagerId && o.ClientId == updateRequest.ClientId)).ToArrayAsync();
            if (dbOrders.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbOrders = _context.Orders.Where(o => o.Id == orderid).ToArray();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbOrder = dbOrders[0];

            dbOrder.ManagerId = updateRequest.ManagerId;
            dbOrder.ClientId = updateRequest.ClientId;
            await _context.SaveChangesAsync();

            return dbOrder;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var dbOrders = await _context.Orders.Where(o => o.Id == orderId).ToArrayAsync();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            _context.Orders.Remove(dbOrders[0]);
            await _context.SaveChangesAsync();
        }
    }
}
