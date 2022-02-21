using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class CommentMap : MapBase<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CommentBody)
                .IsRequired();

            this.Property(t => t.Name)
                .HasMaxLength(50);

           

            // Table & Column Mappings
            this.ToTable("Comments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.AnswerId).HasColumnName("AnswerId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CommentBody).HasColumnName("CommentBody");
            this.Property(t => t.Name).HasColumnName("Name");
           

            // Relationships
            this.HasRequired(t => t.Answer)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.AnswerId);
            this.HasOptional(t => t.Comment1)
                .WithMany(t => t.Comments1)
                .HasForeignKey(d => d.ParentId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.UserId);

        }
    }
}
