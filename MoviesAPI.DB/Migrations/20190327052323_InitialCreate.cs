using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAPI.DB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    YearOfRelease = table.Column<int>(nullable: false),
                    RunningTime = table.Column<double>(nullable: false),
                    AverageRating = table.Column<double>(nullable: false),
                    Genres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    MovieID = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRatings_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AverageRating", "Genres", "RunningTime", "Title", "YearOfRelease" },
                values: new object[,]
                {
                    { 1, 4.0, "Drama", 145.0, "MoonLight", 2016 },
                    { 2, 3.0, "Comedy,Drama,Romance", 125.0, "Trainwreck", 2015 },
                    { 3, 4.0, "Adventure,Drama,Sci-Fi", 144.0, "The Martian", 2015 },
                    { 4, 0.0, "Action, Adventure, Sci-Fi", 125.0, "Jurassic World", 2015 },
                    { 5, 3.5, "Action,Adventure,Fantasy", 151.0, "Batman v Superman= Dawn of Justice", 2016 },
                    { 6, 3.0, "Action,Adventure,Sci-Fi", 147.0, "Captain America= Civil War", 2016 },
                    { 7, 3.3333, "Action,Adventure,Sci-Fi", 144.0, "X-Men= Apocalypse", 2016 },
                    { 8, 0.0, "Action,Comedy", 102.0, "Ride Along 2", 2016 },
                    { 9, 0.0, "Action,Comedy", 102.0, "Finding Dory", 2016 },
                    { 10, 2.0, "Action,Drama,Sci-Fi", 137.0, "Logan", 2017 },
                    { 11, 3.25, "Family,Fantasy,Musical", 129.0, "Beauty and the Beast", 2017 }
                });

            migrationBuilder.InsertData(
                table: "UserRatings",
                columns: new[] { "Id", "MovieID", "Rating", "UserID" },
                values: new object[,]
                {
                    { 1004, 1, 4, 4 },
                    { 7, 11, 5, 2 },
                    { 6, 11, 3, 1 },
                    { 5, 10, 3, 1 },
                    { 1003, 7, 2, 1 },
                    { 14, 7, 5, 6 },
                    { 13, 7, 1, 5 },
                    { 12, 7, 3, 4 },
                    { 11, 7, 4, 3 },
                    { 10, 7, 5, 2 },
                    { 16, 6, 1, 3 },
                    { 15, 6, 3, 2 },
                    { 4, 6, 5, 1 },
                    { 17, 5, 3, 3 },
                    { 3, 5, 4, 1 },
                    { 18, 3, 3, 3 },
                    { 1, 3, 5, 1 },
                    { 2, 2, 3, 1 },
                    { 8, 11, 2, 3 },
                    { 9, 11, 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_MovieID",
                table: "UserRatings",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "UserRatings");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
