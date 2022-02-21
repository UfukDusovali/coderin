using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class ErrorLogRepository : IRepository<ErrorLog>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(ErrorLog item)
        {
            bool sonuc = false;
            try
            {
                db.ErrorLogs.Add(item);
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
                ErrorLog item = db.ErrorLogs.Find(id);
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
                ErrorLog item = db.ErrorLogs.Find(id);
                db.ErrorLogs.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(ErrorLog item)
        {
            bool sonuc = false;
            try
            {
                ErrorLog qitem = db.ErrorLogs.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public ErrorLog Get(Guid id)
        {
            return db.ErrorLogs.Find(id);
        }

        public IEnumerable<ErrorLog> GetBy(Func<ErrorLog, bool> exp)
        {
            return db.ErrorLogs.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<ErrorLog, bool> exp)
        {
            return db.ErrorLogs.Any(exp);
        }

        public List<ErrorLog> GetAll()
        {
            return db.ErrorLogs.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<ErrorLog> GetAllOfItems()
        {
            return db.ErrorLogs.ToList();
        }

        public IEnumerable<ErrorLog> GetPassives()
        {
            return db.ErrorLogs.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<ErrorLog> GetDeleteds()
        {
            return db.ErrorLogs.Where(x => x.Status == (int)Status.Deleted).ToList();
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
