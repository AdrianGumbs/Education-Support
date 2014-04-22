using Framework.Domain;
using Framework.Interfaces;
using Framework.Repos;
using System;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class SiteController : Controller
    {
        Guid check;
        string errorMessage = "An error has occurried";
        ISiteRepo siteRepo;
        IAuthorityRepo authorityRepo = new AuthorityRepo();

        public SiteController()
        {
            siteRepo = new SiteRepo();
        }
        public SiteController(ISiteRepo repo)
        {
            this.siteRepo = repo;
        }

        // GET: /Site/Details/
        public ActionResult Details(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            SiteModel s = new SiteModel();
            Site site = siteRepo.Load(id);
            s.PopulateModel(site);
            s.Authority = siteRepo.SiteAuthority(site);
            return View(s);
        }

        // GET: /Site/Create
        public ActionResult Add(Guid id)
        {
            var model = new SiteModel();
            model.Authority = authorityRepo.Load(id);
            return View(model);
        }

        // POST: /Site/Create
        [HttpPost]
        public ActionResult Add(SiteModel a)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", a);
                }
                Site site = new Site();
                a.PopulateDomain(site);
                a.Authority = siteRepo.SiteAuthority(site);
                siteRepo.Save(site);
                return RedirectToAction("Details", "Authority", new { id = a.Authority.Id });
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(a);
            }
        }

        // GET: /Site/Edit/
        public ActionResult Edit(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            Site site = siteRepo.Load(id);
            SiteModel s = new SiteModel();
            s.PopulateModel(site);
            s.Authority = siteRepo.SiteAuthority(site);
            return View(s);
        }

        // POST: /Site/Edit/
        [HttpPost]
        public ActionResult Edit(SiteModel e)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", e);
                }
                Site site = siteRepo.Load(e.Site_Id);
                e.PopulateDomain(site);
                e.Authority = siteRepo.SiteAuthority(site);
                siteRepo.Save(site);
                return RedirectToAction("Details", "Authority", new { id = site.Authority.Id });
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(e);
            }
        }

        // GET: /Site/Delete/
        public ActionResult Delete(Guid id)
        {
            Site site = siteRepo.Load(id);
            siteRepo.Delete(site);
            TempData["alertMessage"] = "Site has been deleted.";
            return RedirectToAction("Index", "Authority");
        }
    }
}
