using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class CommentRepository : IRepository<Comment>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Comment item)
        {
            bool sonuc = false;
            try
            {
                db.Comments.Add(item);
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
                Comment item = db.Comments.Find(id);
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
                Comment item = db.Comments.Find(id);
                db.Comments.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Comment item)
        {
            bool sonuc = false;
            try
            {
                Comment qitem = db.Comments.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Comment Get(Guid id)
        {
            return db.Comments.Find(id);
        }

        public IEnumerable<Comment> GetBy(Func<Comment, bool> exp)
        {
            return db.Comments.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Comment, bool> exp)
        {
            return db.Comments.Any(exp);
        }

        public List<Comment> GetAll()
        {
            return db.Comments.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Comment> GetAllOfItems()
        {
            return db.Comments.ToList();
        }

        public IEnumerable<Comment> GetPassives()
        {
            return db.Comments.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Comment> GetDeleteds()
        {
            return db.Comments.Where(x => x.Status == (int)Status.Deleted).ToList();
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
