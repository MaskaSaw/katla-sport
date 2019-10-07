using AutoMapper;
using KatlaSport.DataAccess.ManagerCatalogue;

namespace KatlaSport.Services.ManagerManagement
{
    public sealed class ManagerMappingProfile : Profile
    {
        public ManagerMappingProfile()
        {
            CreateMap<ManagerRequest, Manager>();
            CreateMap<Manager, ManagerRequest>();
        }
    }
}
