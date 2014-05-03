using Framework.Domain;
using Framework.Interfaces;
using Framework.Repos;
using System;
using System.Web.Mvc;
using Website.Models;
using Website.Models.Lists;

namespace Website.Controllers
{
    public class WebsiteController : Controller
    {
        Guid check;
        string errorMessage = "An error has occurried";
        IWebsiteRepo websiteRepo;
        ISoftwareRepo softwareRepo = new SoftwareRepo();
        IAuthorityRepo authorityRepo = new AuthorityRepo();

        public WebsiteController()
        {
            websiteRepo = new WebsiteRepo();
        }
        public WebsiteController(IWebsiteRepo repo)
        {
            this.websiteRepo = repo;
        }

        // GET: /Website/
        public ActionResult Index()
        {
            var model = new WebsiteListModel(websiteRepo);
            return View(model);
        }

        // GET: /Website/
        [HttpPost]
        public ActionResult Index(string term)
        {
            try
            {
                var model = new WebsiteListModel(websiteRepo, term);
                return View(model);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        // GET: /Website/Details/
        public ActionResult Details(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            WebsiteModel w = new WebsiteModel();
            WebSite website = websiteRepo.Load(id);
            w.PopulateModel(website);
            w.Authority = websiteRepo.LoadWebsiteAuthority(website);
            w.Version = websiteRepo.LoadWebsiteVersion(website);
            w.Server = websiteRepo.LoadWebsiteServer(website);
            return View(w);
        }

        // GET: /Website/Create
        public ActionResult Add(Guid id)
        {
            var model = new WebsiteModel();
            model.Authority = authorityRepo.Load(id);
            model.LoadSoftware(softwareRepo);
            return View(model);
        }

        // POST: /Website/Create
        [HttpPost]
        public ActionResult Add(WebsiteModel w)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Add", w);
                }
                WebSite website = new WebSite();
                w.PopulateDomain(website);
                website.Authority = authorityRepo.Load(w.Authority.Id);
                website.Software = softwareRepo.Load(w.Software.Id);
                websiteRepo.Save(website);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(w);
            }
        }

        // GET: /Website/Edit/
        public ActionResult Edit(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            WebsiteModel w = new WebsiteModel();
            WebSite website = websiteRepo.Load(id);
            w.PopulateModel(website);
            return View(w);
        }

        // POST: /Website/Edit/
        [HttpPost]
        public ActionResult Edit(WebsiteModel w)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", w);
                }
                WebSite website = websiteRepo.Load(w.Website_Id);
                w.PopulateDomain(website);
                websiteRepo.Save(website);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(w);
            }
        }

        // GET: /Website/Delete/
        public ActionResult Delete(Guid id)
        {
            WebSite website = websiteRepo.Load(id);
            websiteRepo.Delete(website);
            TempData["alertMessage"] = website.Url + " has been deleted.";
            return RedirectToAction("Index");
        }
    }
}
