using AutoMapper;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.ContactDTOs;


namespace Bmp.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactAddDTO, Contact>();
            CreateMap<Contact, ContactListDTO>();
            CreateMap<Contact, ContactDetailDTO>();

        }
    }
}
