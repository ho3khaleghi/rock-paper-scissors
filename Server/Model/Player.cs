using Core.Kernel.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissors.Model
{
    public class Player : LongBasedEntity
    {
        public long? UserId { get; set; }
        public int? Rank { get; set; }
        public string? Title { get; set; }
        public int? Badge { get; set; }
        public int? TotalMatch { get; set; }
        public int? TotalWin { get; set; }
        public int? TotalLose { get; set; }
        public int? TotalScore { get; set; }

        public User? User { get; set; }
        public override Action<ModelBuilder> OnConfiguringEntity => ConfigureEntity;

        private void ConfigureEntity(ModelBuilder modelBuilder)
        {
            var entityType = modelBuilder.Entity<Player>();

            entityType.Property(p => p.Id)
                .UseIdentityColumn();

            entityType.Property(p => p.UserId)
                .IsRequired();

            entityType.Property(p => p.Rank)
                .IsRequired();

            entityType.Property(p => p.Badge)
                .IsRequired();

            entityType.Property(p => p.Version)
                .HasColumnType("timestamp")
                .IsRowVersion();

            entityType.HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Player>(p => p.UserId);
        }
    }
}
