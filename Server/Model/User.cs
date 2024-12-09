using Core.Kernel.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissors.Model
{
    public class User : IntBasedEntity
    {
        public string? UserName { get; set; }
        public byte[]? Password { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public bool Deleted { get; set; }
        
        public override Action<ModelBuilder> OnConfiguringEntity => ConfigureEntity;
        
        private void ConfigureEntity(ModelBuilder modelBuilder)
        {
            var entityType = modelBuilder.Entity<User>();
            
            entityType.Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(20);

            entityType.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(32);

            entityType.Property(p => p.CreationDateTime)
                .IsRequired();
        }
    }
}
