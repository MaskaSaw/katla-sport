using AutoMapper;
using KatlaSport.DataAccess.ClientCatalogue;

namespace KatlaSport.Services.ClientManagment
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
