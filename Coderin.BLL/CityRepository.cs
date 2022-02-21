using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class CityRepository : IRepository<City>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(City item)
        {
            bool sonuc = false;
            try
            {
                db.Cities.Add(item);
                return sonuc = true;
            }
            catch (Exception ex)
            {
                return sonuc;
            }
        }

        public bool Remove(Guid id)
        {
            bool sonuc = false;
            try
            {
                City item = db.Cities.Find(id);
                item.Status = (int)Status.Deleted;
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool RemoveReal(Guid id)
        {
            bool sonuc = false;
            try
            {
                City item = db.Cities.Find(id);
                db.Cities.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(City item)
        {
            bool sonuc = false;
            try
            {
                City qitem = db.Cities.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public City Get(Guid id)
        {
            return db.Cities.Find(id);
        }

        public IEnumerable<City> GetBy(Func<City, bool> exp)
        {
            return db.Cities.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<City, bool> exp)
        {
            return db.Cities.Any(exp);
        }

        public List<City> GetAll()
        {
            return db.Cities.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<City> GetAllOfItems()
        {
            return db.Cities.ToList();
        }

        public IEnumerable<City> GetPassives()
        {
            return db.Cities.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<City> GetDeleteds()
        {
            return db.Cities.Where(x => x.Status == (int)Status.Deleted).ToList();
        }

        public bool Save()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
