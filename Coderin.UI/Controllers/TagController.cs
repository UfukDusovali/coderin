using Coderin.BLL;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coderin.UI.Controllers
{
    public class TagController : Controller
    {
        TagRepository tagRepository = new TagRepository();
        // GET: Tag
        public ActionResult Index()
        {
            return View(tagRepository.GetAll().OrderBy(x => x.Name));
        }
        public ActionResult ByTagNormal(string id)
        {
            string[] URLparcala = id.Split('-');
            string Id = URLparcala[URLparcala.Count() - 5] + "-" + URLparcala[URLparcala.Count() - 4] + "-" + URLparcala[URLparcala.Count() - 3] + "-" + URLparcala[URLparcala.Count() - 2] + "-" + URLparcala[URLparcala.Count() - 1];
            Tag item = tagRepository.Get(Guid.Parse(Id));

            return View(item);
        }
    }
}