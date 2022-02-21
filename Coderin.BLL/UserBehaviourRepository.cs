using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class UserBehaviourRepository : IRepository<UserBehaviour>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(UserBehaviour item)
        {
            bool sonuc = false;
            try
            {
                db.UserBehaviours.Add(item);
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
                UserBehaviour item = db.UserBehaviours.Find(id);
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
                UserBehaviour item = db.UserBehaviours.Find(id);
                db.UserBehaviours.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(UserBehaviour item)
        {
            bool sonuc = false;
            try
            {
                UserBehaviour qitem = db.UserBehaviours.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public UserBehaviour Get(Guid id)
        {
            return db.UserBehaviours.Find(id);
        }

        public IEnumerable<UserBehaviour> GetBy(Func<UserBehaviour, bool> exp)
        {
            return db.UserBehaviours.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<UserBehaviour, bool> exp)
        {
            return db.UserBehaviours.Any(exp);
        }

        public List<UserBehaviour> GetAll()
        {
            return db.UserBehaviours.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<UserBehaviour> GetAllOfItems()
        {
            return db.UserBehaviours.ToList();
        }

        public IEnumerable<UserBehaviour> GetPassives()
        {
            return db.UserBehaviours.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<UserBehaviour> GetDeleteds()
        {
            return db.UserBehaviours.Where(x => x.Status == (int)Status.Deleted).ToList();
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
