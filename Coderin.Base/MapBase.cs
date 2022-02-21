using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coderin.Base
{
    public class MapBase<T> : EntityTypeConfiguration<T> where T : EntityBase
    {
        public MapBase()
        {
            Property(t => t.CreatedIP)
               .IsRequired()
               .HasMaxLength(15);

            Property(t => t.CreatedMAC)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.ModifiedMAC)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.ModifiedIP)
                .IsRequired()
                .HasMaxLength(15);

            Property(t => t.ModifiedComputerName)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.ModifiedADUsername)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.AutoID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.CreateDate).HasColumnName("CreateDate");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.CreatedIP).HasColumnName("CreatedIP");
            Property(t => t.CreatedMAC).HasColumnName("CreatedMAC");
            Property(t => t.ModifiedMAC).HasColumnName("ModifiedMAC");
            Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            Property(t => t.ModifiedIP).HasColumnName("ModifiedIP");
            Property(t => t.ModifiedComputerName).HasColumnName("ModifiedComputerName");
            Property(t => t.ModifiedADUsername).HasColumnName("ModifiedADUsername");
            Property(t => t.AutoID).HasColumnName("AutoID");
        }
    }
}
