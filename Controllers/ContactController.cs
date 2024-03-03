using MGQS.Dto;
using MGQS.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace MGQS.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet("get-contact-list")]
        public IActionResult Index()
        {
            var contactlist = _contactService.GetContacts();
            return View(contactlist);
        }

        [HttpGet("create-contact")]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost("create-contact")]
        public IActionResult CreateContact(CreateContact request)
        {

            _contactService.CreateContat(request);
            return RedirectToAction("Index");
        }

        [HttpGet("edit-contact/{id}")]
        public IActionResult EditContact([FromRoute] int id)
        {
            var data = _contactService.GetContactById(id);
            return View(data);
        }


        [HttpPost("edit-contact/{id}")]
        public IActionResult EditContact([FromRoute] string id, UpdateContact request)
        {
            var dataId = int.Parse(id);
            _contactService.UpdateContact(dataId,request);
            return RedirectToAction("Index");
        }

        [HttpGet("delete-contact/{id}")]
        public IActionResult DeleteContact([FromRoute] int id)
        {
            _contactService.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
