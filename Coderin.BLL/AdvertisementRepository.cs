using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class AdvertisementRepository : IRepository<Advertisement>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Advertisement item)
        {
            bool sonuc = false;
            try
            {
                db.Advertisements.Add(item);
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
                Advertisement item = db.Advertisements.Find(id);
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
                Advertisement item = db.Advertisements.Find(id);
                db.Advertisements.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Advertisement item)
        {
            bool sonuc = false;
            try
            {
                Advertisement qitem = db.Advertisements.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Advertisement Get(Guid id)
        {
            return db.Advertisements.Find(id);
        }

        public IEnumerable<Advertisement> GetBy(Func<Advertisement, bool> exp)
        {
            return db.Advertisements.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Advertisement, bool> exp)
        {
            return db.Advertisements.Any(exp);
        }

        public List<Advertisement> GetAll()
        {
            return db.Advertisements.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Advertisement> GetAllOfItems()
        {
            return db.Advertisements.ToList();
        }

        public IEnumerable<Advertisement> GetPassives()
        {
            return db.Advertisements.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Advertisement> GetDeleteds()
        {
            return db.Advertisements.Where(x => x.Status == (int)Status.Deleted).ToList();
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
