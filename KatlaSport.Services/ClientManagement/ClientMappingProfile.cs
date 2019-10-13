using AutoMapper;
using KatlaSport.DataAccess.ClientCatalogue;

namespace KatlaSport.Services.ClientManagement
{
    public sealed class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientRequest, Client>();
            CreateMap<Client, ClientRequest>();
        }
    }
}
