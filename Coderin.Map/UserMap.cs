using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class UserMap : MapBase<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Mail)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AuthorityId).HasColumnName("AuthorityId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Password).HasColumnName("Password");
            

            // Relationships
            this.HasRequired(t => t.Authority)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.AuthorityId);
    

        }
    }
}
