using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _14530_employes_managment.Data.Migrations
{
    /// <inheritdoc />
    public partial class instruments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Employees",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.Sql(@"
                UPDATE [Employees]
                SET [Department] = CASE
                    WHEN [Department] IN ('0', 'Administration', 'administration', 'ADMINISTRATION') THEN 'Administration'
                    WHEN [Department] IN ('1', 'Engineer', 'engineer', 'ENGINEER') THEN 'Engineer'
                    WHEN [Department] IN ('2', 'Worker', 'worker', 'WORKER') THEN 'Worker'
                    WHEN [Department] IS NULL OR LTRIM(RTRIM([Department])) = '' THEN 'Worker'
                    ELSE 'Worker'
                END;
            ");

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeInstrument = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    InstrumentName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    UseStrings = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.id);
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Employees_Department",
                table: "Employees",
                sql: "[Department] IN ('Administration','Engineer','Worker')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Employees_Department",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);
        }
    }
}
