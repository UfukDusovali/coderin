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
    public class QuestionController : BaseController
    {
        // GET: Admin/Question
        QuestionRepository questionRepository = new QuestionRepository();
        public ActionResult Index()
        {
            return View(questionRepository.GetAll());
        }

        // GET: Admin/Question/Details/5
        public ActionResult Details(Guid id)
        {
            return View(questionRepository.Get(id));
        }

        // GET: Admin/Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Question/Create
        [HttpPost]
        public ActionResult Create(Question question)
        {
            try
            {
                questionRepository.Add(question);
                questionRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Question/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(questionRepository.Get(id));
        }

        // POST: Admin/Question/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                Question gelen = questionRepository.Get(id);
                gelen.UserId = Guid.Parse(collection["UserId"]);
                gelen.Name = collection["Name"];
                gelen.NameUrl = collection["NameUrl"];
                gelen.QuestionBody = collection["QuestionBody"];
                bool sonuc = questionRepository.Update(gelen);
                TempData["mesaj"] = sonuc ? "<script>alert('Soru Güncellendi!');</script>" : "<script>alert('HATA OLUŞTU!');</script>";
                questionRepository.Save();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Question/Delete/5
        public ActionResult Delete(Guid id)
        {
            questionRepository.Remove(id);
            questionRepository.Save();
            return RedirectToAction("Index");
        }

        // POST: Admin/Question/Delete/5
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
