using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class ErrorLogMap : MapBase<ErrorLog>
    {
        public ErrorLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ErrorCode)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.ErrorMessage)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.CustomMesaj)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

           

            // Table & Column Mappings
            this.ToTable("ErrorLog");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ErrorCode).HasColumnName("ErrorCode");
            this.Property(t => t.ErrorMessage).HasColumnName("ErrorMessage");
            this.Property(t => t.CustomMesaj).HasColumnName("CustomMesaj");
            this.Property(t => t.Name).HasColumnName("Name");
           
        }
    }
}
