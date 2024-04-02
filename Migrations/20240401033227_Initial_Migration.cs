using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Menu.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishIngerdients",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngerdients", x => new { x.DishId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_DishIngerdients_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngerdients_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "ImagUrl", "Name", "Price" },
                values: new object[] { 1, "https://www.google.com/imgres?imgurl=https%3A%2F%2Fuk.ooni.com%2Fcdn%2Fshop%2Farticles%2F20220211142645-margherita-9920.jpg%3Fcrop%3Dcenter%26height%3D800%26v%3D1660843558%26width%3D800&tbnid=A6rvFlXyzPB0vM&vet=12ahUKEwi38LbigqCFAxXzTKQEHQNnAwoQMygEegQIARBb..i&imgrefurl=https%3A%2F%2Fuk.ooni.com%2Fblogs%2Frecipes%2Fmargherita-pizza&docid=uTEBLKhJ1uvHvM&w=800&h=800&q=margherita%20pizza&ved=2ahUKEwi38LbigqCFAxXzTKQEHQNnAwoQMygEegQIARBb", "Margherita", 7.5 });

            migrationBuilder.InsertData(
                table: "ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tomato Sauco " },
                    { 2, "Mozzarila " }
                });

            migrationBuilder.InsertData(
                table: "DishIngerdients",
                columns: new[] { "DishId", "IngredientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngerdients_IngredientId",
                table: "DishIngerdients",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngerdients");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "ingredients");
        }
    }
}
