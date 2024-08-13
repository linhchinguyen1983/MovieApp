using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Migrations
{
    public partial class fixmovieactordb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors");

            migrationBuilder.DropIndex(
                name: "IX_MoviesActors_MoviesId",
                table: "MoviesActors");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MoviesActors");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "MoviesActors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors",
                columns: new[] { "MoviesId", "ActorsId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "MoviesActors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ActorId",
                table: "MoviesActors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors",
                columns: new[] { "MovieId", "ActorId" });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActors_MoviesId",
                table: "MoviesActors",
                column: "MoviesId");
        }
    }
}
