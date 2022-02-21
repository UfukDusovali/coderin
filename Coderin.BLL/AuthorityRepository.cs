using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class AuthorityRepository : IRepository<Authority>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Authority item)
        {
            bool sonuc = false;
            try
            {
                db.Authorities.Add(item);
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
                Authority item = db.Authorities.Find(id);
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
                Authority item = db.Authorities.Find(id);
                db.Authorities.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Authority item)
        {
            bool sonuc = false;
            try
            {
                Authority qitem = db.Authorities.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Authority Get(Guid id)
        {
            return db.Authorities.Find(id);
        }

        public IEnumerable<Authority> GetBy(Func<Authority, bool> exp)
        {
            return db.Authorities.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Authority, bool> exp)
        {
            return db.Authorities.Any(exp);
        }

        public List<Authority> GetAll()
        {
            return db.Authorities.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Authority> GetAllOfItems()
        {
            return db.Authorities.ToList();
        }

        public IEnumerable<Authority> GetPassives()
        {
            return db.Authorities.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Authority> GetDeleteds()
        {
            return db.Authorities.Where(x => x.Status == (int)Status.Deleted).ToList();
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
