using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class UserDetailRepository : IRepository<UserDetail>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(UserDetail item)
        {
            bool sonuc = false;
            try
            {
                db.UserDetails.Add(item);
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
                UserDetail item = db.UserDetails.Find(id);
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
                UserDetail item = db.UserDetails.Find(id);
                db.UserDetails.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(UserDetail item)
        {
            bool sonuc = false;
            try
            {
                UserDetail qitem = db.UserDetails.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public UserDetail Get(Guid id)
        {
            return db.UserDetails.Find(id);
        }

        public IEnumerable<UserDetail> GetBy(Func<UserDetail, bool> exp)
        {
            return db.UserDetails.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<UserDetail, bool> exp)
        {
            return db.UserDetails.Any(exp);
        }

        public List<UserDetail> GetAll()
        {
            return db.UserDetails.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<UserDetail> GetAllOfItems()
        {
            return db.UserDetails.ToList();
        }

        public IEnumerable<UserDetail> GetPassives()
        {
            return db.UserDetails.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<UserDetail> GetDeleteds()
        {
            return db.UserDetails.Where(x => x.Status == (int)Status.Deleted).ToList();
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
