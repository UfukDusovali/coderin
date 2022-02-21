using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class TagQuestionRepository : IRepository<TagQuestion>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(TagQuestion item)
        {
            bool sonuc = false;
            try
            {
                db.TagQuestions.Add(item);
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
                TagQuestion item = db.TagQuestions.Find(id);
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
                TagQuestion item = db.TagQuestions.Find(id);
                db.TagQuestions.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(TagQuestion item)
        {
            bool sonuc = false;
            try
            {
                TagQuestion qitem = db.TagQuestions.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public TagQuestion Get(Guid id)
        {
            return db.TagQuestions.Find(id);
        }

        public IEnumerable<TagQuestion> GetBy(Func<TagQuestion, bool> exp)
        {
            return db.TagQuestions.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<TagQuestion, bool> exp)
        {
            return db.TagQuestions.Any(exp);
        }

        public List<TagQuestion> GetAll()
        {
            return db.TagQuestions.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<TagQuestion> GetAllOfItems()
        {
            return db.TagQuestions.ToList();
        }

        public IEnumerable<TagQuestion> GetPassives()
        {
            return db.TagQuestions.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<TagQuestion> GetDeleteds()
        {
            return db.TagQuestions.Where(x => x.Status == (int)Status.Deleted).ToList();
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
