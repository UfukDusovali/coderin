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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["kullaniciListesi"] = "";
            return View();
        }

        UserRepository userRepository = new UserRepository();
        QuestionRepository questionRepository = new QuestionRepository();
        UserBehaviourRepository userBehaviourRepository = new UserBehaviourRepository();
        TagQuestionRepository tagQuestionRepository = new TagQuestionRepository();
        TagRepository tagRepository = new TagRepository();
        AnswerRepository answerRepository = new AnswerRepository();
         public ActionResult UserList()
        {
            return View(userRepository.GetAll());
        }

        [HttpPost]
        [ValidateInput(false)]
         public ActionResult AskQuestion(FormCollection collection)
        {
            bool sonuc = false;
            try
            {
                if (Session["UserId"] != null)
                {
                    Question item = new Question();
                    item.UserId = Guid.Parse(Session["UserId"].ToString()); //Guid.Parse("3649c6ba-e679-4653-84a5-07cf732cdc7e");
                        item.Name = collection["question_title"].ToString().Trim();
                        item.NameUrl = Functions.UrlDuzenle(collection["question_title"].ToString().Trim());
                        item.QuestionBody = collection["editor1"].ToString().Trim();
                    item.Vote = 0;
                    item.Views = 0;
                    questionRepository.Add(item);
                    sonuc = questionRepository.Save();

                    if (sonuc)
                    {
                        if (collection["TagID"] != null)
                        {
                            if (collection["TagID"].ToString().Contains(","))
                            {
                                string[] extraTagParcala = collection["TagID"].ToString().Split(',');
                                for (int i = 0; i < extraTagParcala.Count(); i++)
                                {
                                    TagQuestion item_1 = new TagQuestion();
                                    item_1.TagId = Guid.Parse(extraTagParcala[i]);
                                    item_1.QuestionId = item.Id;
                                    item_1.Name = "";
                                    tagQuestionRepository.Add(item_1);
                                    tagQuestionRepository.Save();
                                }
                                }
                                else
                                {
                                    TagQuestion item_1 = new TagQuestion();
                                    item_1.TagId = Guid.Parse(collection["TagID"].ToString());
                                    item_1.QuestionId = item.Id;
                                    item_1.Name = "";
                                    tagQuestionRepository.Add(item_1);
                                    tagQuestionRepository.Save();
                                }
                            }

                            if (collection["question_tags"].ToString().Trim() != "")
                            {
                                if (collection["question_tags"].ToString().Contains(","))
                                {
                                    string[] tagParcala = collection["question_tags"].ToString().Split(',');
                                    for (int j = 0; j < tagParcala.Count(); j++)
                                    {
                                        if (tagRepository.GetBy(x => x.Name.ToLower() == tagParcala[j].ToLower().Trim()).Count() > 0)
                                        {
                                            foreach (Tag item_5 in tagRepository.GetBy(x => x.Name.ToLower() == tagParcala[j].ToLower()))
                                            {
                                                TagQuestion item_3 = new TagQuestion();
                                                item_3.TagId = item_5.Id;
                                                item_3.QuestionId = item.Id;
                                                item_3.Name = "";
                                                tagQuestionRepository.Add(item_3);
                                                sonuc = tagQuestionRepository.Save();
                                            }
                                        }
                                        else
                                        {
                                            Tag item_2 = new Tag();
                                            item_2.Name = tagParcala[j];
                                            item_2.UserId = Guid.Parse(Session["UserId"].ToString()); //Guid.Parse("3649c6ba-e679-4653-84a5-07cf732cdc7e");
                                            item_2.IsProTag = false;
                                            tagRepository.Add(item_2);
                                            tagRepository.Save();

                                            TagQuestion item_3 = new TagQuestion();
                                            item_3.TagId = item_2.Id;
                                            item_3.QuestionId = item.Id;
                                            item_3.Name = "";
                                            tagQuestionRepository.Add(item_3);
                                            sonuc = tagQuestionRepository.Save();
                                        }
                                    }
                                }
                                else
                                {
                                    if (tagRepository.GetBy(x => x.Name.ToLower() == collection["question_tags"].ToLower().Trim()).Count() > 0)
                                    {
                                        foreach (Tag item_5 in tagRepository.GetBy(x => x.Name.ToLower() == collection["question_tags"].ToLower()))
                                        {
                                            TagQuestion item_3 = new TagQuestion();
                                            item_3.TagId = item_5.Id;
                                            item_3.QuestionId = item.Id;
                                            item_3.Name = "";
                                            tagQuestionRepository.Add(item_3);
                                            sonuc = tagQuestionRepository.Save();
                                        }
                                    }
                                    else
                                    {
                                        Tag item_2 = new Tag();
                                        item_2.Name = collection["question_tags"];
                                        item_2.UserId = Guid.Parse(Session["UserId"].ToString()); //Guid.Parse("3649c6ba-e679-4653-84a5-07cf732cdc7e");
                                        item_2.IsProTag = false;
                                        tagRepository.Add(item_2);
                                        tagRepository.Save();

                                        TagQuestion item_3 = new TagQuestion();
                                        item_3.TagId = item_2.Id;
                                        item_3.QuestionId = item.Id;
                                        item_3.Name = "";
                                        tagQuestionRepository.Add(item_3);
                                        sonuc = tagQuestionRepository.Save();
                                    }
                                }


                            if (sonuc)
                            {
                                UserBehaviour item_4 = new UserBehaviour();
                                item_4.Name = "Soru Sordu.";
                                item_4.UserId = Guid.Parse(Session["UserId"].ToString()); //Guid.Parse("3649c6ba-e679-4653-84a5-07cf732cdc7e");
                                item_4.QuestionId = item.Id;
                                item_4.BehaviourStatus = (int)BehaviourStatus.SoruSordu;
                                userBehaviourRepository.Add(item_4);
                                sonuc = userBehaviourRepository.Save();
                                if (sonuc)
                                {
                                    Session["QTitle"] = null;
                                    Session["QBody"] = null;
                                    Session["QTags"] = null;
                                    Session["QExtraTags"] = null;
                                }
                            }
                        }
}
                    return Redirect("~/Question/Index/" + item.NameUrl + "-" + item.Id);

                }
                else
                {
                    TempData["Error"] = "<script>alert('Soru Sormak İçin Kullanıcı Girişi Yapmalısınız!');</script>";
                    return Redirect("~/User/Login");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "<script>alert('Hata Oluştu');</script>";
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
            
        public ActionResult AnswerTheQuestion(FormCollection collection)
        {
            bool sonuc = false;
            try
            {
                Answer item = new Answer();
                item.QuestionId = Guid.Parse(collection["hiddenId"]);
                item.UserId = Guid.Parse(Session["UserId"].ToString());//Guid.Parse("3649c6ba-e679-4653-84a5-07cf732cdc7e");
                item.Name = "";
                item.NameUrl = "";
                item.Vote = 0;
                item.IsCheck = false;
                item.AnswerBody = collection["editor2"];
                answerRepository.Add(item);
                sonuc = answerRepository.Save();

                if (sonuc)
                {
                    UserBehaviour item_1 = new UserBehaviour();
                    item_1.Name = "Soru Cevapladı.";
                    item_1.UserId = Guid.Parse(Session["UserId"].ToString()); //Guid.Parse("3649c6ba-e679-4653-84a5-07cf732cdc7e");
                    item_1.QuestionId = item.QuestionId;
                    item_1.AnswerId = item.Id;
                    item_1.BehaviourStatus = (short)BehaviourStatus.SoruCevapladi;
                    userBehaviourRepository.Add(item_1);
                    sonuc = userBehaviourRepository.Save();

                    TempData["Error"] = "<script>alert('Cevap Gönderildi.');</script>";
                    return Redirect(TempData["URLim"].ToString());
                }
                else
                {
                    TempData["Error"] = "<script>alert('Cevap Gönderilemedi.');</script>";
                    return Redirect(TempData["URLim"].ToString());
                }

            }
            catch (Exception)
            {
                TempData["Error"] = "<script>alert('Hata Oluştu');</script>";
                return Redirect(TempData["URLim"].ToString());
            }
        }
    }
}