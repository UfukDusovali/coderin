using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class CityMap : MapBase<City>
    {
        public CityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

           

            // Table & Column Mappings
            this.ToTable("Cities");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.Name).HasColumnName("Name");
            

            // Relationships
            this.HasRequired(t => t.Country)
                .WithMany(t => t.Cities)
                .HasForeignKey(d => d.CountryId);

        }
    }
}
