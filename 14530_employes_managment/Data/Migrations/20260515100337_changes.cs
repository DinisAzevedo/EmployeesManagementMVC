using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _14530_employes_managment.Data.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Employees_Department",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Employees",
                newName: "Function");

            migrationBuilder.AlterColumn<bool>(
                name: "UseStrings",
                table: "Instruments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Employees_Function",
                table: "Employees",
                sql: "[Function] IN ('Administration','Engineer','Worker')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Employees_Function",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Function",
                table: "Employees",
                newName: "Department");

            migrationBuilder.AlterColumn<bool>(
                name: "UseStrings",
                table: "Instruments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Employees_Department",
                table: "Employees",
                sql: "[Department] IN ('Administration','Engineer','Worker')");
        }
    }
}
