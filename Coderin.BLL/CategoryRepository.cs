using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class CategoryRepository : IRepository<Category>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Category item)
        {
            bool sonuc = false;
            try
            {
                db.Categories.Add(item);
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
                Category item = db.Categories.Find(id);
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
                Category item = db.Categories.Find(id);
                db.Categories.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Category item)
        {
            bool sonuc = false;
            try
            {
                Category qitem = db.Categories.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Category Get(Guid id)
        {
            return db.Categories.Find(id);
        }

        public IEnumerable<Category> GetBy(Func<Category, bool> exp)
        {
            return db.Categories.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Category, bool> exp)
        {
            return db.Categories.Any(exp);
        }

        public List<Category> GetAll()
        {
            return db.Categories.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Category> GetAllOfItems()
        {
            return db.Categories.ToList();
        }

        public IEnumerable<Category> GetPassives()
        {
            return db.Categories.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Category> GetDeleteds()
        {
            return db.Categories.Where(x => x.Status == (int)Status.Deleted).ToList();
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
