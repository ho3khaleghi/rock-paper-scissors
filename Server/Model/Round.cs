using Core.Kernel.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissors.Model
{
    public class Round : LongBasedEntity
    {
        public long? MatchId { get; set; }
        public int? RoundNumber { get; set; }
        public int? Player1Move { get; set; }
        public int? Player2Move { get; set; }
        public long? WinnerId { get; set; }
        public int? Result { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Match? Match { get; set; }
        public override Action<ModelBuilder> OnConfiguringEntity => ConfigureEntity;

        private void ConfigureEntity(ModelBuilder modelBuilder)
        {
            var entityType = modelBuilder.Entity<Round>();

            entityType.Property(p => p.Id)
                .UseIdentityColumn();

            entityType.Property(p => p.MatchId)
                .IsRequired();

            entityType.Property(p => p.StartDate)
                .IsRequired();

            entityType.Property(p => p.Version)
                .HasColumnType("timestamp")
                .IsRowVersion();

            entityType.HasOne(p => p.Match)
                .WithMany()
                .HasForeignKey(p => p.MatchId);
        }
    }
}
