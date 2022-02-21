using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class AnswerMap : MapBase<Answer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.NameUrl)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.AnswerBody)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Answers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NameUrl).HasColumnName("NameUrl");
            this.Property(t => t.Vote).HasColumnName("Vote");
            this.Property(t => t.IsCheck).HasColumnName("IsCheck");
            this.Property(t => t.AnswerBody).HasColumnName("AnswerBody");
           

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.Answers)
                .HasForeignKey(d => d.QuestionId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Answers)
                .HasForeignKey(d => d.UserId);

        }
    }
}
