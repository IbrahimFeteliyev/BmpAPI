using AutoMapper;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.ContactDTOs;
using Bmp.Entities.DTOs.MapDTOs;


namespace Bmp.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactAddDTO, Contact>();
            CreateMap<Contact, ContactListDTO>();
            CreateMap<Contact, ContactDetailDTO>();

            CreateMap<Map, MapDTO>().ReverseMap();
            CreateMap<Map, MapAdminDTO>();
        }
    }
}
