using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class UserProTitleRepository : IRepository<UserProTitle>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(UserProTitle item)
        {
            bool sonuc = false;
            try
            {
                db.UserProTitles.Add(item);
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
                UserProTitle item = db.UserProTitles.Find(id);
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
                UserProTitle item = db.UserProTitles.Find(id);
                db.UserProTitles.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(UserProTitle item)
        {
            bool sonuc = false;
            try
            {
                UserProTitle qitem = db.UserProTitles.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public UserProTitle Get(Guid id)
        {
            return db.UserProTitles.Find(id);
        }

        public IEnumerable<UserProTitle> GetBy(Func<UserProTitle, bool> exp)
        {
            return db.UserProTitles.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<UserProTitle, bool> exp)
        {
            return db.UserProTitles.Any(exp);
        }

        public List<UserProTitle> GetAll()
        {
            return db.UserProTitles.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<UserProTitle> GetAllOfItems()
        {
            return db.UserProTitles.ToList();
        }

        public IEnumerable<UserProTitle> GetPassives()
        {
            return db.UserProTitles.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<UserProTitle> GetDeleteds()
        {
            return db.UserProTitles.Where(x => x.Status == (int)Status.Deleted).ToList();
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
