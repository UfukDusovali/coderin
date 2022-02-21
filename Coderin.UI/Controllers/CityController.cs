using Coderin.BLL;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coderin.UI.Controllers
{
    public class CityController : BaseController
    {
        // GET: City

        CityRepository cityRepository = new CityRepository();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCities(Guid id)
        {
            List<City> cList = cityRepository.GetBy(x => x.CountryId == id).Select(x => new City
            {
                Id = x.Id,
                Name = x.Name
            }).OrderBy(x => x.Name).ToList();

            return Json(cList, JsonRequestBehavior.AllowGet);
        }
    }
}