using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class QuestionMap : MapBase<Question>
    {
        public QuestionMap()
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

            this.Property(t => t.QuestionBody)
                .IsRequired();

            

            // Table & Column Mappings
            this.ToTable("Questions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NameUrl).HasColumnName("NameUrl");
            this.Property(t => t.QuestionBody).HasColumnName("QuestionBody");
            this.Property(t => t.Vote).HasColumnName("Vote");
            this.Property(t => t.Views).HasColumnName("Views");
            

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.UserId);

        }
    }
}
