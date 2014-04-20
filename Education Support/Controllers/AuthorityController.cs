using Framework.Domain;
using Framework.Interfaces;
using Framework.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Website.Models;
using Website.Models.Lists;

namespace Website.Controllers
{
    public class AuthorityController : Controller
    {
        Guid check;
        string errorMessage = "An error has occurried";
        IAuthorityRepo authorityRepo = new AuthorityRepo();

        public AuthorityController()
        {
            authorityRepo = new AuthorityRepo();
        }

        public AuthorityController(IAuthorityRepo repo)
        {
            this.authorityRepo = repo;
        }

        // GET: /Authority/
        public ActionResult Index()
        {
            var model = new AuthorityListModel(authorityRepo);
            return View(model);
        }

        // POST: /Authority/
        [HttpPost]
        public ActionResult Index(string search)
        {
            var model = new AuthorityListModel(authorityRepo, search);
            return View(model);
        }

        public JsonResult AuthoritiesList(string term)
        {
            var _model = new AuthorityListModel(authorityRepo, term);
            List<string> authorities;
            authorities = _model.AuthorityList
                .Where(m => m.Name.ToUpper().Contains(term.ToUpper()))
                .Select(y => y.Name).ToList();
            var result = Json(authorities, JsonRequestBehavior.AllowGet);
            return Json(result);
        }

        // GET: /Authority/Details/5
        public ActionResult Details(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            Authority authority = authorityRepo.Load(id);
            AuthorityModel a = new AuthorityModel();
            a.PopulateModel(authority);
            a.Contacts = authorityRepo.LoadContactsByAuthority(authority);
            a.Sites = authorityRepo.LoadSitesByAuthority(authority);
            //a.Versions = authorityRepo.LoadSoftwareByAuthority(authority);
            return View(a);
        }

        // GET: /Authority/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: /Authority/Create
        [HttpPost]
        public ActionResult Add(AuthorityModel a)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", a);
                }
                Authority authority = new Authority();
                a.PopulateDomain(authority);
                authorityRepo.Save(authority);
                TempData["alertMessage"] = "Authority " + a.Name + " has been added.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View();
            }
        }

        // GET: /Authority/Edit/
        public ActionResult Edit(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            Authority authority = authorityRepo.Load(id);
            AuthorityModel e = new AuthorityModel();
            e.PopulateModel(authority);
            return View(e);
        }

        // POST: /Authority/Edit/
        [HttpPost]
        public ActionResult Edit(AuthorityModel e)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", e);
                }
                Authority authority = new Authority();
                e.PopulateDomain(authority);
                authority.Id = e.Id;
                authorityRepo.Save(authority);
                TempData["alertMessage"] = "Changes to " + e.Name + " have been added.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View();
            }
        }

        // GET: /Authority/Delete/
        public ActionResult Delete(Guid id)
        {
            Authority authority = authorityRepo.Load(id);
            authorityRepo.Remove(authority);
            TempData["alertMessage"] = "Authority has been deleted.";
            return RedirectToAction("Index");
        }

    }
}
