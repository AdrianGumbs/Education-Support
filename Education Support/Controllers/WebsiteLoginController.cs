using Framework.Domain;
using Framework.Interfaces;
using Framework.Repos;
using System;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class WebsiteLoginController : Controller
    {
        Guid check;
        string errorMessage = "An error has occurried";
        IWebsiteLoginRepo loginRepo;
        IWebsiteRepo websiteRepo = new WebsiteRepo();

        public WebsiteLoginController()
        {
            loginRepo = new WebsiteLoginRepo();
        }
        public WebsiteLoginController(IWebsiteLoginRepo repo)
        {
            loginRepo = repo;
        }

        // GET: /Login/Create
        public ActionResult Add(Guid id)
        {
            var model = new WebsiteLoginModel();
            model.Website = websiteRepo.Load(id);
            return View(model);
        }

        // POST: /Login/Create
        [HttpPost]
        public ActionResult Add(WebsiteLoginModel a)
        {
            try
            {
             if (!ModelState.IsValid)
                {
                    return View("Create", a);
                }
                WebsiteLogin login = new WebsiteLogin();
                a.PopulateDomain(login);
                login.Website = a.Website;
                loginRepo.Save(login);
                return RedirectToAction("Details", "Website", new { id = login.Website.Id });
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(a);
            }
        }

        // GET: /Login/Edit/
        public ActionResult Edit(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            WebsiteLoginModel c = new WebsiteLoginModel();
            WebsiteLogin login = loginRepo.Load(id);
            c.PopulateModel(login);
            return View(c);
        }

        // POST: /Login/Edit/
        [HttpPost]
        public ActionResult Edit(WebsiteLoginModel e)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", e);
                }
                WebsiteLogin login = loginRepo.Load(e.Login_Id);
                e.PopulateDomain(login);
                loginRepo.Save(login);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(e);
            }
        }

        // GET: /Login/Delete/
        public ActionResult Delete(Guid id)
        {
            WebsiteLogin login = loginRepo.Load(id);
            loginRepo.Delete(login);
            TempData["alertMessage"] = "Account has been deleted.";
            return RedirectToAction("Index");
        }
    }
}
