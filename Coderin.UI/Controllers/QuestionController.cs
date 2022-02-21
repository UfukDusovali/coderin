using Coderin.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coderin.UI.Controllers
{
    public class QuestionController : BaseController
    {
        // GET: Question
        QuestionRepository questionRepository = new QuestionRepository();
        public ActionResult Index(string id)
        {
            string[] URLparcala = id.Split('-');
            string Id = URLparcala[URLparcala.Count() - 5] + "-" + URLparcala[URLparcala.Count() - 4] + "-" + URLparcala[URLparcala.Count() - 3] + "-" + URLparcala[URLparcala.Count() - 2] + "-" + URLparcala[URLparcala.Count() - 1];
            
            Coderin.Entity.Question item = questionRepository.Get(Guid.Parse(Id));
            item.Views = item.Views + 1;
            questionRepository.Update(item);
            questionRepository.Save();
            
            return View(item);
        }
        public ActionResult MyNotifications()
        {
            return View();
        }

        public ActionResult MyAnswer()
        {
            return View();
        }
    }
}