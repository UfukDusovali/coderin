using Coderin.Base.Enum;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.BLL
{
    public class ChatRepository : IRepository<Chat>
    {
        CoderinDBContext db = new CoderinDBContext();
        public bool Add(Chat item)
        {
            bool sonuc = false;
            try
            {
                db.Chats.Add(item);
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
                Chat item = db.Chats.Find(id);
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
                Chat item = db.Chats.Find(id);
                db.Chats.Remove(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Update(Chat item)
        {
            bool sonuc = false;
            try
            {
                Chat qitem = db.Chats.Find(item.Id);
                db.Entry(qitem).CurrentValues.SetValues(item);
                return sonuc = true;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public Chat Get(Guid id)
        {
            return db.Chats.Find(id);
        }

        public IEnumerable<Chat> GetBy(Func<Chat, bool> exp)
        {
            return db.Chats.Where(x => x.Status == (int)Status.Active).Where(exp).ToList();
        }

        public bool Any(Func<Chat, bool> exp)
        {
            return db.Chats.Any(exp);
        }

        public List<Chat> GetAll()
        {
            return db.Chats.Where(x => x.Status == (int)Status.Active).ToList();
        }

        public IEnumerable<Chat> GetAllOfItems()
        {
            return db.Chats.ToList();
        }

        public IEnumerable<Chat> GetPassives()
        {
            return db.Chats.Where(x => x.Status == (int)Status.Passive).ToList();
        }

        public IEnumerable<Chat> GetDeleteds()
        {
            return db.Chats.Where(x => x.Status == (int)Status.Deleted).ToList();
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
