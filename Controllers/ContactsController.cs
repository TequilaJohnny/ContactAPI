using Microsoft.AspNetCore.Mvc;
using contactApi.Models;
using contactApi.Services;

namespace contactApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactService.GetAllContacts();
            return Ok(contacts);
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedContacts(int pageNumber = 1, int pageSize = 10)
        {
            var paginatedContacts = await _contactService.GetPaginatedContacts(pageNumber, pageSize);
            return Ok(paginatedContacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _contactService.GetContactById(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] Contact contact)
        {
            await _contactService.AddContact(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] Contact contact)
        {
            await _contactService.UpdateContact(id, contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteContact(id);
            return NoContent();
        }
    }
}
