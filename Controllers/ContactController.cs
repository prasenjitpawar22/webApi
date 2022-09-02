// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using MyWebAPICore.Data;
// using MyWebAPICore.Models;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPICore.Data;
using MyWebAPICore.Models;
using MyWebAPICore.Repositories;

namespace MyWebAPICore.Controllers;

[ApiController] //telling this is a api controller
// [Route("api/contacts")]
[Route("api/[controller]")] //controller name 
public class ContactController : Controller
{
    private IRespository<Contacts, AddContactRequest, Guid> _contactRespository;

    public ContactController(IRespository<Contacts, AddContactRequest, Guid> contactRepository)
    {
        _contactRespository = contactRepository;
    }

    //get method (read)
    [HttpGet]
    public async Task<IActionResult> GetAction()
    {
        var d = await _contactRespository.GetAllAction();
        return Ok(d);
        // return View(); 
    }

    //get single contact
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetContact([FromRoute] Guid id)
    {
        var contact = await _contactRespository.GetSingleAction(id);

        if (contact == null)
        {
            return NotFound();
        }
        return Ok(contact);
    }

    //create method 
    [HttpPost]
    public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
    {

        var contact = await _contactRespository.AddAction(addContactRequest);
        return Ok(contact);
    }

    //update method
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateContact([FromRoute] Guid id, AddContactRequest updateContactRequest)
    {
        var contact = await _contactRespository.UpdateAction(id, updateContactRequest);

        return Ok(contact);

    }

    //delete method 
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
    {

        var contact = await _contactRespository.DeleteAction(id);
        return Ok(contact);
    }
}