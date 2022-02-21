using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class UserDetailMap : MapBase<UserDetail>
    {
        public UserDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.CompanyName)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(11);

            

            // Table & Column Mappings
            this.ToTable("UserDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Avatar).HasColumnName("Avatar");
            this.Property(t => t.Working).HasColumnName("Working");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.CityId).HasColumnName("CityId");
            this.Property(t => t.TownId).HasColumnName("TownId");
           

            // Relationships
            this.HasRequired(t => t.City)
                .WithMany(t => t.UserDetails)
                .HasForeignKey(d => d.CityId);
            this.HasRequired(t => t.Country)
                .WithMany(t => t.UserDetails)
                .HasForeignKey(d => d.CountryId);
            this.HasRequired(t => t.Town)
                .WithMany(t => t.UserDetails)
                .HasForeignKey(d => d.TownId);
            this.HasRequired(t => t.User)
                .WithOptional(t => t.UserDetail);

        }
    }
}
