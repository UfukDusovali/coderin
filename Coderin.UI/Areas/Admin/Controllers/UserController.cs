using Coderin.BLL;
using Coderin.Entity;
using Coderin.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Coderin.UI.Areas.Admin.Controllers
{
    public class UserController :BaseController
    {
        // GET: Admin/User
        UserRepository userRepository = new UserRepository();
        public ActionResult Index()
        {
            return View(userRepository.GetAll());
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(Guid id)
        {
            return View(userRepository.Get(id));
        }

        // GET: Admin/User/Create
       

        // POST: Admin/User/Create
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

        // GET: Admin/User/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(userRepository.Get(id));
        }


        private string MD5Sifrele(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btr = Encoding.UTF8.GetBytes(password); btr = md5.ComputeHash(btr);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            
            try
            {
                User gelen = userRepository.Get(id);
                gelen.AuthorityId = Guid.Parse(collection["AuthorityId"]);
                gelen.Name = collection["Name"];
                gelen.Surname = collection["Surname"];
                gelen.Mail = collection["Mail"];
                gelen.Password = (string)MD5Sifrele(collection["Password"]);
                userRepository.Update(gelen);
                userRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(Guid id)
        {

            userRepository.Remove(id);
            userRepository.Save();
            return RedirectToAction("Index");
        }


        public ActionResult Login()
        {
            return View();
        }

       
        public JsonResult LoginJson(string id,string id2)
        {
            User user = userRepository.GetBy(x => x.Mail == id && x.Password == id2).SingleOrDefault();
            if (user != null)
            {
                Session["userId"] = user.Id;
                return Json("true");

            }
            else
            {
                return Json("false");
            }
        }

    }
}
