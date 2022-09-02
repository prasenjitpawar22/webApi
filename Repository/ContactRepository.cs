

using MyWebAPICore.Models;
using MyWebAPICore.Data;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPICore.Repositories;

public class ContactRepository : IRespository<Contacts, AddContactRequest, Guid>
{
    private ApplicationDbContext _db;

    public ContactRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Contacts> AddAction(AddContactRequest entity)
    {

        var contact = new Contacts()
        {
            Id = Guid.NewGuid(),
            Address = entity.Address,
            Email = entity.Email,
            FullName = entity.FullName,
            Phone = entity.Phone
        };

        await _db.Contact.AddAsync(contact);
        return contact;
    }

    public async Task<Contacts> DeleteAction(Guid id)
    {
        var contact = await _db.Contact.FindAsync(id);

        if (contact != null)
        {
            _db.Remove(contact);
            await _db.SaveChangesAsync();

        }

        return contact;
    }

    public async Task<IEnumerable<Contacts>> GetAllAction()
    {
        return await _db.Contact.ToListAsync();
    }

    public async Task<Contacts> GetSingleAction(Guid id)
    {
        return await _db.Contact.FindAsync(id);
    }

    public async Task SaveAction()
    {
        await _db.SaveChangesAsync();

    }


    public async Task<Contacts> UpdateAction(Guid id, AddContactRequest entity)
    {
        var contact = await _db.Contact.FindAsync(id);

        contact.FullName = entity.FullName;
        contact.Address = entity.Address;
        contact.Email = entity.Email;
        contact.Phone = entity.Phone;

        await _db.SaveChangesAsync();

        return contact;
    }
}
