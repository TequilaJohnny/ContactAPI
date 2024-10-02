using contactApi.Models;
using Microsoft.EntityFrameworkCore;

namespace contactApi.Services
{
    public class ContactService
    {
        private readonly ContactContext _context;

        public ContactService(ContactContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContact(int id, Contact contact)
        {
            if (id != contact.Id) throw new InvalidOperationException("Contact ID mismatch");

            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
