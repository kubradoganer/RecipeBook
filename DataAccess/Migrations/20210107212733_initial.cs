using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'42', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'17', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'5', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'7', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'11', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'8', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'7', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    RecipeTypeId = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipe_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipe_RecipeType_RecipeTypeId",
                        column: x => x.RecipeTypeId,
                        principalTable: "RecipeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeBook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'8', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeBook_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'7', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItem_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'41', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IngredientTypeId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false),
                    MeasurementTypeId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_IngredientType_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalTable: "IngredientType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_MeasurementType_MeasurementTypeId",
                        column: x => x.MeasurementTypeId,
                        principalTable: "MeasurementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'17', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeTag_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeBookItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'25', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeId = table.Column<int>(nullable: false),
                    RecipeBookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeBookItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeBookItem_RecipeBook_RecipeBookId",
                        column: x => x.RecipeBookId,
                        principalTable: "RecipeBook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeBookItem_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IngredientType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Su" },
                    { 24, "Sosis" },
                    { 26, "Kaşar Peyniri" },
                    { 27, "Mozerella" },
                    { 28, "Sıvıyağ" },
                    { 29, "Zeytinyağ" },
                    { 30, "Roka" },
                    { 31, "Tavuk" },
                    { 32, "Et" },
                    { 33, "Balık" },
                    { 34, "Kemalpaşa" },
                    { 35, "Biber" },
                    { 36, "Pirinç" },
                    { 37, "Tavuk Suyu" },
                    { 38, "Kekik" },
                    { 39, "Karabiber" },
                    { 40, "Pulbiber" },
                    { 41, "Tereyağ" },
                    { 23, "Milföy" },
                    { 22, "Sirke" },
                    { 25, "Salça" },
                    { 20, "Mısır Nişastası" },
                    { 2, "Süt" },
                    { 3, "Şeker" },
                    { 4, "Un" },
                    { 5, "Tuz" },
                    { 6, "Çikolata" },
                    { 7, "Kakao" },
                    { 21, "Nutella" },
                    { 9, "Vanilin" },
                    { 10, "Domates" },
                    { 8, "Kabartma Tozu" },
                    { 12, "Salatalık" },
                    { 11, "Marul" },
                    { 18, "Krema" },
                    { 17, "Bisküvi" },
                    { 19, "Buğday Nişastası" },
                    { 15, "Limon" },
                    { 14, "Turşu" },
                    { 13, "Soğan" },
                    { 16, "Lime" }
                });

            migrationBuilder.InsertData(
                table: "MeasurementType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "1000 ml" },
                    { 16, "25 ml" },
                    { 15, "Yaprak" },
                    { 14, "Çimdik" },
                    { 13, "Gram" },
                    { 12, "1 adet" },
                    { 11, "1 pk" },
                    { 9, "500 ml" },
                    { 1, "250 ml" },
                    { 7, "Çay Kaşığı" },
                    { 6, "Yemek Kaşığı" },
                    { 5, "Çay Bardağı" },
                    { 4, "Su Barağı" },
                    { 3, "50 ml" },
                    { 2, "125 ml" },
                    { 8, "Tatlı Kaşığı" }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Akşam Yemegi" },
                    { 2, "Lezzetli Bir Mola" },
                    { 3, "Tatlı ve Daha Fazlası" },
                    { 4, "Pratik Menü" }
                });

            migrationBuilder.InsertData(
                table: "RecipeType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Şerbetli Tatlılar" },
                    { 4, "Et Yemekleri" },
                    { 6, "Çikolatalı  Tatlılar" },
                    { 2, "Tavuk Yemekleri" },
                    { 1, "Sütlü Tatlılar" },
                    { 3, "Salatalar" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Etli" },
                    { 9, "Az Kalorili" },
                    { 8, "Tuzlu" },
                    { 6, "Pilav" },
                    { 7, "Tatlı" },
                    { 4, "Pratik" },
                    { 3, "Hamur" },
                    { 2, "Şerbet" },
                    { 1, "Çikolata" },
                    { 5, "Tavuk" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 6, "Pierce", "Brosnan", "", "brosnan" },
                    { 1, "Kübra", "Doğan Er", "sffsafsfsfsas", "dogankub" },
                    { 2, "Ralph", "Fiennes", "", "fiennes" },
                    { 3, "Roy", "Scheider", "", "scheider" },
                    { 4, "John", "Candy", "", "candy" },
                    { 5, "Steve", "Buscemi", "", "buscemi" },
                    { 7, "Ewan", "McGregor", "", "mcgregor" }
                });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "Id", "CreatedUserId", "Name", "RecipeTypeId" },
                values: new object[,]
                {
                    { 1, 1, "İzmir Bombası", 6 },
                    { 5, 1, "Et Sote", 4 },
                    { 6, 1, "Tavuklu Pilav", 2 },
                    { 3, 2, "Kemalpaşa", 5 },
                    { 4, 3, "Tavuk Sote", 2 },
                    { 2, 4, "Tavuklu Salata", 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeBook",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Kubra'nın Defteri", 1 },
                    { 2, "Ralph'un Defteri", 2 },
                    { 3, "Roy'un Defteri", 3 },
                    { 4, "John'un Defteri", 4 },
                    { 5, "Steve'n Defteri", 5 },
                    { 6, "Pierce'n Defteri", 6 },
                    { 7, "Ewan'ın Defteri", 7 }
                });

            migrationBuilder.InsertData(
                table: "MenuItem",
                columns: new[] { "Id", "MenuId", "RecipeId" },
                values: new object[,]
                {
                    { 3, 2, 1 },
                    { 4, 3, 1 },
                    { 5, 3, 3 },
                    { 1, 1, 2 },
                    { 6, 4, 2 },
                    { 2, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeBookItem",
                columns: new[] { "Id", "RecipeBookId", "RecipeId" },
                values: new object[,]
                {
                    { 3, 1, 3 },
                    { 5, 2, 5 },
                    { 23, 7, 6 },
                    { 4, 1, 4 },
                    { 8, 3, 6 },
                    { 9, 3, 1 },
                    { 11, 3, 4 },
                    { 2, 1, 2 },
                    { 10, 3, 2 },
                    { 12, 4, 1 },
                    { 13, 4, 5 },
                    { 14, 4, 3 },
                    { 15, 4, 4 },
                    { 16, 4, 6 },
                    { 17, 5, 5 },
                    { 18, 6, 1 },
                    { 19, 6, 4 },
                    { 20, 6, 6 },
                    { 21, 7, 2 },
                    { 22, 7, 3 },
                    { 7, 2, 2 },
                    { 1, 1, 1 },
                    { 6, 2, 1 },
                    { 24, 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "Id", "Amount", "IngredientTypeId", "MeasurementTypeId", "RecipeId" },
                values: new object[,]
                {
                    { 32, 1m, 10, 12, 5 },
                    { 30, 20m, 29, 13, 5 },
                    { 29, 500m, 32, 13, 5 },
                    { 9, 3m, 11, 15, 2 },
                    { 10, 1m, 12, 12, 2 },
                    { 11, 1m, 13, 12, 2 },
                    { 12, 2m, 14, 12, 2 },
                    { 13, 1m, 15, 12, 2 },
                    { 14, 1m, 10, 12, 2 },
                    { 15, 10m, 30, 15, 2 },
                    { 16, 250m, 31, 13, 2 },
                    { 17, 5m, 29, 13, 2 },
                    { 18, 5m, 5, 13, 2 },
                    { 8, 5m, 19, 13, 1 },
                    { 7, 2m, 28, 8, 1 },
                    { 6, 1m, 22, 7, 1 },
                    { 5, 10m, 21, 8, 1 },
                    { 4, 1m, 5, 14, 1 },
                    { 3, 40m, 4, 13, 1 },
                    { 2, 1m, 2, 8, 1 },
                    { 1, 1m, 1, 8, 1 },
                    { 33, 1m, 13, 12, 5 },
                    { 34, 2m, 35, 12, 5 },
                    { 31, 1m, 25, 6, 5 },
                    { 23, 500m, 31, 13, 4 },
                    { 22, 1m, 15, 16, 3 },
                    { 40, 10m, 28, 13, 6 },
                    { 39, 25m, 41, 13, 6 },
                    { 28, 2m, 35, 12, 4 },
                    { 27, 1m, 13, 12, 4 },
                    { 26, 1m, 10, 12, 4 },
                    { 25, 1m, 25, 6, 4 },
                    { 24, 20m, 29, 13, 4 },
                    { 21, 4m, 3, 4, 3 },
                    { 35, 300m, 31, 13, 6 },
                    { 36, 2m, 36, 4, 6 },
                    { 37, 3m, 37, 4, 6 },
                    { 38, 2m, 39, 13, 6 },
                    { 19, 1m, 34, 11, 3 },
                    { 20, 5m, 1, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeTag",
                columns: new[] { "Id", "RecipeId", "TagId" },
                values: new object[,]
                {
                    { 13, 5, 10 },
                    { 14, 6, 5 },
                    { 1, 1, 1 },
                    { 2, 1, 7 },
                    { 7, 3, 7 },
                    { 6, 2, 8 },
                    { 5, 2, 5 },
                    { 4, 2, 9 },
                    { 12, 5, 8 },
                    { 8, 3, 2 },
                    { 9, 3, 3 },
                    { 15, 6, 6 },
                    { 10, 4, 8 },
                    { 11, 4, 5 },
                    { 3, 1, 4 },
                    { 16, 6, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuId",
                table: "MenuItem",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_RecipeId",
                table: "MenuItem",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_CreatedUserId",
                table: "Recipe",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_RecipeTypeId",
                table: "Recipe",
                column: "RecipeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeBook_UserId",
                table: "RecipeBook",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeBookItem_RecipeBookId",
                table: "RecipeBookItem",
                column: "RecipeBookId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeBookItem_RecipeId",
                table: "RecipeBookItem",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_IngredientTypeId",
                table: "RecipeIngredient",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_MeasurementTypeId",
                table: "RecipeIngredient",
                column: "MeasurementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                table: "RecipeIngredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTag_RecipeId",
                table: "RecipeTag",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTag_TagId",
                table: "RecipeTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "RecipeBookItem");

            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "RecipeTag");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "RecipeBook");

            migrationBuilder.DropTable(
                name: "IngredientType");

            migrationBuilder.DropTable(
                name: "MeasurementType");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "RecipeType");
        }
    }
}
