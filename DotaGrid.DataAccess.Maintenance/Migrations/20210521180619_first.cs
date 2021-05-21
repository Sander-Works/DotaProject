using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaGrid.DataAccess.Maintenance.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainAttributes",
                columns: table => new
                {
                    MainattributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainAttributeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAttributes", x => x.MainattributeId);
                });

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    HeroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Q = table.Column<string>(nullable: true),
                    W = table.Column<string>(nullable: true),
                    E = table.Column<string>(nullable: true),
                    Ultimate = table.Column<string>(nullable: true),
                    Hp = table.Column<int>(nullable: false),
                    Mana = table.Column<int>(nullable: false),
                    Ms = table.Column<int>(nullable: false),
                    Armor = table.Column<int>(nullable: false),
                    MainattributeId = table.Column<int>(nullable: true),
                    Playstyle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.HeroId);
                    table.ForeignKey(
                        name: "FK_Hero_MainAttributes_MainattributeId",
                        column: x => x.MainattributeId,
                        principalTable: "MainAttributes",
                        principalColumn: "MainattributeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hero_MainattributeId",
                table: "Hero",
                column: "MainattributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "MainAttributes");
        }
    }
}
