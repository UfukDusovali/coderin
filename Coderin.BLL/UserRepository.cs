using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class UserRepository : IRepository<User>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(User item)
        {
            bool sonuc = false;
            try
            {
                db.Users.Add(item);
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
                User item = db.Users.Find(id);
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
                User item = db.Users.Find(id);
                db.Users.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(User item)
        {
            bool sonuc = false;
            try
            {
                User uitem = db.Users.Find(item.Id);
                db.Entry(uitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public User Get(Guid id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetBy(Func<User, bool> exp)
        {
            return db.Users.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<User, bool> exp)
        {
            return db.Users.Any(exp);
        }

        public List<User> GetAll()
        {
            return db.Users.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<User> GetAllOfItems()
        {
            return db.Users.ToList();
        }

        public IEnumerable<User> GetPassives()
        {
            return db.Users.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<User> GetDeleteds()
        {
            return db.Users.Where(x => x.Status == (int)Status.Deleted).ToList();
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
