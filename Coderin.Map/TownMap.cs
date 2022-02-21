using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class TownMap : MapBase<Town>
    {
        public TownMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            

            // Table & Column Mappings
            this.ToTable("Towns");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.CityId).HasColumnName("CityId");
            this.Property(t => t.Name).HasColumnName("Name");
           

            // Relationships
            this.HasRequired(t => t.City)
                .WithMany(t => t.Towns)
                .HasForeignKey(d => d.CityId);

        }
    }
}
