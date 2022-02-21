using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class ProTitleRepository : IRepository<ProTitle>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(ProTitle item)
        {
            bool sonuc = false;
            try
            {
                db.ProTitles.Add(item);
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
                ProTitle item = db.ProTitles.Find(id);
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
                ProTitle item = db.ProTitles.Find(id);
                db.ProTitles.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(ProTitle item)
        {
            bool sonuc = false;
            try
            {
                ProTitle qitem = db.ProTitles.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public ProTitle Get(Guid id)
        {
            return db.ProTitles.Find(id);
        }

        public IEnumerable<ProTitle> GetBy(Func<ProTitle, bool> exp)
        {
            return db.ProTitles.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<ProTitle, bool> exp)
        {
            return db.ProTitles.Any(exp);
        }

        public List<ProTitle> GetAll()
        {
            return db.ProTitles.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<ProTitle> GetAllOfItems()
        {
            return db.ProTitles.ToList();
        }

        public IEnumerable<ProTitle> GetPassives()
        {
            return db.ProTitles.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<ProTitle> GetDeleteds()
        {
            return db.ProTitles.Where(x => x.Status == (int)Status.Deleted).ToList();
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
