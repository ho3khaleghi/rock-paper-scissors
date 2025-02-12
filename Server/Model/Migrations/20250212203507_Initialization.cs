using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockPaperScissors.Model.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LastLoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Badge = table.Column<int>(type: "int", nullable: false),
                    TotalMatch = table.Column<int>(type: "int", nullable: true),
                    TotalWin = table.Column<int>(type: "int", nullable: true),
                    TotalLose = table.Column<int>(type: "int", nullable: true),
                    TotalScore = table.Column<int>(type: "int", nullable: true),
                    Version = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player1Id = table.Column<long>(type: "bigint", nullable: false),
                    Player2Id = table.Column<long>(type: "bigint", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    MatchMode = table.Column<int>(type: "int", nullable: false),
                    MatchStatus = table.Column<int>(type: "int", nullable: false),
                    RoundCount = table.Column<int>(type: "int", nullable: false),
                    WinnerId = table.Column<long>(type: "bigint", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Player_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Player_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Player_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<long>(type: "bigint", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: true),
                    Player1Move = table.Column<int>(type: "int", nullable: true),
                    Player2Move = table.Column<int>(type: "int", nullable: true),
                    WinnerId = table.Column<long>(type: "bigint", nullable: true),
                    Result = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_Player1Id",
                table: "Match",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Player2Id",
                table: "Match",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_WinnerId",
                table: "Match",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_UserId",
                table: "Player",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Round_MatchId",
                table: "Round",
                column: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
