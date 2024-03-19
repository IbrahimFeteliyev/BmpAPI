using AutoMapper;
using Bmp.Core.Configuration;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using System.Net.Mail;
using System.Net;
using Bmp.Business.Abstarct;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.DTOs.ContactDTOs;
using Bmp.Entities.Concrete;
using Microsoft.Extensions.Configuration;

namespace Bmp.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDAL _contactDAL;
        private readonly IMapper _mapper;
        public ContactManager(IContactDAL contactDAL, IMapper mapper)
        {
            _contactDAL = contactDAL;
            _mapper = mapper;
        }

        public async Task<IResult> AddContactAsync(ContactAddDTO contactAddDTO)
        {
            var map = _mapper.Map<Contact>(contactAddDTO);
            _contactDAL.Add(map);
            string body = "<table border='1' width='100%'><tr><th></th><th>Məlumatlar</th></tr>" +
              $"<tr><td>Ad</td><td>{contactAddDTO.Name}</td></tr>" +
              $"<tr><td>Soyad</td><td>{contactAddDTO.Surname}</td></tr>" +
              $"<tr><td>Email</td><td>{contactAddDTO.Email}</td></tr>" +
              $"<tr><td>Əlaqə nömrəsi</td><td>{contactAddDTO.ContactNumber}</td></tr>" +
              $"<tr><td>Mətn</td><td>{contactAddDTO.Text}</td></tr></table>";
            SendEmail(body);

            return new SuccessResult("Contact Added");
        }
        private void SendEmail(string body)
        {
            string fromEmail = EmailConfiguration.Email;
            string fromPassword = EmailConfiguration.Password;
            using (SmtpClient client = new(EmailConfiguration.Smtp, EmailConfiguration.Port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(fromEmail, fromPassword);

                using (MailMessage mailMessage = new())
                {
                    mailMessage.From = new MailAddress(fromEmail);
                    mailMessage.To.Add(fromEmail);
                    mailMessage.Subject = $"Message from Baku Medical Plasa from - {EmailConfiguration.Email}";
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    client.Send(mailMessage);
                }
            }
        }
        public IDataResult<List<ContactListDTO>> GetAllContactsAdmin()
        {
            var contacts = _contactDAL.GetAll();
            var contactListDTOs = _mapper.Map<List<ContactListDTO>>(contacts);
            return new SuccessDataResult<List<ContactListDTO>>(contactListDTOs);
        }


        public IDataResult<ContactDetailDTO> GetContactById(int id)
        {
            var contact = _contactDAL.Get(x => x.Id == id);
            var contactDetailDTO = _mapper.Map<ContactDetailDTO>(contact);
            return new SuccessDataResult<ContactDetailDTO>(contactDetailDTO);
        }

        public IResult RemoveContact(int id)
        {
            var contact = _contactDAL.Get(x => x.Id == id);
            _contactDAL.Delete(contact);
            return new SuccessResult("Contact Deleted");
        }
    }
}
