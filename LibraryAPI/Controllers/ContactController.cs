using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IService<Contact> _contactService;

        public ContactController(IService<Contact> contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<List<Contact>> Get()
        {
            List<Contact> contacts = _contactService.Get();

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(Guid id)
        {
            var contact = _contactService.GetById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost("save")]
        public ActionResult Insert(Contact contact)
        {
            bool result = _contactService.Insert(contact);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult Update(Contact contact)
        {
            bool result = _contactService.Update(contact);
            if (result)
                return Ok();

            return BadRequest();
        }

    }
}
