using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.ContactDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Business.Abstarct
{
    public interface IContactService
    {
        IDataResult<List<ContactListDTO>> GetAllContactsAdmin();
        Task<Core.Utilities.Results.Abstract.IResult> AddContactAsync(ContactAddDTO contactAddDTO);
        IDataResult<ContactDetailDTO> GetContactById(int id);
        Core.Utilities.Results.Abstract.IResult RemoveContact(int id);
    }
}
