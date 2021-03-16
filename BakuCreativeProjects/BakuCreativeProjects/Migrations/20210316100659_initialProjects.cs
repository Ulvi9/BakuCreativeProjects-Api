using Microsoft.EntityFrameworkCore.Migrations;

namespace BakuCreativeProjects.Migrations
{
    public partial class initialProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCategories_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MainCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Kisi" });

            migrationBuilder.InsertData(
                table: "MainCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Qadin" });

            migrationBuilder.InsertData(
                table: "MainCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Usaq" });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "MainCategoryId", "Name" },
                values: new object[] { 1, 1, "Ayaqqabi" });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "MainCategoryId", "Name" },
                values: new object[] { 2, 1, "Aksesuar" });

            migrationBuilder.InsertData(
                table: "ChildCategories",
                columns: new[] { "Id", "Name", "SubCategoryId" },
                values: new object[] { 1, "Sport", 1 });

            migrationBuilder.InsertData(
                table: "ChildCategories",
                columns: new[] { "Id", "Name", "SubCategoryId" },
                values: new object[] { 2, "Klassik", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategories_SubCategoryId",
                table: "ChildCategories",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_MainCategoryId",
                table: "SubCategories",
                column: "MainCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildCategories");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "MainCategories");
        }
    }
}
