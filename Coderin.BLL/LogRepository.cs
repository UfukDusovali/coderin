using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class LogRepository : IRepository<Log>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Log item)
        {
            bool sonuc = false;
            try
            {
                db.Logs.Add(item);
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
                Log item = db.Logs.Find(id);
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
                Log item = db.Logs.Find(id);
                db.Logs.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Log item)
        {
            bool sonuc = false;
            try
            {
                Log qitem = db.Logs.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Log Get(Guid id)
        {
            return db.Logs.Find(id);
        }

        public IEnumerable<Log> GetBy(Func<Log, bool> exp)
        {
            return db.Logs.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Log, bool> exp)
        {
            return db.Logs.Any(exp);
        }

        public List<Log> GetAll()
        {
            return db.Logs.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Log> GetAllOfItems()
        {
            return db.Logs.ToList();
        }

        public IEnumerable<Log> GetPassives()
        {
            return db.Logs.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Log> GetDeleteds()
        {
            return db.Logs.Where(x => x.Status == (int)Status.Deleted).ToList();
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
