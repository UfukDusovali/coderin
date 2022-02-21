using Coderin.BLL;
using Coderin.Entity;
using Coderin.UI.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coderin.UI.Areas.Admin.Controllers
{
    public class ProTitlesController : BaseController
    {
        ProTitleRepository protitlesRepository = new ProTitleRepository();
        TagRepository tagRepository = new TagRepository();
        CoderinDBContext db = new CoderinDBContext();
        // GET: Admin/ProTitles
        public ActionResult Index(Tag tag)
        {
         
            return View(protitlesRepository.GetAll());
        }

        // GET: Admin/ProTitles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ProTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProTitles/Create
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

        // GET: Admin/ProTitles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ProTitles/Edit/5
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

        // GET: Admin/ProTitles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ProTitles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
