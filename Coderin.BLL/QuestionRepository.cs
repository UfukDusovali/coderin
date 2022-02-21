using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class QuestionRepository : IRepository<Question>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Question item)
        {
            bool sonuc = false;
            try
            {
                db.Questions.Add(item);
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
                Question item = db.Questions.Find(id);
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
                Question item = db.Questions.Find(id);
                db.Questions.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Question item)
        {
            bool sonuc = false;
            try
            {
                Question qitem = db.Questions.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Question Get(Guid id)
        {
            return db.Questions.Find(id);
        }

        public IEnumerable<Question> GetBy(Func<Question, bool> exp)
        {
            return db.Questions.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Question, bool> exp)
        {
            return db.Questions.Any(exp);
        }

        public List<Question> GetAll()
        {
            return db.Questions.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Question> GetAllOfItems()
        {
            return db.Questions.ToList();
        }

        public IEnumerable<Question> GetPassives()
        {
            return db.Questions.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Question> GetDeleteds()
        {
            return db.Questions.Where(x => x.Status == (int)Status.Deleted).ToList();
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
