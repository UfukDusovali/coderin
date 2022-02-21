using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class LogMap : MapBase<Log>
    {
        public LogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TableName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ProcessType)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

           

            // Table & Column Mappings
            this.ToTable("Log");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TableName).HasColumnName("TableName");
            this.Property(t => t.ProcessType).HasColumnName("ProcessType");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Name).HasColumnName("Name");
           

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Logs)
                .HasForeignKey(d => d.UserId);

        }
    }
}
