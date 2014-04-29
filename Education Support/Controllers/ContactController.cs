using Framework.Domain;
using Framework.Interfaces;
using Framework.Repos;
using System;
using System.Web.Mvc;
using Websitet.Models;

namespace Website.Controllers
{
    public class ContactController : Controller
    {
        Guid check;
        string errorMessage = "An error has occurried";
        IContactRepo contactRepo;
        IAuthorityRepo authorityRepo = new AuthorityRepo();

        public ContactController()
        {
            contactRepo = new ContactRepo();
        }
        public ContactController(IContactRepo repo)
        {
            this.contactRepo = repo;
        }

        // GET: /Contact/Details/
        public ActionResult Details(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            ContactModel c = new ContactModel();
            Contact contact = contactRepo.Load(id);
            c.PopulateModel(contact);
            c.Authority = contactRepo.ContactAuthority(contact);
            return View(c);
        }

        // GET: /Contact/Create
        public ActionResult Add(Guid id)
        {
            var model = new ContactModel();
            model.Authority = authorityRepo.Load(id);
            return View(model);
        }

        // POST: /Contact/Create
        [HttpPost]
        public ActionResult Add(ContactModel c)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Add", c);
                }
                Contact contact = new Contact();
                c.PopulateDomain(contact);
                contact.Authority = authorityRepo.Load(c.Authority.Id);
                contactRepo.Save(contact);
                return RedirectToAction("Details","Authority", new { id = contact.Authority.Id });
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(c);
            }
        }

        // GET: /Contact/Edit/
        public ActionResult Edit(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            Contact contact = contactRepo.Load(id);
            ContactModel c = new ContactModel();
            c.PopulateModel(contact);
            c.Authority = contactRepo.ContactAuthority(contact);
            return View(c);
        }

        // POST: /Contact/Edit/
        [HttpPost]
        public ActionResult Edit(ContactModel c)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", c);
                }
                Contact contact = contactRepo.Load(c.Contact_Id);
                c.PopulateDomain(contact);
                c.Authority = contactRepo.ContactAuthority(contact);
                contactRepo.Save(contact);
                return RedirectToAction("Details", new { id = contact.Id });
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(c);
            }
        }

        // GET: /Contact/Delete/
        public ActionResult Delete(Guid id)
        {
            Contact contact = contactRepo.Load(id);
            contactRepo.Delete(contact);
            TempData["alertMessage"] = "Contact has been deleted.";
            return RedirectToAction("Details", "Authority", new { id = contact.Authority.Id });
        }
    }
}
