using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class TagQuestionMap : MapBase<TagQuestion>
    {
        public TagQuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            

            // Table & Column Mappings
            this.ToTable("TagQuestions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TagId).HasColumnName("TagId");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.Name).HasColumnName("Name");
           

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.TagQuestions)
                .HasForeignKey(d => d.QuestionId);
            this.HasRequired(t => t.Tag)
                .WithMany(t => t.TagQuestions)
                .HasForeignKey(d => d.TagId);

        }
    }
}
