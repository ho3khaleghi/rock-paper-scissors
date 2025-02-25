using Core.Kernel.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissors.Model
{
    public class Profile : LongBasedEntity
    {
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; }= null;
        public string? Email { get; set; }
        public string? AlternateEmail { get; set; } = null;
        public string? PhoneNumber { get; set; }

        public User User { get; set; } = null!;

        public override Action<ModelBuilder> OnConfiguringEntity => ConfigureEntity;

        private void ConfigureEntity(ModelBuilder modelBuilder)
        {
            var entityType = modelBuilder.Entity<Profile>();

            entityType.Property(p => p.Id)
                .IsRequired();

            entityType.Property(p => p.FirstName)
                .HasMaxLength(50);

            entityType.Property(p => p.LastName)
                .HasMaxLength(50);

            entityType.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(254);

            entityType.Property(p => p.AlternateEmail)
                .HasMaxLength(254);

            entityType.Property(p => p.PhoneNumber)
                .HasMaxLength(20);

            entityType.HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Profile>(p => p.Id);
        }
    }
}
