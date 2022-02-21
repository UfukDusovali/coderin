using Coderin.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Coderin.Entity
{
    public partial class User : EntityBase
    {
        public User()
        {
            this.Advertisements = new List<Advertisement>();
            this.Answers = new List<Answer>();
            this.Chats = new List<Chat>();
            this.Comments = new List<Comment>();
            this.Follows = new List<Follow>();
            this.Follows1 = new List<Follow>();
            this.FollowQuestions = new List<FollowQuestion>();
            this.Logs = new List<Log>();
            this.Messages = new List<Message>();
            this.Messages1 = new List<Message>();
            this.Photos = new List<Photo>();
            this.Questions = new List<Question>();
            this.UserBehaviours = new List<UserBehaviour>();
            this.UserProTitles = new List<UserProTitle>();
            this.UserBehaviours1 = new List<UserBehaviour>();
        }

        public System.Guid AuthorityId { get; set; }


        [Required(ErrorMessage = "boþ geçilemez")]
        [Range(3, 15, ErrorMessage = "Þifreniz 3 ile 20 karakter olmalý")]
        [Display(Name = "Ad")]
        public string Name { get; set; }


        [Required(ErrorMessage = "boþ geçilemez")]
        [Range(3, 15, ErrorMessage = "Þifreniz 3 ile 20 karakter olmalý")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "boþ geçilemez")]
        [DataType(DataType.EmailAddress)]
        [Remote("IsMail", "User", ErrorMessage = "Mail adresi sistemde kayýtlý")]
        [Display(Name = "E-Mail")]
        //[RegularExpression("^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Must be a valid email")]
        public string Mail { get; set; }




        [Required(ErrorMessage = "boþ geçilemez")]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "Þifreniz 6 ile 15 karakter olmalý", MinimumLength = 6)]
        [RegularExpression("[a-zA-Z0-9]$", ErrorMessage = "Geçerli bir þifre girin")]
        [Display(Name = "Þifre")]
        public string Password { get; set; }


        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Authority Authority { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Follow> Follows { get; set; }
        public virtual ICollection<Follow> Follows1 { get; set; }
        public virtual ICollection<FollowQuestion> FollowQuestions { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Message> Messages1 { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<UserBehaviour> UserBehaviours { get; set; }
        public virtual ICollection<UserBehaviour> UserBehaviours1 { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public virtual ICollection<UserProTitle> UserProTitles { get; set; }
        
    }
}
