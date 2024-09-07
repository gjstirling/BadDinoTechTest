﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadDinosaurCodeTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class Scores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: true),
                    DinosaurId = table.Column<int>(type: "INTEGER", nullable: false),
                    DinoClassId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_DinoClass_DinoClassId",
                        column: x => x.DinoClassId,
                        principalTable: "DinoClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_Dinosaurs_DinosaurId",
                        column: x => x.DinosaurId,
                        principalTable: "Dinosaurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_DinoClassId",
                table: "Scores",
                column: "DinoClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_DinosaurId",
                table: "Scores",
                column: "DinosaurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");
        }
    }
}
