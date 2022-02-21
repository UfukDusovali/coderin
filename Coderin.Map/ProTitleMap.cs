using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class ProTitleMap : MapBase<ProTitle>
    {
        public ProTitleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

           

            // Table & Column Mappings
            this.ToTable("ProTitles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TagId).HasColumnName("TagId");
           

            // Relationships
            this.HasRequired(t => t.Tag)
                .WithMany(t => t.ProTitles)
                .HasForeignKey(d => d.TagId);

        }
    }
}
