using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class FollowMap : MapBase<Follow>
    {
        public FollowMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);


            // Table & Column Mappings
            this.ToTable("Follows");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FollowingId).HasColumnName("FollowingId");
            this.Property(t => t.FollowerId).HasColumnName("FollowerId");
           

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Follows)
                .HasForeignKey(d => d.FollowingId);
            this.HasRequired(t => t.User1)
                .WithMany(t => t.Follows1)
                .HasForeignKey(d => d.FollowerId);

        }
    }
}
