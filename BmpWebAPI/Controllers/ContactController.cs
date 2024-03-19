using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.ContactDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetContact()
        {
            var result = _contactService.GetAllContactsAdmin();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContact(ContactAddDTO contactAddDTO)
        {
            var result = await _contactService.AddContactAsync(contactAddDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            var result = _contactService.GetContactById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpDelete("RemoveContactById/{id}")]
        public IActionResult RemoveContactById(int id)
        {
            var result = _contactService.RemoveContact(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
