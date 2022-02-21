using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class FollowQuestionRepository : IRepository<FollowQuestion>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(FollowQuestion item)
        {
            bool sonuc = false;
            try
            {
                db.FollowQuestions.Add(item);
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
                FollowQuestion item = db.FollowQuestions.Find(id);
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
                FollowQuestion item = db.FollowQuestions.Find(id);
                db.FollowQuestions.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(FollowQuestion item)
        {
            bool sonuc = false;
            try
            {
                FollowQuestion qitem = db.FollowQuestions.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public FollowQuestion Get(Guid id)
        {
            return db.FollowQuestions.Find(id);
        }

        public IEnumerable<FollowQuestion> GetBy(Func<FollowQuestion, bool> exp)
        {
            return db.FollowQuestions.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<FollowQuestion, bool> exp)
        {
            return db.FollowQuestions.Any(exp);
        }

        public List<FollowQuestion> GetAll()
        {
            return db.FollowQuestions.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<FollowQuestion> GetAllOfItems()
        {
            return db.FollowQuestions.ToList();
        }

        public IEnumerable<FollowQuestion> GetPassives()
        {
            return db.FollowQuestions.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<FollowQuestion> GetDeleteds()
        {
            return db.FollowQuestions.Where(x => x.Status == (int)Status.Deleted).ToList();
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
