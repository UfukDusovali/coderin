using Coderin.BLL;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Coderin.UI.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        UserRepository userRepository = new UserRepository();
        UserDetailRepository userDetailRepository = new UserDetailRepository();
        FollowRepository followRepository = new FollowRepository();
        public ActionResult Index()
        {
            return View(userRepository.GetAll());
        }
        public JsonResult IsMail(string Mail)
        {
            return Json(!userRepository.Any(x => x.Mail == Mail), JsonRequestBehavior.AllowGet);
        }

        // GET: User/Details/5
        public ActionResult Details(Guid id)
        {
            return View(userRepository.Get(id));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            bool sonuc = false;
            try
            {
                User ekle = new User();
                ekle.AuthorityId = Guid.Parse("6f13f1ed-71f8-40bf-883c-8eab23a9627a");
                //ekle.Id = Guid.NewGuid();
                ekle.Name = collection["Name"];
                ekle.Surname = collection["Surname"];
                ekle.Mail = collection["Mail"];
                ekle.Password = (string)MD5Sifrele(collection["Password"]);
                sonuc = userRepository.Add(ekle);
                sonuc = userRepository.Save();
                if (sonuc)
                {
                    UserDetail _ekle = new UserDetail();
                    _ekle.Id = ekle.Id;
                    _ekle.Name = "name";
                    _ekle.Avatar = Guid.Parse("13159537-b2e7-4120-8dbe-2d0d0b9a53c3");
                    _ekle.Working = false;
                    _ekle.CompanyName = "Coderin";
                    _ekle.Gender = false;
                    _ekle.BirthDate = DateTime.Now;
                    _ekle.Phone = "12345678901";
                    _ekle.CountryId = Guid.Parse("1f3ffa83-f641-42c4-8887-4d0eb5b868f3");
                    _ekle.CityId = Guid.Parse("3b660b2d-3cb7-4774-859c-874ea303c34e");
                    _ekle.TownId = Guid.Parse("a3225cae-405f-41b0-ae20-d450d79689fd");

                    sonuc = userDetailRepository.Add(_ekle);
                    sonuc = userDetailRepository.Save();
                    Session["userId"] = ekle.Id;
                }
               



                // TODO: Add insert logic here
                //userRepository.Add(user);
                //sonuc = userRepository.Save();
                return RedirectToAction("UserDetail/" + (Guid)ekle.Id);
            }
            catch (Exception ex)
            {
                return View();
            }
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

        // GET: User/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(userRepository.Get(id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            bool sonuc = false;
            try
            {
                // TODO: Add update logic here
                User gelen = userRepository.Get(id);
                gelen.AuthorityId = Guid.Parse(collection["AuthorityId"]);
                gelen.Name = collection["Name"];
                gelen.Surname = collection["Surname"];
                gelen.Mail = collection["Mail"];
                gelen.Password = collection["Password"];
                userRepository.Update(gelen);
                sonuc = userRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UserDetail(Guid id)
        {
            return View(userDetailRepository.Get(id));
        }

        [HttpPost]
        public ActionResult UserDetail(Guid id, UserDetail item)
        {
            bool sonuc = false;
            try
            {
                // TODO: Add update logic here
                UserDetail gelen = userDetailRepository.Get(id);

                gelen.Working = item.Working;
                gelen.CompanyName = item.CompanyName;
                gelen.Gender = item.Gender;
                gelen.BirthDate = item.BirthDate;
                gelen.Phone = item.Phone;
                gelen.CountryId = item.CountryId;
                gelen.CityId = item.CityId;
                sonuc = userDetailRepository.Save();
                return Redirect("~/User/UserDetail/"+ id);
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(Guid id)
        {
            bool sonuc = false;
            userRepository.Remove(id);
            sonuc = userRepository.Save();
            return RedirectToAction("Index");
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            string email = collection["txtEmail"];
            string password = collection["txtPassword"];
            password = MD5Sifrele(password);
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                TempData["error"] = "<script>alert('Email ve Şifre Girmediniz!');</script>";
            }
            else if (string.IsNullOrEmpty(email))
            {
                TempData["error"] = "<script>alert('Email Girmediniz!');</script>";
            }
            else if (string.IsNullOrEmpty(password))
            {
                TempData["error"] = "<script>alert('Parola Girmediniz!');</script>";
            }
            else
            {
                User uye = userRepository.GetBy(x => x.Mail == email && x.Password == password).SingleOrDefault();
                if (uye != null)
                {
                    Session["UserId"] = uye.Id;
                    return Redirect(Url.Action("Index", "Home"));
                }
                else
                {
                    TempData["error"] = "<script>alert('Email yada Parola hatalı!');</script>";
                }
            }
            return View();
        }

        public ActionResult Profil(Guid id)
        {
            return View(userRepository.Get(id));
        }

        public ActionResult Index(Guid id)
        {
            return View(userRepository.Get(followRepository.Get(id).FollowerId).Name);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect(Url.Action("Index", "Home"));
        }
        public ActionResult MyNotifications(Guid id)
        {
            return View(userRepository.Get(id));
        }
        
    }
}
