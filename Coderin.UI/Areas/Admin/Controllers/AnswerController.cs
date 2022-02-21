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
    public class AnswerController : BaseController
    {
        AnswerRepository answerRepository = new AnswerRepository();
        // GET: Admin/Answer
        public ActionResult Index()
        {
            return View(answerRepository.GetAll());
        }

        // GET: Admin/Answer/Details/5
        public ActionResult Details(Guid id)
        {
            return View(answerRepository.Get(id));
        }

        // GET: Admin/Answer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Answer/Create
        [HttpPost]
        public ActionResult Create(Answer answer)
        {
            try
            {
                answerRepository.Add(answer);
                answerRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Answer/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(answerRepository.Get(id));
        }

        // POST: Admin/Answer/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                Answer gelen = answerRepository.Get(id);
                gelen.UserId = Guid.Parse(collection["UserId"]);
                gelen.Name = collection["Name"];
                gelen.NameUrl = collection["NameUrl"];
                gelen.AnswerBody = collection["AnswerBody"];
                bool sonuc = answerRepository.Update(gelen);
                TempData["mesaj"] = sonuc ? "<script>alert('Cevap Güncellendi!');</script>" : "<script>alert('HATA OLUŞTU!');</script>";
                answerRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Answer/Delete/5
        public ActionResult Delete(Guid id)
        {
            answerRepository.Remove(id);
            answerRepository.Save();
            return View();
        }

        // POST: Admin/Answer/Delete/5
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
