using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreaationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LabelType",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LabelURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HallID = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreaationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LabelType_Halls_HallID",
                        column: x => x.HallID,
                        principalTable: "Halls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HallID = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreaationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Machines_Halls_HallID",
                        column: x => x.HallID,
                        principalTable: "Halls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabelData",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Interwoven = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MachineID = table.Column<long>(type: "bigint", nullable: false),
                    Filament = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Den = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Ply = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Mingel = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    direction = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Emptyfield1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Emptyfield2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Emptyfield3 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Emptyfield4 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Emptyfield5 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YarnType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreaationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LabelData_Machines_MachineID",
                        column: x => x.MachineID,
                        principalTable: "Machines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelData_MachineID",
                table: "LabelData",
                column: "MachineID");

            migrationBuilder.CreateIndex(
                name: "IX_LabelType_HallID",
                table: "LabelType",
                column: "HallID");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_HallID",
                table: "Machines",
                column: "HallID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelData");

            migrationBuilder.DropTable(
                name: "LabelType");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Halls");
        }
    }
}
