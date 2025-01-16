using Core.Kernel.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissors.Model
{
    public class Match : LongBasedEntity
    {
        public Guid? MatchSessionId { get; set; }
        public long? Player1Id { get; set; }
        public long? Player2Id { get; set; }
        public int? DifficultyLevel { get; set; }
        public int? MatchMode { get; set; }
        public int? MatchStatus { get; set; }
        public int? RoundCount { get; set; }
        public long? WinnerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Player? Player1 { get; set; }
        public Player? Player2 { get; set; }
        public Player? Winner { get; set; }

        public override Action<ModelBuilder> OnConfiguringEntity => ConfigureEntity;

        private void ConfigureEntity(ModelBuilder modelBuilder)
        {
            var entityType = modelBuilder.Entity<Match>();

            entityType.Property(p => p.Id)
                .UseIdentityColumn();

            entityType.Property(p => p.MatchSessionId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            entityType.Property(p => p.Player1Id)
                .IsRequired();

            entityType.Property(p => p.Player2Id)
                .IsRequired();

            entityType.Property(p => p.DifficultyLevel)
                .IsRequired();

            entityType.Property(p => p.MatchMode)
                .IsRequired();

            entityType.Property(p => p.MatchStatus)
                .IsRequired();

            entityType.Property(p => p.RoundCount)
                .IsRequired();

            entityType.Property(p => p.StartDate)
                .IsRequired();

            entityType.Property(p => p.Version)
                .HasColumnType("timestamp")
                .IsRowVersion();

            entityType.HasOne(p => p.Player1)
                .WithMany()
                .HasForeignKey(p => p.Player1Id);

            entityType.HasOne(p => p.Player2)
                .WithMany()
                .HasForeignKey(p => p.Player2Id);

            entityType.HasOne(p => p.Winner)
                .WithMany()
                .HasForeignKey(p => p.WinnerId);
        }
    }
}
