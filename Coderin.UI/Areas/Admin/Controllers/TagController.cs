using Coderin.BLL;
using Coderin.Entity;
using Coderin.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coderin.UI.Areas.Admin.Controllers
{
    public class TagController : BaseController
    {
        // GET: Admin/Tag
     
        TagRepository tagRepository = new TagRepository();
        public ActionResult Index()
        {
            return View(tagRepository.GetAll());
        }

        // GET: Admin/Tag/Details/5
        public ActionResult Details(Guid id)
        {
            return View(tagRepository.Get(id));
        }

        // GET: Admin/Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tag/Create
        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            try
            {
                tagRepository.Add(tag);
                tagRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET: Admin/Tag/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(tagRepository.Get(id));
        }

        // POST: Admin/Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
           
            try
            {
                // TODO: Add update logic here
                Tag gelen = tagRepository.Get(id);             
                gelen.Name = collection["Name"];
                string a = collection["IsProTag"];
                if (a=="false")
                {
                    gelen.IsProTag = true;
                }
                else
                {
                    gelen.IsProTag = false;
                }
                
                tagRepository.Update(gelen);
                 tagRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            
            tagRepository.Remove(id);
            tagRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Ata(Guid id)
        {
            return View();
        }
    }
}
