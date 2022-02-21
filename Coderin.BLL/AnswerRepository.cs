using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class AnswerRepository : IRepository<Answer>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Answer item)
        {
            bool sonuc = false;
            try
            {
                db.Answers.Add(item);
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
                Answer item = db.Answers.Find(id);
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
                Answer item = db.Answers.Find(id);
                db.Answers.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Answer item)
        {
            bool sonuc = false;
            try
            {
                Answer qitem = db.Answers.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Answer Get(Guid id)
        {
            return db.Answers.Find(id);
        }

        public IEnumerable<Answer> GetBy(Func<Answer, bool> exp)
        {
            return db.Answers.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Answer, bool> exp)
        {
            return db.Answers.Any(exp);
        }

        public List<Answer> GetAll()
        {
            return db.Answers.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Answer> GetAllOfItems()
        {
            return db.Answers.ToList();
        }

        public IEnumerable<Answer> GetPassives()
        {
            return db.Answers.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Answer> GetDeleteds()
        {
            return db.Answers.Where(x => x.Status == (int)Status.Deleted).ToList();
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
