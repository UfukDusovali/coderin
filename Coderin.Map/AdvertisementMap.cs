using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class AdvertisementMap : MapBase<Advertisement>
    {
        public AdvertisementMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name)
                .HasMaxLength(50);

            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(150);

            Property(t => t.Body)
                .IsRequired();
          

            // Table & Column Mappings
            ToTable("Advertisement");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.FotoId).HasColumnName("FotoId");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Body).HasColumnName("Body");
            Property(t => t.Price).HasColumnName("Price");
            Property(t => t.StartDate).HasColumnName("StartDate");
            Property(t => t.EndDate).HasColumnName("EndDate");
            

            // Relationships
            HasRequired(t => t.User)
                .WithMany(t => t.Advertisements)
                .HasForeignKey(d => d.UserId);

        }
    }
}
