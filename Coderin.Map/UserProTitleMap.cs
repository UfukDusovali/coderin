using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class UserProTitleMap : MapBase<UserProTitle>
    {
        public UserProTitleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);
            

            // Table & Column Mappings
            this.ToTable("UserProTitles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ProTitleId).HasColumnName("ProTitleId");
           

            // Relationships
            this.HasRequired(t => t.ProTitle)
                .WithMany(t => t.UserProTitles)
                .HasForeignKey(d => d.ProTitleId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserProTitles)
                .HasForeignKey(d => d.UserId);

        }
    }
}
