using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationTaskUppgift.Migrations
{
    /// <inheritdoc />
    public partial class initsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentRequests",
                columns: table => new
                {
                    CurrentVacId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    FK_RequestVacationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentRequests", x => x.CurrentVacId);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    FK_RequestVacationId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    maxTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "VacationStatuses",
                columns: table => new
                {
                    VacationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CurrentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FK_CurrentRequestId = table.Column<int>(type: "int", nullable: false),
                    FK_Personel = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationStatuses", x => x.VacationStatusId);
                    table.ForeignKey(
                        name: "FK_VacationStatuses_CurrentRequests_FK_CurrentRequestId",
                        column: x => x.FK_CurrentRequestId,
                        principalTable: "CurrentRequests",
                        principalColumn: "CurrentVacId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationStatuses_Personels_FK_Personel",
                        column: x => x.FK_Personel,
                        principalTable: "Personels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestVacations",
                columns: table => new
                {
                    RequestVacId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FK_VacationType = table.Column<int>(type: "int", nullable: false),
                    FK_Personel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CurrentRequestsModelCurrentVacId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestVacations", x => x.RequestVacId);
                    table.ForeignKey(
                        name: "FK_RequestVacations_CurrentRequests_CurrentRequestsModelCurrentVacId",
                        column: x => x.CurrentRequestsModelCurrentVacId,
                        principalTable: "CurrentRequests",
                        principalColumn: "CurrentVacId");
                    table.ForeignKey(
                        name: "FK_RequestVacations_Personels_PersonelsId",
                        column: x => x.PersonelsId,
                        principalTable: "Personels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestVacations_VacationTypes_FK_VacationType",
                        column: x => x.FK_VacationType,
                        principalTable: "VacationTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestVacations_CurrentRequestsModelCurrentVacId",
                table: "RequestVacations",
                column: "CurrentRequestsModelCurrentVacId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestVacations_FK_VacationType",
                table: "RequestVacations",
                column: "FK_VacationType");

            migrationBuilder.CreateIndex(
                name: "IX_RequestVacations_PersonelsId",
                table: "RequestVacations",
                column: "PersonelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationStatuses_FK_CurrentRequestId",
                table: "VacationStatuses",
                column: "FK_CurrentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationStatuses_FK_Personel",
                table: "VacationStatuses",
                column: "FK_Personel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestVacations");

            migrationBuilder.DropTable(
                name: "VacationStatuses");

            migrationBuilder.DropTable(
                name: "VacationTypes");

            migrationBuilder.DropTable(
                name: "CurrentRequests");

            migrationBuilder.DropTable(
                name: "Personels");
        }
    }
}
