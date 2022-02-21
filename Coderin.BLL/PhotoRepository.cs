using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class PhotoRepository : IRepository<Photo>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Photo item)
        {
            bool sonuc = false;
            try
            {
                db.Photos.Add(item);
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
                Photo item = db.Photos.Find(id);
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
                Photo item = db.Photos.Find(id);
                db.Photos.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Photo item)
        {
            bool sonuc = false;
            try
            {
                Photo qitem = db.Photos.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Photo Get(Guid id)
        {
            return db.Photos.Find(id);
        }

        public IEnumerable<Photo> GetBy(Func<Photo, bool> exp)
        {
            return db.Photos.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Photo, bool> exp)
        {
            return db.Photos.Any(exp);
        }

        public List<Photo> GetAll()
        {
            return db.Photos.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Photo> GetAllOfItems()
        {
            return db.Photos.ToList();
        }

        public IEnumerable<Photo> GetPassives()
        {
            return db.Photos.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Photo> GetDeleteds()
        {
            return db.Photos.Where(x => x.Status == (int)Status.Deleted).ToList();
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
