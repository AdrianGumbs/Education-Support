using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education_Support.Controllers
{
    public class ContactController : Controller
    {
        // GET: /Contact/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Contact/Details/
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: /Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Contact/Edit/
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: /Contact/Edit/
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Contact/Delete/
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
