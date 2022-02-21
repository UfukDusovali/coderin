using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class ChatMap : MapBase<Chat>
    {
        public ChatMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Subject)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

           

            // Table & Column Mappings
            this.ToTable("Chat");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ChatId).HasColumnName("ChatId");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Name).HasColumnName("Name");
            

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Chats)
                .HasForeignKey(d => d.UserId);

        }
    }
}
