using Framework.Domain;
using Framework.Interfaces;
using Framework.Repos;
using System;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class WebsiteConfigController : Controller
    {
        Guid check;
        string errorMessage = "An error has occurried";
        IWebsiteConfigRepo configRepo;
        IWebsiteRepo websiteRepo = new WebsiteRepo();

        public WebsiteConfigController()
        {
            configRepo = new WebsiteConfigRepo();
        }
        public WebsiteConfigController(IWebsiteConfigRepo repo)
        {
            configRepo = repo;
        }

        // GET: /Config/Create
        public ActionResult Add(Guid id)
        {
            var model = new WebsiteConfigModel();
            model.Website = websiteRepo.Load(id);
            return View(model);
        }

        // POST: /Config/Create
        [HttpPost]
        public ActionResult Add(WebsiteConfigModel a)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", a);
                }
                WebsiteConfig config = new WebsiteConfig();
                a.PopulateDomain(config);
                config.Website = a.Website;
                configRepo.Save(config);
                return RedirectToAction("Details", "Website", new { id = config.Website.Id });
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(a);
            }
        }

        // GET: /Config/Edit/
        public ActionResult Edit(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            WebsiteConfigModel c = new WebsiteConfigModel();
            WebsiteConfig config = configRepo.Load(id);
            c.PopulateModel(config);
            return View(c);
        }

        // POST: /Config/Edit/
        [HttpPost]
        public ActionResult Edit(WebsiteConfigModel e)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", e);
                }
                WebsiteConfig config = configRepo.Load(e.Config_Id);
                e.PopulateDomain(config);
                configRepo.Save(config);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(e);
            }
        }

        // GET: /Config/Delete/
        public ActionResult Delete(Guid id)
        {
            WebsiteConfig config = configRepo.Load(id);
            configRepo.Delete(config);
            TempData["alertMessage"] = "The web.config details for this site have been deleted.";
            return RedirectToAction("Details", "Website", new { id = config.Website.Id });
        }
    }
}
