using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class MessageRepository : IRepository<Message>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Message item)
        {
            bool sonuc = false;
            try
            {
                db.Messages.Add(item);
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
                Message item = db.Messages.Find(id);
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
                Message item = db.Messages.Find(id);
                db.Messages.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Message item)
        {
            bool sonuc = false;
            try
            {
                Message qitem = db.Messages.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Message Get(Guid id)
        {
            return db.Messages.Find(id);
        }

        public IEnumerable<Message> GetBy(Func<Message, bool> exp)
        {
            return db.Messages.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Message, bool> exp)
        {
            return db.Messages.Any(exp);
        }

        public List<Message> GetAll()
        {
            return db.Messages.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Message> GetAllOfItems()
        {
            return db.Messages.ToList();
        }

        public IEnumerable<Message> GetPassives()
        {
            return db.Messages.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Message> GetDeleteds()
        {
            return db.Messages.Where(x => x.Status == (int)Status.Deleted).ToList();
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
