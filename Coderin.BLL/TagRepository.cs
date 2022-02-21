using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class TagRepository : IRepository<Tag>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Tag item)
        {
            bool sonuc = false;
            try
            {
                db.Tags.Add(item);
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
                Tag item = db.Tags.Find(id);
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
                Tag item = db.Tags.Find(id);
                db.Tags.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Tag item)
        {
            bool sonuc = false;
            try
            {
                Tag qitem = db.Tags.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Tag Get(Guid id)
        {
            return db.Tags.Find(id);
        }

        public IEnumerable<Tag> GetBy(Func<Tag, bool> exp)
        {
            return db.Tags.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Tag, bool> exp)
        {
            return db.Tags.Any(exp);
        }

        public List<Tag> GetAll()
        {
            return db.Tags.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Tag> GetAllOfItems()
        {
            return db.Tags.ToList();
        }

        public IEnumerable<Tag> GetPassives()
        {
            return db.Tags.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Tag> GetDeleteds()
        {
            return db.Tags.Where(x => x.Status == (int)Status.Deleted).ToList();
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

        public Tag Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
