using AutoMapper;
using KatlaSport.DataAccess.OrderCatalogue;

namespace KatlaSport.Services.OrderManagement
{
    public sealed class OrderMappingProfile : Profile
    {

        public OrderMappingProfile()
        {
            CreateMap<OrderRequest, Order>();
            CreateMap<Order, OrderRequest>();
        }
    }
}
