using Coderin.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coderin.UI.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {
            ViewData["Users"] = new UserRepository().GetAll();
            ViewData["Authorities"] = new AuthorityRepository().GetAll();
            ViewData["Countries"] = new CountryRepository().GetAll();
            ViewData["Cities"] = new CityRepository().GetAll();
           
        }
    }
}