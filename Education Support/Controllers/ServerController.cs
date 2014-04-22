using Framework.Domain;
using Framework.Interfaces;
using Framework.Repos;
using System;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class ServerController : Controller
    {
        Guid check;
        string errorMessage = "An error has occurried";

        IServerRepo serverRepo;
        IWebsiteRepo websiteRepo = new WebsiteRepo();

        public ServerController()
        {
            serverRepo = new ServerRepo();
        }
        public ServerController(IServerRepo repo)
        {
            this.serverRepo = repo;
        }

        // GET: /Server/Details/
        public ActionResult Details(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            Server server = serverRepo.Load(id);
            ServerModel s = new ServerModel();
            s.PopulateModel(server);
            s.Website = serverRepo.ServerWebsite(server);
            return View(s);
        }

        // GET: /Server/Create
        public ActionResult Add(Guid id)
        {
            var model = new ServerModel();
            model.Website = websiteRepo.Load(id);
            return View(model);
        }

        // POST: /Server/Create
        [HttpPost]
        public ActionResult Add(ServerModel s)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Add", s);
                }
                Server server = new Server();
                s.PopulateDomain(server);
                server.Website = websiteRepo.Load(s.Website.Id);
                serverRepo.Save(server);
                return RedirectToAction("Details", "Website", new { id = s.Website.Id });
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(s);
            }
        }

        // GET: /Server/Edit/
        public ActionResult Edit(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out check))
            {
                return HttpNotFound();
            }
            Server server = serverRepo.Load(id);
            ServerModel e = new ServerModel();
            e.PopulateModel(server);
            return View(e);
        }

        // POST: /Server/Edit/
        [HttpPost]
        public ActionResult Edit(ServerModel s)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", s);
                }
                Server server = new Server();
                s.PopulateDomain(server);
                server.Id = s.Server_Id;
                server.Website = websiteRepo.Load(s.Website.Id);
                serverRepo.Save(server);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["alertMessage"] = errorMessage;
                return View(s);
            }
        }

        // GET: /Server/Delete/
        public ActionResult Delete(Guid id)
        {
            Server server = serverRepo.Load(id);
            serverRepo.Delete(server);
            TempData["alertMessage"] = "Server has been deleted.";
            return RedirectToAction("Details", "Website", new { id = server.Website.Id });
        }
    }
}
