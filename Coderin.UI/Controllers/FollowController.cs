using Coderin.Base.Enum;
using Coderin.BLL;
using Coderin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coderin.UI.Controllers
{
    public class FollowController : BaseController
    {
        UserRepository userRepository = new UserRepository();
        FollowRepository followRepository = new FollowRepository();
        UserBehaviourRepository userBehaviourRepository = new UserBehaviourRepository();

        // GET: Follow
        [HttpPost]
        public ActionResult Add(Guid id)
        {
            Follow item = new Follow();
            item.FollowerId = Guid.Parse(Session["UserId"].ToString());
            item.FollowingId = id;
            followRepository.Add(item);
            bool sonuc = followRepository.Save();
            if (sonuc)
            {
                UserBehaviour item2 = new UserBehaviour();
                item2.FollowedId = id;
                item2.UserId = (Guid)Session["UserId"];
                item2.BehaviourStatus = (int)BehaviourStatus.TakipEtti;
                item2.Name = "Takip Etti";
                userBehaviourRepository.Add(item2);
                userBehaviourRepository.Save();
            }
            return Redirect(TempData["URLim"].ToString());
        }

        [HttpPost]
        public ActionResult Remove(Guid id)
        {
            foreach (Follow item in followRepository.GetBy(x => x.FollowerId == (Guid)Session["UserId"] && x.FollowingId == id))
            {
                item.Status = 1;
                followRepository.Update(item);
                bool sonuc = followRepository.Save();

                if (sonuc)
                {
                    UserBehaviour item2 = new UserBehaviour();
                    item2.FollowedId = id;
                    item2.UserId = (Guid)Session["UserId"];
                    item2.BehaviourStatus = (int)BehaviourStatus.TakibiKaldirdi;
                    item2.Name = "Takipi Kaldırdı";
                    userBehaviourRepository.Add(item2);
                    userBehaviourRepository.Save();
                }
            }  
            return Redirect(TempData["URLim"].ToString());
        }

        public ActionResult Following(Guid id)
        {

            return View(followRepository.GetBy(x => x.FollowerId == id));
        }

        public ActionResult Follower(Guid id)
        {

            return View(followRepository.GetBy(x => x.FollowingId == id));
        }
    }
}