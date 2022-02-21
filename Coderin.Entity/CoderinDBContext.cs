using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Coderin.Base;
using Coderin.Base.Enum;
using System;
using System.Web;
using Coderin.Map;
using System.Management;

namespace Coderin.Entity
{
    public partial class CoderinDBContext : DbContext
    {
        static CoderinDBContext()
        {
            Database.SetInitializer<CoderinDBContext>(null);
        }

        public CoderinDBContext()
            : base("Name=CoderinDBContext")
        {
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ProTitle> ProTitles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TagQuestion> TagQuestions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserBehaviour> UserBehaviours { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserProTitle> UserProTitles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FollowQuestion> FollowQuestions { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdvertisementMap());
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new AuthorityMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ChatMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new ErrorLogMap());
            modelBuilder.Configurations.Add(new FollowMap());
            modelBuilder.Configurations.Add(new LogMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new ProTitleMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TagQuestionMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new UserBehaviourMap());
            modelBuilder.Configurations.Add(new UserDetailMap());
            modelBuilder.Configurations.Add(new UserProTitleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new FollowQuestionMap());
        
         
        }
        private string MAC()
        {
            ManagementClass manager = new ManagementClass("Win32_NetworkAdapterConfiguration");
            foreach (ManagementObject obj in manager.GetInstances())
            {
                if ((bool)obj["IPEnabled"])
                {
                    return obj["MacAddress"].ToString();
                }
            }
            return String.Empty;
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                EntityBase entity = item.Cast<EntityBase>().Entity;
                entity.Id = entity.Id != Guid.Parse("00000000-0000-0000-0000-000000000000") ? entity.Id : Guid.NewGuid();
                entity.CreateDate = entity.CreateDate == new DateTime() ? DateTime.Now : entity.CreateDate;
                entity.ModifiedDate = DateTime.Now;
                entity.Status = entity.Status != (int)Status.Active ? entity.Status : (int)Status.Active;
                var n = HttpContext.Current.Session["UserId"];

                entity.CreatedBy = entity.CreatedBy == Guid.Parse("00000000-0000-0000-0000-000000000000") ? HttpContext.Current.Session["UserId"] != null ? Guid.Parse(HttpContext.Current.Session["UserId"].ToString()) : Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff") : entity.CreatedBy;

                entity.CreatedMAC = entity.CreatedMAC != null ? entity.CreatedMAC : MAC();
                entity.ModifiedADUsername = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                entity.ModifiedBy = HttpContext.Current.Session["UserId"] != null ? Guid.Parse(HttpContext.Current.Session["UserId"].ToString()) : Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

                entity.ModifiedComputerName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedMAC = MAC();
                if (entity.CreatedIP == null)
                {
                    if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                    {
                        entity.CreatedIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                        entity.ModifiedIP = entity.CreatedIP;
                    }
                    else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
                    {
                        entity.CreatedIP = HttpContext.Current.Request.UserHostAddress;
                        entity.ModifiedIP = entity.CreatedIP;
                    }
                }
                else
                {
                    if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                    {
                        entity.ModifiedIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();

                    }
                    else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
                    {
                        entity.ModifiedIP = HttpContext.Current.Request.UserHostAddress;
                    }
                }
            }   
            return base.SaveChanges();
        }
    }
}
