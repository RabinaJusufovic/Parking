using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace parking.database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    day = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Month",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    month = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(nullable: true),
                    latitude = table.Column<long>(nullable: false),
                    longitude = table.Column<long>(nullable: false),
                    phone = table.Column<int>(nullable: false),
                    workingHours = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    availability = table.Column<bool>(nullable: false),
                    rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    signUpDate = table.Column<DateTime>(nullable: false),
                    dayRefId = table.Column<int>(nullable: false),
                    monthRefId = table.Column<int>(nullable: false),
                    yearRefId = table.Column<int>(nullable: false),
                    roleRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Day_dayRefId",
                        column: x => x.dayRefId,
                        principalTable: "Day",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Month_monthRefId",
                        column: x => x.monthRefId,
                        principalTable: "Month",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Role_roleRefId",
                        column: x => x.roleRefId,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Year_yearRefId",
                        column: x => x.yearRefId,
                        principalTable: "Year",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    userRefId = table.Column<int>(nullable: false),
                    parkingRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Parking_parkingRefId",
                        column: x => x.parkingRefId,
                        principalTable: "Parking",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_User_userRefId",
                        column: x => x.userRefId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usersRefId = table.Column<int>(nullable: false),
                    parkingsRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favorite_Parking_parkingsRefId",
                        column: x => x.parkingsRefId,
                        principalTable: "Parking",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorite_User_usersRefId",
                        column: x => x.usersRefId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(nullable: false),
                    timeComing = table.Column<int>(nullable: false),
                    timeLeaving = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    parkingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reserve_Parking_parkingId",
                        column: x => x.parkingId,
                        principalTable: "Parking",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserve_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    counter = table.Column<int>(nullable: false),
                    commentRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.id);
                    table.ForeignKey(
                        name: "FK_Like_Comments_commentRefId",
                        column: x => x.commentRefId,
                        principalTable: "Comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subcommnets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment = table.Column<string>(nullable: true),
                    commentsRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcommnets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Subcommnets_Comments_commentsRefId",
                        column: x => x.commentsRefId,
                        principalTable: "Comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_parkingRefId",
                table: "Comments",
                column: "parkingRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userRefId",
                table: "Comments",
                column: "userRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_parkingsRefId",
                table: "Favorite",
                column: "parkingsRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_usersRefId",
                table: "Favorite",
                column: "usersRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_commentRefId",
                table: "Like",
                column: "commentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_parkingId",
                table: "Reserve",
                column: "parkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_userId",
                table: "Reserve",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcommnets_commentsRefId",
                table: "Subcommnets",
                column: "commentsRefId");

            migrationBuilder.CreateIndex(
                name: "IX_User_dayRefId",
                table: "User",
                column: "dayRefId");

            migrationBuilder.CreateIndex(
                name: "IX_User_monthRefId",
                table: "User",
                column: "monthRefId");

            migrationBuilder.CreateIndex(
                name: "IX_User_roleRefId",
                table: "User",
                column: "roleRefId");

            migrationBuilder.CreateIndex(
                name: "IX_User_yearRefId",
                table: "User",
                column: "yearRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Reserve");

            migrationBuilder.DropTable(
                name: "Subcommnets");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Year");
        }
    }
}
