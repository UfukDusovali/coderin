using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class UserBehaviourMap : MapBase<UserBehaviour>
    {
        public UserBehaviourMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(500);

           

            // Table & Column Mappings
            this.ToTable("UserBehaviours");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FollowedId).HasColumnName("FollowedId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CommentId).HasColumnName("CommentId");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.AnswerId).HasColumnName("AnswerId");
            this.Property(t => t.TagId).HasColumnName("TagId");
            this.Property(t => t.Saw).HasColumnName("Saw");
            this.Property(t => t.BehaviourStatus).HasColumnName("BehaviourStatus");
            

             //Relationships
            this.HasOptional(t => t.Comment)
                .WithMany(t => t.UserBehaviours)
                .HasForeignKey(d => d.CommentId);

            this.HasOptional(t => t.Question)
                .WithMany(t => t.UserBehaviours)
                .HasForeignKey(d => d.QuestionId);

            this.HasOptional(t => t.User)
                .WithMany(t => t.UserBehaviours)
                .HasForeignKey(t => t.UserId);

            this.HasOptional(t => t.User1)
              .WithMany(t => t.UserBehaviours1)
              .HasForeignKey(t => t.FollowedId);

            this.HasOptional(t => t.Answer)
               .WithMany(t => t.UserBehaviours)
               .HasForeignKey(t => t.AnswerId);
           

        }
    }
}
