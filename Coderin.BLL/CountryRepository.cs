using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class CountryRepository : IRepository<Country>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Country item)
        {
            bool sonuc = false;
            try
            {
                db.Countries.Add(item);
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
                Country item = db.Countries.Find(id);
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
                Country item = db.Countries.Find(id);
                db.Countries.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Country item)
        {
            bool sonuc = false;
            try
            {
                Country qitem = db.Countries.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Country Get(Guid id)
        {
            return db.Countries.Find(id);
        }

        public IEnumerable<Country> GetBy(Func<Country, bool> exp)
        {
            return db.Countries.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Country, bool> exp)
        {
            return db.Countries.Any(exp);
        }

        public List<Country> GetAll()
        {
            return db.Countries.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Country> GetAllOfItems()
        {
            return db.Countries.ToList();
        }

        public IEnumerable<Country> GetPassives()
        {
            return db.Countries.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Country> GetDeleteds()
        {
            return db.Countries.Where(x => x.Status == (int)Status.Deleted).ToList();
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
