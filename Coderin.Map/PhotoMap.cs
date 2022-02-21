using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class PhotoMap : MapBase<Photo>
    {
        public PhotoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PhotoPath)
                .IsRequired()
                .HasMaxLength(200);

            

            // Table & Column Mappings
            this.ToTable("Photos");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PhotoPath).HasColumnName("PhotoPath");
           

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Photos)
                .HasForeignKey(d => d.UserId);

        }
    }
}
