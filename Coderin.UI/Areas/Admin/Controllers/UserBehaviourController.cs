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
    public class UserBehaviourController : BaseController
    {
        // GET: Admin/UserBehaviour
        UserBehaviourRepository userbehaviourRepository = new UserBehaviourRepository();
        public ActionResult Index()
        {
            return View(userbehaviourRepository.GetAll());
        }

        // GET: Admin/UserBehaviour/Details/5
        public ActionResult Details(Guid id)
        {
            return View(userbehaviourRepository.Get(id));
        }

        // GET: Admin/UserBehaviour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UserBehaviour/Create
        [HttpPost]
        public ActionResult Create(UserBehaviour userbehaviour)
        {
            try
            {
                userbehaviourRepository.Add(userbehaviour);
                userbehaviourRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/UserBehaviour/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(userbehaviourRepository.Get(id));
        }

        // POST: Admin/UserBehaviour/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                UserBehaviour gelen = userbehaviourRepository.Get(id);
                gelen.Name = collection["Name"];
                gelen.UserId = Guid.Parse(collection["UserId"]);
                gelen.CommentId = Guid.Parse(collection["CommentId"]);
                gelen.QuestionId = Guid.Parse(collection["QuestionId"]);
                gelen.AnswerId = Guid.Parse(collection["AnswerId"]);
                gelen.TagId = Guid.Parse(collection["TagId"]);
                bool sonuc = userbehaviourRepository.Update(gelen);
                TempData["mesaj"] = sonuc ? "<script>alert('Kullanıcının Davranışı Güncellendi!');</script>" : "<script>alert('HATA OLUŞTU!');</script>";
                userbehaviourRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/UserBehaviour/Delete/5
        public ActionResult Delete(Guid id)
        {
            userbehaviourRepository.Remove(id);
            userbehaviourRepository.Save();
            return View();
        }

        // POST: Admin/UserBehaviour/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
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
