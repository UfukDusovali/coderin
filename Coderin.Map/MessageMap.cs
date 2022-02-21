using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Coderin.Entity;
using Coderin.Base;

namespace Coderin.Map
{
    public class MessageMap : MapBase<Message>
    {
        public MessageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.MessageBody)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.ReadIP)
                .IsRequired()
                .HasMaxLength(15);

           
            // Table & Column Mappings
            this.ToTable("Messages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SenderId).HasColumnName("SenderId");
            this.Property(t => t.ReceiverId).HasColumnName("ReceiverId");
            this.Property(t => t.ChatId).HasColumnName("ChatId");
            this.Property(t => t.MessageBody).HasColumnName("MessageBody");
            this.Property(t => t.Name).HasColumnName("Name");
            

            // Relationships
            this.HasOptional(t => t.Chat)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.ChatId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.SenderId);
            this.HasRequired(t => t.User1)
                .WithMany(t => t.Messages1)
                .HasForeignKey(d => d.ReceiverId);

        }
    }
}
