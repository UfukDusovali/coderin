using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;


namespace Coderin.Map
{
    public class FollowQuestionMap : MapBase<FollowQuestion>
    {
        public FollowQuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);


            // Table & Column Mappings
            this.ToTable("FollowQuestions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FQuestionId).HasColumnName("FQuestionId");
            this.Property(t => t.FFollowerId).HasColumnName("FFollowerId");
           

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.FollowQuestions)
                .HasForeignKey(d => d.FFollowerId);

            this.HasRequired(t => t.Question)
                .WithMany(t => t.FollowQuestions)
                .HasForeignKey(d => d.FQuestionId);

        }
    }
}
