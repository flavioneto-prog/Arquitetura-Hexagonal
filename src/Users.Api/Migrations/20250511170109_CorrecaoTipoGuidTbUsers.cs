using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiteturaHexagonal.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTipoGuidTbUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USERS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    Email = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USERS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USERS");
        }
    }
}
