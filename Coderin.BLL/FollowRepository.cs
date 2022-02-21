using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class FollowRepository : IRepository<Follow>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Follow item)
        {
            bool sonuc = false;
            try
            {
                db.Follows.Add(item);
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
                Follow item = db.Follows.Find(id);
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
                Follow item = db.Follows.Find(id);
                db.Follows.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Follow item)
        {
            bool sonuc = false;
            try
            {
                Follow qitem = db.Follows.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Follow Get(Guid id)
        {
            return db.Follows.Find(id);
        }

        public IEnumerable<Follow> GetBy(Func<Follow, bool> exp)
        {
            return db.Follows.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Follow, bool> exp)
        {
            return db.Follows.Any(exp);
        }

        public List<Follow> GetAll()
        {
            return db.Follows.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Follow> GetAllOfItems()
        {
            return db.Follows.ToList();
        }

        public IEnumerable<Follow> GetPassives()
        {
            return db.Follows.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Follow> GetDeleteds()
        {
            return db.Follows.Where(x => x.Status == (int)Status.Deleted).ToList();
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
